using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportingService.Repo.Migrations
{
    public partial class CreateSP_Monitoring_SP_ExpectedTaskReminderEmails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE [Monitoring].[SP_ExpectedTaskReminderEmails]
	@Trigger VARCHAR(100)
	,@Activity VARCHAR(100)
	,@RunID INT

  AS 

  DECLARE	@RowsAffected INT
			,@LastRunTimestamp DATETIME
			,@ProcessedTo DATETIME
			,@TemplateName VARCHAR(100) = 'TaskReminder'

  SELECT	@LastRunTimestamp = [ProcessedTo]
	FROM	[Monitoring].[MonitoringTimestamps]
	WHERE	[Activity] = @Activity
			  AND [Trigger] = @Trigger
			  AND [Start] = 0
			  AND [RunID] = @RunID - 1
			  
  SELECT	@LastRunTimestamp = ISNULL(@LastRunTimestamp,[DateLastModified])
	FROM	[Analysis].[EmailTemplates]
	WHERE	[TemplateName] = @TemplateName

  SELECT	@ProcessedTo = CASE	WHEN GETDATE() > DATEADD(MM,1,@LastRunTimestamp) THEN DATEADD(MM,1,@LastRunTimestamp)
								ELSE GETDATE() 
								END
  
  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,@Trigger,1,GETDATE(),NULL,NULL)

  IF OBJECT_ID('tempdb..[#Expected]') IS NOT NULL
    DROP TABLE [#Expected]

  CREATE TABLE [#Expected]
	( [UserID] INT
	  ,[ReminderDue] DATETIME
	  ,[Details] VARCHAR(100)
	  ,[GroupID] INT
	  ,[JobID] INT
	  ,[RequestID] INT )

  INSERT INTO [#Expected]
	( [UserID]
	  ,[ReminderDue]
	  ,[Details]
	  ,[GroupID]
	  ,[JobID]
	  ,[RequestID] )
  SELECT	[VolunteerUserID]
			,[ReminderDue]
			,CONCAT([ReminderInterval],' day(s) before due date')
			,[ReferringGroupID]
			,[JobID]
			,[RequestID]
	FROM	(
			  /* Join onto status updates and find the most recent */
			  SELECT	[J].[JobID]
						,[J].[RequestID]
						,[J].[ReferringGroupID]
						,[J].[ReminderInterval]
						,[J].[DueDateType]
						,[J].[DueDate]
						,[J].[ReminderDue]
						,[L].[Name] AS [JobStatus]
						,[JS].[DateCreated]
						,[JS].[VolunteerUserID]
						,ROW_NUMBER() OVER (PARTITION BY [J].[JobID],[J].[ReminderInterval] ORDER BY [JS].[DateCreated] DESC) AS [RowNum]
				FROM	(
						  /* Get a list of reminders for tasks added or due since the last run date */
						  SELECT	[J].[ID] AS [JobID]
									,[J].[RequestID]
									,[J].[ReferringGroupID]
									,[I].*
									,[J].[DueDate]
									,DATEADD(HH,6,CAST(CAST(DATEADD(DD,-1 * [I].[ReminderInterval],[J].[DueDate]) AS DATE) AS DATETIME)) AS [ReminderDue]
							FROM	(
									  SELECT	[J].*
												,[R].[RequestType]
												,[R].[ReferringGroupID]
												,ROW_NUMBER() OVER (PARTITION BY [J].[ID] ORDER BY [J].[DateFrom] DESC) AS [RowNum]
										FROM	[Request].[Job]
												  AS [J]
												LEFT JOIN
												[RequestLatest].[Request]
												  AS [R]
												  ON [J].[RequestID] = [R].[ID]
										WHERE	[J].[DueDate] BETWEEN @LastRunTimestamp AND @ProcessedTo
												  OR [R].[DateRequested] BETWEEN @LastRunTimestamp AND @ProcessedTo
									)
									  AS [J]
									LEFT JOIN
									[Lookup].[DueDateType]
										AS [DDT]
										ON [J].[DueDateTypeID] = [DDT].[ID]
									LEFT JOIN
									(
									  /* Create a list of all the reminders which are due */
									  SELECT	1 AS [ReminderInterval]
												,'On' AS [DueDateType]
									  UNION
									  SELECT	0 AS [ReminderInterval]
												,'On' AS [DueDateType]
									  UNION
									  SELECT	7 AS [ReminderInterval]
												,'Before' AS [DueDateType]
									  UNION
									  SELECT	3 AS [ReminderInterval]
												,'Before' AS [DueDateType]
									  UNION
									  SELECT	0 AS [ReminderInterval]
												,'Before' AS [DueDateType]
									)
									  AS [I]
									  ON [DDT].[Name] = [I].[DueDateType]
							WHERE	[J].[RowNum] = 1
									  AND [J].[RequestType] = (SELECT [ID] FROM [Lookup].[RequestType] WHERE [Name] = 'Task')
						)
						  AS [J]
						LEFT JOIN
						[Request].[RequestJobStatus]
						  AS [JS]
						  ON [J].[JobID] = [JS].[JobID]
							   AND [JS].[DateCreated] <= [J].[ReminderDue]
						LEFT JOIN
						[Lookup].[JobStatus]
						  AS [L]
						  ON [JS].[JobStatusID] = [L].[ID]
			)
				AS [JOIN]
	WHERE	[JOIN].[RowNum] = 1
			  AND [JOIN].[JobStatus] NOT IN ('Open','Done','Cancelled')
			  AND NOT ([JOIN].[DueDateType] = 'On' AND [JOIN].[ReminderInterval] = 0 AND [JOIN].[DateCreated] <= DATEADD(DD,-1,[JOIN].[ReminderDue]))

  DELETE	[NEW]
	FROM	[#Expected]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [EXISTING].[TemplateName] = @TemplateName
				   AND [EXISTING].[JobID] = [NEW].[JobID]
				   AND [NEW].[ReminderDue] = [EXISTING].[TimestampExpected]
	WHERE	[EXISTING].[RecipientUserID] IS NOT NULL

  SELECT	@RowsAffected = COUNT(1)
	FROM	[#Expected]

  INSERT INTO [Monitoring].[ExpectedEmails]
	( [RecipientUserID]
	  ,[TemplateName]
	  ,[TimestampExpected]
	  ,[Details]
	  ,[GroupID]
	  ,[RequestID]
	  ,[JobID]
	  ,[EmailsExpected] )
  SELECT	[NEW].[UserID]
			,@TemplateName
			,[NEW].[ReminderDue]
			,[NEW].[Details]
			,[NEW].[GroupID]
			,[NEW].[RequestID]
			,[NEW].[JobID]
			,1
	FROM	[#Expected]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [EXISTING].[TemplateName] = @TemplateName
				   AND [EXISTING].[JobID] = [NEW].[JobID]
				   AND [NEW].[ReminderDue] = [EXISTING].[TimestampExpected]
	WHERE	[EXISTING].[RecipientUserID] IS NULL

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,@Trigger,0,GETDATE(),@RowsAffected,@ProcessedTo)
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP PROCEDURE [Monitoring].[SP_ExpectedTaskReminderEmails]
            ");
        }
    }
}
