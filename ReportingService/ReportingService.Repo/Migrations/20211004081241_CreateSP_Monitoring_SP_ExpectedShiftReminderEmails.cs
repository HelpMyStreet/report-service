using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportingService.Repo.Migrations
{
    public partial class CreateSP_Monitoring_SP_ExpectedShiftReminderEmails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE [Monitoring].[SP_ExpectedShiftNotificationEmails]
	@Trigger VARCHAR(100)
	,@Activity VARCHAR(100)
	,@RunID INT

  AS 

  DECLARE	@RowsAffected INT
			,@LastRunTimestamp DATETIME
			,@ProcessedTo DATETIME
			,@TemplateName VARCHAR(100) = 'RequestNotification'

  SELECT	@LastRunTimestamp = MIN([ProcessedTo])
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
	VALUES (@Activity,@RunID,CONCAT(@Trigger,' - existing volunteers'),1,GETDATE(),NULL,NULL)

  IF OBJECT_ID('tempdb..[#Expected]') IS NOT NULL
    DROP TABLE [#Expected]

  CREATE TABLE [#Expected]
	( [UserID] INT
	  ,[DateDue] DATETIME
	  ,[Details] VARCHAR(100)
	  --,[Unsubscribed] BIT
	  ,[Order] INT )

  INSERT INTO [#Expected]
	( [UserID]
	  ,[DateDue]
	  ,[Details]
	  --,[Unsubscribed]
	  ,[Order] )
  SELECT	[FN].[UserID]
			,[DateDue]
			,CONCAT(COUNT(DISTINCT [RequestID]),' shift(s)') AS [Details]
			--,[FN].[Unsubscribed]
			,[FN].[Order]
	FROM	(
				SELECT	[R].[ID] AS [RequestID]
						,[J].[ID] AS [JobID]
						,DATEADD(HH,DATEDIFF(HH, 0, [R].[DateRequested]) + 1, 0) AS [DateDue]
						,[R].[ReferringGroupID]
				FROM	(
							SELECT	*
									,ROW_NUMBER() OVER (PARTITION BY [ID] ORDER BY [DateFrom] DESC) AS [RowNum]
							FROM	[RequestLatest].[Request]
							WHERE	[ID] IN (SELECT [RequestID] FROM [RequestLatest].[Job] WHERE CAST([DueDate] AS DATE) BETWEEN @LastRunTimestamp AND @ProcessedTo)
						)
							AS [R]
						LEFT JOIN
						[LookupLatest].[RequestType]
							AS [RT]
							ON [R].[RequestType] = [RT].[ID]
						LEFT JOIN
						[RequestLatest].[Job]
							AS [J]
							ON [R].[ID] = [J].[RequestID]
				WHERE	CAST([DateRequested] AS DATE) BETWEEN @LastRunTimestamp AND @ProcessedTo
							AND [RT].[Name] = 'Shift'
			)
				AS [A]
			CROSS APPLY
			[Analysis].[FN_GetUsersForNotification]
			([A].[JobID],[A].[DateDue],@TemplateName)
				AS [FN]		  
	GROUP BY [FN].[UserID]
			,[DateDue]  
			--,[FN].[Unsubscribed]
			,[FN].[Order]

  DELETE	[NEW]
	FROM	[#Expected]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [EXISTING].[TemplateName] = @TemplateName
				   AND [NEW].[DateDue] = [EXISTING].[TimestampExpected]
	WHERE	[EXISTING].[RecipientUserID] IS NOT NULL

  SELECT	@RowsAffected = COUNT(1)
	FROM	[#Expected]

  INSERT INTO [Monitoring].[ExpectedEmails]
	( [RecipientUserID]
	  ,[TemplateName]
	  ,[TimestampExpected]
	  ,[Details]
	  ,[EmailsExpected]
	  --,[Unsubscribed]
	  ,[RecipientOrder] )
  SELECT	[NEW].[UserID]
			,@TemplateName
			,[NEW].[DateDue]
			,[NEW].[Details]
			,1
			--,[NEW].[Unsubscribed]
			,[NEW].[Order]
	FROM	[#Expected]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [EXISTING].[TemplateName] = @TemplateName
				   AND [NEW].[DateDue] = [EXISTING].[TimestampExpected]
	WHERE	[EXISTING].[RecipientUserID] IS NULL

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,CONCAT(@Trigger,' - existing volunteers'),0,GETDATE(),@RowsAffected,@ProcessedTo)

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,CONCAT(@Trigger,' - new volunteers'),1,GETDATE(),NULL,NULL)

  DELETE FROM [#Expected]

  INSERT INTO [#Expected]
	( [UserID]
	  ,[DateDue]
	  ,[Details]
	  --,[Unsubscribed]
	  ,[Order] )
  SELECT	[FN].[UserID]
			,[DateDue]
			,CONCAT(COUNT(DISTINCT [RequestID]),' shift(s)') AS [Details]
			--,[FN].[Unsubscribed]
			,[FN].[Order]
	FROM	(
				SELECT	[U].[ID] AS [UserID]
						,[J].[ID] AS [JobID]
						,[R].[ID] AS [RequestID]
						,[U].[DateCreated]
						,[R].[DateRequested]
						,[JS].[Name] AS [JobStatus]
						,DATEADD(HH,DATEDIFF(HH, 0, [U].[DateCreated]) + 1, 0) AS [DateDue]
						,ROW_NUMBER() OVER (PARTITION BY [U].[ID],[J].[ID] ORDER BY [RJS].[DateCreated] DESC) AS [RowNum]
				FROM	[UserLatest].[User]
							AS [U]
						LEFT JOIN
						(
							SELECT	*
									,ROW_NUMBER() OVER (PARTITION BY [ID] ORDER BY [DateFrom] DESC) AS [RowNum]
							FROM	[RequestLatest].[Request]
						)
							AS [R]
							ON [U].[DateCreated] > DATEADD(HH,DATEDIFF(HH, 0, [R].[DateRequested]) + 1, 0)
								AND [R].[RowNum] = 1
						LEFT JOIN
						[LookupLatest].[RequestType]
							AS [RT]
							ON [R].[RequestType] = [RT].[ID]
						LEFT JOIN
						[RequestLatest].[Job]
							AS [J]
							ON [R].[ID] = [J].[RequestID]
						LEFT JOIN
						[RequestLatest].[RequestJobStatus]
							AS [RJS]
							ON [J].[ID] = [RJS].[JobID]
								AND [RJS].[DateCreated] <= DATEADD(HH,DATEDIFF(HH, 0, [U].[DateCreated]) + 1, 0)
						LEFT JOIN
						[LookupLatest].[JobStatus]
							AS [JS]
							ON [RJS].[JobStatusID] = [JS].[ID]
				WHERE	CAST([U].[DateCreated] AS DATE) BETWEEN @LastRunTimestamp AND @ProcessedTo
							AND [RT].[Name] = 'Shift'
			)
			  AS [A]
			CROSS APPLY
			[Analysis].[FN_GetDropOutReason]
			([A].[JobID],[A].[DateDue],'RequestNotification',[A].[UserID])
			  AS [FN]		
	WHERE	[RowNum] = 1
			  AND [JobStatus] = 'Open'
			  AND ISNULL([FN].[Dropout],0) = 0
	GROUP BY [FN].[UserID]
			,[DateDue]
			--,[FN].[Unsubscribed]
			,[FN].[Order]

  DELETE	[NEW]
	FROM	[#Expected]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [EXISTING].[TemplateName] = @TemplateName
				   AND [NEW].[DateDue] = [EXISTING].[TimestampExpected]
	WHERE	[EXISTING].[RecipientUserID] IS NOT NULL

  SELECT	@RowsAffected = COUNT(1)
	FROM	[#Expected]

  INSERT INTO [Monitoring].[ExpectedEmails]
	( [RecipientUserID]
	  ,[TemplateName]
	  ,[TimestampExpected]
	  ,[Details]
	  ,[EmailsExpected]
	--  ,[Unsubscribed]
	  ,[RecipientOrder] )
  SELECT	[NEW].[UserID]
			,@TemplateName
			,[NEW].[DateDue]
			,[NEW].[Details]
			,1
		--	,[NEW].[Unsubscribed]
			,[NEW].[Order]
	FROM	[#Expected]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [EXISTING].[TemplateName] = @TemplateName
				   AND [NEW].[DateDue] = [EXISTING].[TimestampExpected]
	WHERE	[EXISTING].[RecipientUserID] IS NULL

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,CONCAT(@Trigger,' - new volunteers'),0,GETDATE(),@RowsAffected,@ProcessedTo)
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP PROCEDURE [Monitoring].[SP_ExpectedShiftNotificationEmails]
            ");
        }
    }
}
