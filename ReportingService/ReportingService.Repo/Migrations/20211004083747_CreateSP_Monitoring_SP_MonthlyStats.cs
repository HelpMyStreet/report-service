using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportingService.Repo.Migrations
{
    public partial class CreateSP_Monitoring_SP_MonthlyStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE [Monitoring].[SP_MonthlyStats]
	@Date DATE

	AS

  /* Declare variables */
  DECLARE	@BaseDate DATE
			,@EndDate DATE
			,@PartMonth BIT

  SELECT	@Date = ISNULL(@Date,GETDATE())

  SELECT	@BaseDate = DATEFROMPARTS(YEAR(@Date),MONTH(@Date),1)
  SELECT	@EndDate = DATEADD(DD,-1,DATEADD(MM,1,@BaseDate))

  SELECT	@PartMonth = CASE	WHEN GETDATE() > @EndDate THEN 0
								ELSE 1
								END

  /* Create temp table */
  IF OBJECT_ID('tempdb..[#MonthlyStats]') IS NOT NULL
    DROP TABLE [#MonthlyStats]

  CREATE TABLE [#MonthlyStats]
	( [GroupID] INT
	  ,[Timestamp] DATETIME
	  ,[TimePeriod] VARCHAR(30)
	  ,[GroupName] VARCHAR(100)
	  ,[Subgroup] VARCHAR(100)
	  ,[Members] INT
	  ,[Admins] INT
	  ,[ActiveVols] INT
	  ,[NonMemberVols] INT
	  ,[YotiIDs] INT
	  ,[OtherCredentials] INT
	  ,[Requests] INT
	  ,[Jobs] INT
	  ,[Jobs_Cancelled] VARCHAR(6)
	  ,[Jobs_Completed] VARCHAR(6)
	  ,[Jobs_Overdue] VARCHAR(6)
	  ,[TopActivities] VARCHAR(MAX)
	  PRIMARY KEY ([GroupID],[Timestamp]) )


			
  /* Insert specific month stats */
  INSERT INTO [#MonthlyStats]
  SELECT	[G].[ID] AS [GroupID]
			,CASE WHEN @PartMonth = 1 THEN GETDATE() ELSE @EndDate END
			,CONCAT(DATENAME(MM,@Date),' ',DATEPART(YY,@Date),CASE WHEN @PartMonth = 1 THEN ' (to date)' END) AS [TimePeriod]
			,ISNULL([PG].[GroupName],[G].[GroupName]) AS [Group]
			,CASE	WHEN [G].[ParentGroupID] IS NOT NULL THEN [G].[GroupName]
					END AS [Subgroup]
			,[U].[Members]
			,[U].[Admins]
			,[U].[ActiveVols]
			,[U].[NonMemberVols]
			,[U].[Yoti]
			,[C].[Other]
			,[R].[Requests]
			,[R].[Jobs]
			,[R].[CancelledJobs]
			,[R].[CompleteJobs]
			,[R].[OverdueJobs]
			,[A].[TopActivities]
	FROM	[GroupLatest].[Group]
			  AS [G]
			LEFT JOIN
			(
			  SELECT	[ID]
						,MIN([DateFrom]) AS [DateFrom]
				FROM	[Group].[Group]
				GROUP BY [ID]
			)
			  AS [DateFrom]
			  ON [G].[ID] = [DateFrom].[ID]
			LEFT JOIN
			[GroupLatest].[Group]
			  AS [PG]
			  ON [G].[ParentGroupID] = [PG].[ID]
			LEFT JOIN
			(
			  SELECT	ISNULL([UR].[GroupID],[V].[ReferringGroupID]) AS [GroupID]
						,COUNT(DISTINCT CASE	WHEN [R].[Name] = 'Member' THEN [UR].[UserID]
												END) AS [Members]
						,COUNT(DISTINCT CASE	WHEN [R].[Name] IN ('RequestSubmitter') OR [R].[Name] LIKE '%Admin%' THEN [UR].[UserID]
												END) AS [Admins]
						,COUNT(DISTINCT CASE	WHEN [V].[Member] = 1 THEN [V].[VolunteerUserID]
												END) AS [ActiveVols]
						,COUNT(DISTINCT CASE	WHEN [V].[Member] <> 1 THEN [V].[VolunteerUserID]
												END) AS [NonMemberVols]
						,COUNT(DISTINCT CASE	WHEN [Y].[UserID] IS NOT NULL THEN CONCAT([UR].[UserID],[Y].[DateAdded])
												END) AS [Yoti]
				FROM	(
						  SELECT	*
							FROM	[GroupLatest].[UserRoleAudit]
							WHERE	CAST([DateRequested] AS DATE) BETWEEN @BaseDate AND @EndDate
									  AND [Success] = 1
									  AND [ActionID] = 1
						)
						  AS [UR]
						LEFT JOIN
						[Lookup].[Role]
						  AS [R]
						  ON [UR].[RoleID] = [R].[ID]
						LEFT JOIN
						(
						  SELECT	*
							FROM	(
									  SELECT	[UC].[UserID]
												,[URA].[GroupID]
												,[UC].[DateAdded]
												,[URA].[ActionID]
												,ROW_NUMBER() OVER (PARTITION BY [UC].[UserID],[URA].[GroupID] ORDER BY [URA].[DateRequested] DESC) AS [RonwNum]
										FROM	[GroupLatest].[UserCredential]
												  AS [UC]
												LEFT JOIN
												[GroupLatest].[UserRoleAudit]
												  AS [URA]
												  ON [UC].[UserID] = [URA].[UserID]
														AND [URA].[RoleID] = 1
														AND [URA].[Success] = 1
														AND [URA].[DateRequested] <= [UC].[DateAdded]
										WHERE	[CredentialID] = (SELECT [ID] FROM [GroupLatest].[Credential] WHERE [Name] = 'IdentityVerifiedByYoti')
												  AND CAST([DateAdded] AS DATE) BETWEEN @BaseDate AND @EndDate
									)
									  AS [A]
							WHERE	[A].[RonwNum] = 1
									  AND [A].[ActionID] = 1
						)
						  AS [Y]
						  ON [UR].[UserID] = [Y].[UserID]
							   AND [UR].[GroupID] = [Y].[GroupID]
						FULL OUTER JOIN
						(
						  SELECT	[ReferringGroupID]
									,[VolunteerUserID]
									,MAX([Member]) AS [Member]
							FROM	(
									  SELECT	[R].[ReferringGroupID]
												,[RJS].[VolunteerUserID]
												,[J].[ID] AS [JobID]
												,ROW_NUMBER() OVER (PARTITION BY [RJS].[VolunteerUserID],[J].[ID] ORDER BY [RJS].[DateCreated] DESC) AS [RowNum]
												,CASE WHEN [URA].[ActionID] = 1 THEN 1 ELSE 0 END AS [Member]
										FROM	[RequestLatest].[Request]
												  AS [R]
												LEFT JOIN
												[RequestLatest].[Job]
												  AS [J]
												  ON [R].[ID] = [J].[RequestID]
												LEFT JOIN
												[RequestLatest].[RequestJobStatus]
												  AS [RJS]
												  ON [J].[ID] = [RJS].[JobID]
												LEFT JOIN
												[GroupLatest].[UserRoleAudit]
												  AS [URA]
												  ON [RJS].[VolunteerUserID] = [URA].[UserID]
													   AND [R].[ReferringGroupID] = [URA].[GroupID]
													   AND [URA].[RoleID] = 1
													   AND [URA].[Success] = 1
													   AND [URA].[DateRequested] <= [RJS].[DateCreated]
										WHERE	CAST([RJS].[DateCreated] AS DATE) BETWEEN @BaseDate AND @EndDate
									)
									  AS [A]
							WHERE	[RowNum] = 1
							GROUP BY [VolunteerUserID]
									,[ReferringGroupID]					
						)
						  AS [V]
						  ON [UR].[UserID] = [V].[VolunteerUserID]
							   AND [V].[ReferringGroupID] = [UR].[GroupID]
				GROUP BY ISNULL([UR].[GroupID],[V].[ReferringGroupID])
			)
			  AS [U]
			  ON [G].[ID] = [U].[GroupID]
			LEFT JOIN
			(
			  SELECT	[GroupID]
						,SUM(CASE WHEN [C].[Name] <> 'IdentityVerifiedByYoti' THEN 1 END) AS [Other]
				FROM	[GroupLatest].[UserCredential]
						  AS [UC]
						LEFT JOIN
						[GroupLatest].[Credential]
						  AS [C]
						  ON [UC].[CredentialID] = [C].[ID]
				WHERE	CAST([DateAdded] AS DATE) BETWEEN @BaseDate AND @EndDate
				GROUP BY [GroupID]
			)
			  AS [C]
			  ON [G].[ID] = [C].[GroupID]
			LEFT JOIN
			(
			  SELECT	[R].[ReferringGroupID]
						,COUNT(DISTINCT [R].[ID]) AS [Requests]
						,COUNT(DISTINCT [J].[ID]) AS [Jobs]
						,CONCAT(CAST(COUNT(DISTINCT CASE WHEN [JS].[Name] = 'Cancelled' THEN [J].[ID] END) * 100.0 / COUNT(DISTINCT [J].[ID]) AS DECIMAL(18,1)),'%') AS [CancelledJobs]
						,CONCAT(CAST(COUNT(DISTINCT CASE WHEN [JS].[Name] = 'Done' THEN [J].[ID] END) * 100.0 / COUNT(DISTINCT [J].[ID]) AS DECIMAL(18,1)),'%') AS [CompleteJobs]
						,CONCAT(CAST(COUNT(DISTINCT CASE WHEN [DDJS].[Name] NOT IN ('Done','Cancelled') AND CAST([DDS].[DueDate] AS DATE) < CAST(GETDATE() AS DATE) THEN [J].[ID] END) * 100.0 / COUNT(DISTINCT [J].[ID]) AS DECIMAL(18,1)),'%') AS [OverdueJobs]
				FROM	[RequestLatest].[Request]
						  AS [R]
						LEFT JOIN
						[RequestLatest].[Job]
						  AS [J]
						  ON [R].[ID] = [J].[RequestID]
						LEFT JOIN
						[Lookup].[JobStatus]
						  AS [JS]
						  ON [J].[JobStatusID] = [JS].[ID]
						LEFT JOIN
						(
						  SELECT	[J].[ID] AS [JobID]
									,[RJS].[JobStatusID]
									,ISNULL(DATEADD(MI,[S].[ShiftLength] + 1,[S].[StartDate]),[J].[DueDate]) AS [DueDate]
									,ROW_NUMBER() OVER (PARTITION BY [J].[ID] ORDER BY [RJS].[DateCreated] DESC) AS [RowNum]
							FROM	[RequestLatest].[Job]
									  AS [J]
									LEFT JOIN
									[RequestLatest].[Shift]
									  AS [S]
									  ON [J].[RequestID] = [S].[RequestID]
									LEFT JOIN
									[RequestLatest].[RequestJobStatus]
									  AS [RJS]
									  ON [J].[ID] = [RJS].[JobID]
										   AND CAST([RJS].[DateCreated] AS DATE) <= CAST(ISNULL(DATEADD(MI,[S].[ShiftLength] + 1,[S].[StartDate]),[J].[DueDate]) AS DATE)
						)
						  AS [DDS]
						  ON [J].[ID] = [DDS].[JobID]
							   AND [DDS].[RowNum] = 1
						LEFT JOIN
						[Lookup].[JobStatus]
						  AS [DDJS]
						  ON [DDS].[JobStatusID] = [DDJS].[ID]
				WHERE	CAST([R].[DateRequested] AS DATE) BETWEEN @BaseDate AND @EndDate
				GROUP BY [R].[ReferringGroupID]
			)
			  AS [R]
			  ON [G].[ID] = [R].[ReferringGroupID]
			LEFT JOIN
			(
			  SELECT	[G].[ID]
						,(SELECT	' ' + CONCAT([A].[Name],' (',[A].[Count],')')
							FROM	(
									  SELECT	[R].[ReferringGroupID]
												,[SA].[Name]
												,COUNT(DISTINCT [J].[ID]) AS [Count]
												,ROW_NUMBER() OVER (PARTITION BY [R].[ReferringGroupID] ORDER BY COUNT(DISTINCT [J].[ID]) DESC) AS [RowNum]
										FROM	[RequestLatest].[Job]
												  AS [J]
												LEFT JOIN
												[RequestLatest].[Request]
												  AS [R]
												  ON [J].[RequestID] = [R].[ID]
												LEFT JOIN
												[Lookup].[SupportActivity]
												  AS [SA]
												  ON [J].[SupportActivityID] = [SA].[ID]
										WHERE	CAST([R].[DateRequested] AS DATE) BETWEEN @BaseDate AND @EndDate
										GROUP BY [R].[ReferringGroupID]
												,[SA].[Name]
									)
									  AS [A]
							WHERE	[A].[ReferringGroupID] = [G].[ID]
									  AND [A].[RowNum] <= 3
							FOR XML PATH('')) [TopActivities]
					FROM	[GroupLatest].[Group]
							  AS [G]
					GROUP BY [G].[ID]
			)
			  AS [A]
			  ON [G].[ID] = [A].[ID]
	WHERE	CAST([DateFrom].[DateFrom] AS DATE) <= @EndDate
	ORDER BY ISNULL([PG].[GroupName],[G].[GroupName])
			,[SubGroup]


  /* Insert 'since launch' stats */
  INSERT INTO [#MonthlyStats]
  SELECT	[G].[ID] AS [GroupID]
			,GETDATE()
			,'Since Launch' AS [TimePeriod]
			,ISNULL([PG].[GroupName],[G].[GroupName]) AS [Group]
			,CASE	WHEN [G].[ParentGroupID] IS NOT NULL THEN [G].[GroupName]
					END AS [Subgroup]
			,[U].[Members]
			,[U].[Admins]
			,[U].[ActiveVols]
			,[U].[NonMemberVols]
			,[U].[Yoti]
			,[C].[Other]
			,[R].[Requests]
			,[R].[Jobs]
			,[R].[CancelledJobs]
			,[R].[CompleteJobs]
			,[R].[OverdueJobs]
			,[A].[TopActivities]
	FROM	[GroupLatest].[Group]
			  AS [G]
			LEFT JOIN
			[GroupLatest].[Group]
			  AS [PG]
			  ON [G].[ParentGroupID] = [PG].[ID]
			LEFT JOIN
			(
			  SELECT	ISNULL([UR].[GroupID],[V].[ReferringGroupID]) AS [GroupID]
						,COUNT(DISTINCT CASE	WHEN [R].[Name] = 'Member' THEN [UR].[UserID]
												END) AS [Members]
						,COUNT(DISTINCT CASE	WHEN [R].[Name] IN ('RequestSubmitter') OR [R].[Name] LIKE '%Admin%' THEN [UR].[UserID]
												END) AS [Admins]
						,COUNT(DISTINCT CASE	WHEN [R].[Name] = 'Member' THEN [V].[VolunteerUserID]
												END) AS [ActiveVols]
						,COUNT(DISTINCT CASE	WHEN [R].[Name] IS NULL THEN [V].[VolunteerUserID]
												END) AS [NonMemberVols]
						,COUNT(DISTINCT CASE	WHEN [R].[Name] = 'Member' AND [Y].[UserID] IS NOT NULL THEN CONCAT([UR].[UserID],[Y].[DateAdded])
												END) AS [Yoti]
				FROM	[GroupLatest].[UserRole]
						  AS [UR]
						LEFT JOIN
						[Lookup].[Role]
						  AS [R]
						  ON [UR].[RoleID] = [R].[ID]
						LEFT JOIN
						(
						  SELECT	[UserID]
									,[DateAdded]
							FROM	[GroupLatest].[UserCredential]
							WHERE	[CredentialID] = (SELECT [ID] FROM [GroupLatest].[Credential] WHERE [Name] = 'IdentityVerifiedByYoti')
						)
						  AS [Y]
						  ON [UR].[UserID] = [Y].[UserID]
						FULL OUTER JOIN
						(
						  SELECT	DISTINCT [R].[ReferringGroupID]
									,[RJS].[VolunteerUserID]
							FROM	[RequestLatest].[Request]
									  AS [R]
									LEFT JOIN
									[RequestLatest].[Job]
									  AS [J]
									  ON [R].[ID] = [J].[RequestID]
									LEFT JOIN
									[RequestLatest].[RequestJobStatus]
									  AS [RJS]
									  ON [J].[ID] = [RJS].[JobID]
						)
						  AS [V]
						  ON [UR].[UserID] = [V].[VolunteerUserID]
							   AND [V].[ReferringGroupID] = [UR].[GroupID]
				GROUP BY ISNULL([UR].[GroupID],[V].[ReferringGroupID])
			)
			  AS [U]
			  ON [G].[ID] = [U].[GroupID]
			LEFT JOIN
			(
			  SELECT	[GroupID]
						,SUM(CASE WHEN [C].[Name] <> 'IdentityVerifiedByYoti' THEN 1 END) AS [Other]
				FROM	[GroupLatest].[UserCredential]
						  AS [UC]
						LEFT JOIN
						[GroupLatest].[Credential]
						  AS [C]
						  ON [UC].[CredentialID] = [C].[ID]
				GROUP BY [GroupID]
			)
			  AS [C]
			  ON [G].[ID] = [C].[GroupID]
			LEFT JOIN
			(
			  SELECT	[R].[ReferringGroupID]
						,COUNT(DISTINCT [R].[ID]) AS [Requests]
						,COUNT(DISTINCT [J].[ID]) AS [Jobs]
						,CONCAT(CAST(COUNT(DISTINCT CASE WHEN [JS].[Name] = 'Cancelled' THEN [J].[ID] END) * 100.0 / COUNT(DISTINCT [J].[ID]) AS DECIMAL(18,1)),'%') AS [CancelledJobs]
						,CONCAT(CAST(COUNT(DISTINCT CASE WHEN [JS].[Name] = 'Done' THEN [J].[ID] END) * 100.0 / COUNT(DISTINCT [J].[ID]) AS DECIMAL(18,1)),'%') AS [CompleteJobs]
						,CONCAT(CAST(COUNT(DISTINCT CASE WHEN [DDJS].[Name] NOT IN ('Done','Cancelled') AND CAST([DDS].[DueDate] AS DATE) < CAST(GETDATE() AS DATE) THEN [J].[ID] END) * 100.0 / COUNT(DISTINCT [J].[ID]) AS DECIMAL(18,1)),'%') AS [OverdueJobs]
				FROM	[RequestLatest].[Request]
						  AS [R]
						LEFT JOIN
						[RequestLatest].[Job]
						  AS [J]
						  ON [R].[ID] = [J].[RequestID]
						LEFT JOIN
						[Lookup].[JobStatus]
						  AS [JS]
						  ON [J].[JobStatusID] = [JS].[ID]
						LEFT JOIN
						(
						  SELECT	[J].[ID] AS [JobID]
									,[RJS].[JobStatusID]
									,ISNULL(DATEADD(MI,[S].[ShiftLength] + 1,[S].[StartDate]),[J].[DueDate]) AS [DueDate]
									,ROW_NUMBER() OVER (PARTITION BY [J].[ID] ORDER BY [RJS].[DateCreated] DESC) AS [RowNum]
							FROM	[RequestLatest].[Job]
									  AS [J]
									LEFT JOIN
									[RequestLatest].[Shift]
									  AS [S]
									  ON [J].[RequestID] = [S].[RequestID]
									LEFT JOIN
									[RequestLatest].[RequestJobStatus]
									  AS [RJS]
									  ON [J].[ID] = [RJS].[JobID]
										   AND CAST([RJS].[DateCreated] AS DATE) <= CAST(ISNULL(DATEADD(MI,[S].[ShiftLength] + 1,[S].[StartDate]),[J].[DueDate]) AS DATE)
						)
						  AS [DDS]
						  ON [J].[ID] = [DDS].[JobID]
							   AND [DDS].[RowNum] = 1
						LEFT JOIN
						[Lookup].[JobStatus]
						  AS [DDJS]
						  ON [DDS].[JobStatusID] = [DDJS].[ID]
				GROUP BY [R].[ReferringGroupID]
			)
			  AS [R]
			  ON [G].[ID] = [R].[ReferringGroupID]
			LEFT JOIN
			(
			  SELECT	[G].[ID]
						,(SELECT	' ' + CONCAT([A].[Name],' (',[A].[Count],')')
							FROM	(
									  SELECT	[R].[ReferringGroupID]
												,[SA].[Name]
												,COUNT(DISTINCT [J].[ID]) AS [Count]
												,ROW_NUMBER() OVER (PARTITION BY [R].[ReferringGroupID] ORDER BY COUNT(DISTINCT [J].[ID]) DESC) AS [RowNum]
										FROM	[RequestLatest].[Job]
												  AS [J]
												LEFT JOIN
												[RequestLatest].[Request]
												  AS [R]
												  ON [J].[RequestID] = [R].[ID]
												LEFT JOIN
												[Lookup].[SupportActivity]
												  AS [SA]
												  ON [J].[SupportActivityID] = [SA].[ID]
										GROUP BY [R].[ReferringGroupID]
												,[SA].[Name]
									)
									  AS [A]
							WHERE	[A].[ReferringGroupID] = [G].[ID]
									  AND [A].[RowNum] <= 3
							FOR XML PATH('')) [TopActivities]
					FROM	[GroupLatest].[Group]
							  AS [G]
					GROUP BY [G].[ID]
			)
			  AS [A]
			  ON [G].[ID] = [A].[ID]
	ORDER BY ISNULL([PG].[GroupName],[G].[GroupName])
			,[SubGroup]

  /* Delete rows */
  DELETE	[PERM]
	FROM	[Monitoring].[MonthlyStats]
			  AS [PERM]
			LEFT JOIN
			[#MonthlyStats]
			  AS [TEMP]
			  ON [PERM].[GroupID] = [TEMP].[GroupID]
				   AND REPLACE([PERM].[TimePeriod],' (to date)','') = REPLACE([TEMP].[TimePeriod],' (to date)','')
	WHERE	[TEMP].[GroupID] IS NOT NULL

  INSERT INTO [Monitoring].[MonthlyStats]
  SELECT	*
	FROM	[#MonthlyStats]

            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP PROCEDURE [Monitoring].[SP_MonthlyStats]
            ");
        }
    }
}
