using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportingService.Repo.Migrations
{
    public partial class CreateSP_Monitoring_SP_ExpectedRequestUpdateEmails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE [Monitoring].[SP_ExpectedRequestUpdateEmails]
	@Trigger VARCHAR(100)
	,@Activity VARCHAR(100)
	,@RunID INT

  AS 

  DECLARE	@RowsAffected INT
			,@LastRunTimestamp DATETIME
			,@ProcessedTo DATETIME
			,@TemplateName VARCHAR(100) = 'TaskUpdateSimplified'

  SELECT	@LastRunTimestamp = [ProcessedTo]
	FROM	[Monitoring].[MonitoringTimestamps]
	WHERE	[Activity] = @Activity
			  AND LEFT([Trigger],LEN(@Trigger)) = @Trigger 
			  AND [Start] = 0
			  AND [RunID] = @RunID - 1
			  
  SELECT	@LastRunTimestamp = ISNULL(@LastRunTimestamp,[DateLastModified])
	FROM	[Analysis].[EmailTemplates]
	WHERE	[TemplateName] = @TemplateName

  SELECT	@ProcessedTo = CASE	WHEN GETDATE() > DATEADD(MM,1,@LastRunTimestamp) THEN DATEADD(MM,1,@LastRunTimestamp)
								ELSE GETDATE() 
								END

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,CONCAT(@Trigger,' - current volunteer'),1,GETDATE(),NULL,NULL)

  IF OBJECT_ID('tempdb..[#Expected]') IS NOT NULL
    DROP TABLE [#Expected]

  CREATE TABLE [#Expected]
	( [UserID] INT
	  ,[DateCreated] DATETIME
	  ,[GroupID] INT
	  ,[JobID] INT
	  ,[RequestID] INT
	  ,[Details] VARCHAR(100) )

  INSERT INTO [#Expected]
	( [UserID]
	  ,[DateCreated]
	  ,[GroupID]
	  ,[JobID]
	  ,[RequestID]
	  ,[Details] )
  SELECT	[1].[VolunteerUserID] 
			,[1].[DateCreated]
			,[R].[ReferringGroupID]
			,[1].[JobID]
			,[J].[RequestID]
			,'Volunteer notification' AS [Details]
	FROM	(
			  SELECT	*
						,ROW_NUMBER() OVER (PARTITION BY [JobID] ORDER BY [DateCreated]) AS [RowNum]
				FROM	[RequestLatest].[RequestJobStatus]
				WHERE	[JobID] IN (SELECT DISTINCT [JobID] FROM [RequestLatest].[RequestJobStatus] WHERE [DateCreated] BETWEEN @LastRunTimestamp AND @ProcessedTo)
			)
				AS [1]
			LEFT JOIN
			(
			  SELECT	*
						,ROW_NUMBER() OVER (PARTITION BY [JobID] ORDER BY [DateCreated]) AS [RowNum]
				FROM	[RequestLatest].[RequestJobStatus]
				WHERE	[JobID] IN (SELECT DISTINCT [JobID] FROM [RequestLatest].[RequestJobStatus] WHERE [DateCreated] BETWEEN @LastRunTimestamp AND @ProcessedTo)
			)
				AS [2]
				ON [1].[JobID] = [2].[JobID]
					AND [1].[RowNum] = ([2].[RowNum] + 1)
			LEFT JOIN
			[RequestLatest].[Job]
				AS [J]
				ON [1].[JobID] = [J].[ID]
			LEFT JOIN
			[RequestLatest].[Request]
				AS [R]
				ON [J].[RequestID] = [R].[ID]
	WHERE	[1].[DateCreated] BETWEEN @LastRunTimestamp AND @ProcessedTo
				AND [1].[JobStatusID] <> [2].[JobStatusID] --- Only generate notifications if status has changed
				AND [1].[CreatedByUserID] <> -1 --- No notification for auto-updates
				AND [1].[VolunteerUserID] <> [1].[CreatedByUserID] --- Notify new volunteer if it wasn't their action

  DELETE	[NEW]
	FROM	[#Expected]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [EXISTING].[TemplateName] = @TemplateName
				   AND [NEW].[DateCreated] = [EXISTING].[TimestampExpected]
				   AND [NEW].[JobID] = [EXISTING].[JobID]
	WHERE	[EXISTING].[RecipientUserID] IS NOT NULL

  SELECT	@RowsAffected = COUNT(1)
	FROM	[#Expected]

  INSERT INTO [Monitoring].[ExpectedEmails]
	( [RecipientUserID]
	  ,[TemplateName]
	  ,[TimestampExpected]
	  ,[GroupID]
	  ,[JobID]
	  ,[RequestID]
	  ,[Details] )
  SELECT	[NEW].[UserID]
			,@TemplateName
			,[NEW].[DateCreated]
			,[NEW].[GroupID]
			,[NEW].[JobID]
			,[NEW].[RequestID]
			,[NEW].[Details]
	FROM	[#Expected]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [EXISTING].[TemplateName] = @TemplateName
				   AND [NEW].[DateCreated] = [EXISTING].[TimestampExpected]
				   AND [NEW].[JobID] = [EXISTING].[JobID]
	WHERE	[EXISTING].[RecipientUserID] IS NULL

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,CONCAT(@Trigger,' - current volunteer'),0,GETDATE(),@RowsAffected,@ProcessedTo)

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,CONCAT(@Trigger,' - new volunteer'),1,GETDATE(),NULL,NULL)

  DELETE FROM [#Expected]

  INSERT INTO [#Expected]
	( [UserID]
	  ,[DateCreated]
	  ,[GroupID]
	  ,[JobID]
	  ,[RequestID]
	  ,[Details] )
  SELECT	[2].[VolunteerUserID]
			,[1].[DateCreated]
			,[R].[ReferringGroupID] AS [GroupID]
			,[1].[JobID]
			,[J].[RequestID]
			,'Volunteer notification' AS [Details]
	FROM	(
				SELECT	*
						,ROW_NUMBER() OVER (PARTITION BY [JobID] ORDER BY [DateCreated]) AS [RowNum]
				FROM	[RequestLatest].[RequestJobStatus]
				WHERE	[JobID] IN (SELECT DISTINCT [JobID] FROM [RequestLatest].[RequestJobStatus] WHERE [DateCreated] BETWEEN @LastRunTimestamp AND @ProcessedTo)
			)
				AS [1]
			LEFT JOIN
			(
				SELECT	*
						,ROW_NUMBER() OVER (PARTITION BY [JobID] ORDER BY [DateCreated]) AS [RowNum]
				FROM	[RequestLatest].[RequestJobStatus]
				WHERE	[JobID] IN (SELECT DISTINCT [JobID] FROM [RequestLatest].[RequestJobStatus] WHERE [DateCreated] BETWEEN @LastRunTimestamp AND @ProcessedTo)
			)
				AS [2]
				ON [1].[JobID] = [2].[JobID]
					AND [1].[RowNum] = ([2].[RowNum] + 1)
			LEFT JOIN
			[RequestLatest].[Job]
				AS [J]
				ON [1].[JobID] = [J].[ID]
			LEFT JOIN
			[RequestLatest].[Request]
				AS [R]
				ON [J].[RequestID] = [R].[ID]
	WHERE	[1].[DateCreated] BETWEEN @LastRunTimestamp AND @ProcessedTo
				AND [1].[JobStatusID] <> [2].[JobStatusID] --- Only generate notifications if status has changed
				AND [1].[CreatedByUserID] <> -1 --- No notification for auto-updates
				AND [2].[VolunteerUserID] <> [1].[CreatedByUserID] --- Notify old volunteer if it wasn't their action

  DELETE	[NEW]
	FROM	[#Expected]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [EXISTING].[TemplateName] = @TemplateName
				   AND [NEW].[DateCreated] = [EXISTING].[TimestampExpected]
				   AND [NEW].[JobID] = [EXISTING].[JobID]
	WHERE	[EXISTING].[RecipientUserID] IS NOT NULL

  SELECT	@RowsAffected = COUNT(1)
	FROM	[#Expected]

  INSERT INTO [Monitoring].[ExpectedEmails]
	( [RecipientUserID]
	  ,[TemplateName]
	  ,[TimestampExpected]
	  ,[GroupID]
	  ,[JobID]
	  ,[RequestID]
	  ,[Details] )
  SELECT	[NEW].[UserID]
			,@TemplateName
			,[NEW].[DateCreated]
			,[NEW].[GroupID]
			,[NEW].[JobID]
			,[NEW].[RequestID]
			,[NEW].[Details]
	FROM	[#Expected]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [EXISTING].[TemplateName] = @TemplateName
				   AND [NEW].[DateCreated] = [EXISTING].[TimestampExpected]
				   AND [NEW].[JobID] = [EXISTING].[JobID]
	WHERE	[EXISTING].[RecipientUserID] IS NULL

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,CONCAT(@Trigger,' - new volunteer'),0,GETDATE(),@RowsAffected,@ProcessedTo)

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,CONCAT(@Trigger,' - requester'),1,GETDATE(),NULL,NULL)

  DELETE FROM [#Expected]

  INSERT INTO [#Expected]
	( [UserID]
	  ,[DateCreated]
	  ,[GroupID]
	  ,[JobID]
	  ,[RequestID]
	  ,[Details] )
  SELECT	-1 AS [UserID]
			,[1].[DateCreated]
			,[R].[ReferringGroupID] AS [GroupID]
			,[1].[JobID]
			,[J].[RequestID]
			,'Requester notification' AS [Details]
	FROM	(
				SELECT	*
						,ROW_NUMBER() OVER (PARTITION BY [JobID] ORDER BY [DateCreated]) AS [RowNum]
				FROM	[RequestLatest].[RequestJobStatus]
				WHERE	[JobID] IN (SELECT DISTINCT [JobID] FROM [RequestLatest].[RequestJobStatus] WHERE [DateCreated] BETWEEN @LastRunTimestamp AND @ProcessedTo)
			)
				AS [1]
			LEFT JOIN
			(
				SELECT	*
						,ROW_NUMBER() OVER (PARTITION BY [JobID] ORDER BY [DateCreated]) AS [RowNum]
				FROM	[RequestLatest].[RequestJobStatus]
				WHERE	[JobID] IN (SELECT DISTINCT [JobID] FROM [RequestLatest].[RequestJobStatus] WHERE [DateCreated] BETWEEN @LastRunTimestamp AND @ProcessedTo)
			)
				AS [2]
				ON [1].[JobID] = [2].[JobID]
					AND [1].[RowNum] = ([2].[RowNum] + 1)
			LEFT JOIN
			[RequestLatest].[Job]
				AS [J]
				ON [1].[JobID] = [J].[ID]
			LEFT JOIN
			[RequestLatest].[Request]
				AS [R]
				ON [J].[RequestID] = [R].[ID]
	WHERE	[1].[DateCreated] BETWEEN @LastRunTimestamp AND @ProcessedTo
				AND [1].[JobStatusID] <> [2].[JobStatusID] --- Only generate notifications if status has changed
				AND [1].[CreatedByUserID] <> -1 --- No notification for auto-updates

  DELETE	[NEW]
	FROM	[#Expected]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [EXISTING].[TemplateName] = @TemplateName
				   AND [NEW].[DateCreated] = [EXISTING].[TimestampExpected]
				   AND [NEW].[JobID] = [EXISTING].[JobID]
	WHERE	[EXISTING].[RecipientUserID] IS NOT NULL

  SELECT	@RowsAffected = COUNT(1)
	FROM	[#Expected]

  INSERT INTO [Monitoring].[ExpectedEmails]
	( [RecipientUserID]
	  ,[TemplateName]
	  ,[TimestampExpected]
	  ,[GroupID]
	  ,[JobID]
	  ,[RequestID]
	  ,[Details] )
  SELECT	[NEW].[UserID]
			,@TemplateName
			,[NEW].[DateCreated]
			,[NEW].[GroupID]
			,[NEW].[JobID]
			,[NEW].[RequestID]
			,[NEW].[Details]
	FROM	[#Expected]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [EXISTING].[TemplateName] = @TemplateName
				   AND [NEW].[DateCreated] = [EXISTING].[TimestampExpected]
				   AND [NEW].[JobID] = [EXISTING].[JobID]
	WHERE	[EXISTING].[RecipientUserID] IS NULL

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,CONCAT(@Trigger,' - requester'),0,GETDATE(),@RowsAffected,@ProcessedTo)

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,CONCAT(@Trigger,' - recipient'),1,GETDATE(),NULL,NULL)

  DELETE FROM [#Expected]

  INSERT INTO [#Expected]
	( [UserID]
	  ,[DateCreated]
	  ,[GroupID]
	  ,[JobID]
	  ,[RequestID]
	  ,[Details] )
  SELECT	-1
			,[1].[DateCreated]
			,[R].[ReferringGroupID]
			,[1].[JobID]
			,[J].[RequestID]
			,'Recipient notification' AS [Details]
	FROM	(
				SELECT	*
						,ROW_NUMBER() OVER (PARTITION BY [JobID] ORDER BY [DateCreated]) AS [RowNum]
				FROM	[RequestLatest].[RequestJobStatus]
				WHERE	[JobID] IN (SELECT DISTINCT [JobID] FROM [RequestLatest].[RequestJobStatus] WHERE [DateCreated] >= DATEADD(DD,-7,CAST(GETDATE() AS DATE)))
			)
				AS [1]
			LEFT JOIN
			(
				SELECT	*
						,ROW_NUMBER() OVER (PARTITION BY [JobID] ORDER BY [DateCreated]) AS [RowNum]
				FROM	[RequestLatest].[RequestJobStatus]
				WHERE	[JobID] IN (SELECT DISTINCT [JobID] FROM [RequestLatest].[RequestJobStatus] WHERE [DateCreated] >= DATEADD(DD,-7,CAST(GETDATE() AS DATE)))
			)
				AS [2]
				ON [1].[JobID] = [2].[JobID]
					AND [1].[RowNum] = ([2].[RowNum] + 1)
			LEFT JOIN
			[RequestLatest].[Job]
				AS [J]
				ON [1].[JobID] = [J].[ID]
			LEFT JOIN
			[RequestLatest].[Request]
				AS [R]
				ON [J].[RequestID] = [R].[ID]
	WHERE	[1].[DateCreated] BETWEEN @LastRunTimestamp AND @ProcessedTo
				AND [1].[JobStatusID] <> [2].[JobStatusID] --- Only generate notifications if status has changed
				AND [1].[CreatedByUserID] <> -1 --- No notification for auto-updates
				AND [R].[RequestorType] <> 2 --- No separate recipient notification if the requester requires the help themselves

  DELETE	[NEW]
	FROM	[#Expected]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [EXISTING].[TemplateName] = @TemplateName
				   AND [NEW].[DateCreated] = [EXISTING].[TimestampExpected]
				   AND [NEW].[JobID] = [EXISTING].[JobID]
	WHERE	[EXISTING].[RecipientUserID] IS NOT NULL

  SELECT	@RowsAffected = COUNT(1)
	FROM	[#Expected]

  INSERT INTO [Monitoring].[ExpectedEmails]
	( [RecipientUserID]
	  ,[TemplateName]
	  ,[TimestampExpected]
	  ,[GroupID]
	  ,[JobID]
	  ,[RequestID]
	  ,[Details] )
  SELECT	[NEW].[UserID]
			,@TemplateName
			,[NEW].[DateCreated]
			,[NEW].[GroupID]
			,[NEW].[JobID]
			,[NEW].[RequestID]
			,[NEW].[Details]
	FROM	[#Expected]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [EXISTING].[TemplateName] = @TemplateName
				   AND [NEW].[DateCreated] = [EXISTING].[TimestampExpected]
				   AND [NEW].[JobID] = [EXISTING].[JobID]
	WHERE	[EXISTING].[RecipientUserID] IS NULL

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,CONCAT(@Trigger,' - recipient'),0,GETDATE(),@RowsAffected,@ProcessedTo)

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,CONCAT(@Trigger,' - email expected'),1,GETDATE(),NULL,NULL)

  SELECT	@RowsAffected = COUNT(1)
	FROM	[Monitoring].[ExpectedEmails]
	WHERE	[RecipientUserID] IN (SELECT [RecipientUserID] FROM [Monitoring].[ExpectedEmails] WHERE [TemplateName] = @TemplateName AND [EmailsExpected] IS NULL)

  UPDATE	[EXP]
	SET		[EmailsExpected] = [C].[EmailsExpected]
	FROM	[Monitoring].[ExpectedEmails]
			  AS [EXP]
			LEFT JOIN
			(
			  SELECT	[RecipientUserID]
						,[JobID]
						,CAST([TimestampExpected] AS DATE) AS [Date]
						,COUNT(1) AS [EmailsExpected]
				FROM	[Monitoring].[ExpectedEmails]
				WHERE	[TemplateName] = @TemplateName
						  AND [RecipientUserID] IN (SELECT [RecipientUserID] FROM [Monitoring].[ExpectedEmails] WHERE [TemplateName] = @TemplateName AND [EmailsExpected] IS NULL)
				GROUP BY [RecipientUserID]
						,[JobID]
						,CAST([TimestampExpected] AS DATE)
			)
			  AS [C]
			  ON [EXP].[RecipientUserID] = [C].[RecipientUserID]
				   AND [EXP].[JobID] = [C].[JobID]
				   AND [EXP].[TemplateName] = @TemplateName
				   AND CAST([EXP].[TimestampExpected] AS DATE) = [C].[Date]
	WHERE	[C].[EmailsExpected] IS NOT NULL

	  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,CONCAT(@Trigger,' - email expected'),0,GETDATE(),@RowsAffected,@ProcessedTo)




            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP PROCEDURE [Monitoring].[SP_ExpectedRequestUpdateEmails]
            ");
        }
    }
}
