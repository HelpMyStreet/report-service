using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportingService.Repo.Migrations
{
    public partial class CreateSP_Monitoring_SP_ExpectedTaskNotificationEmails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
               CREATE PROCEDURE [Monitoring].[SP_ExpectedTaskNotificationEmails]
	@Trigger VARCHAR(100)
	,@Activity VARCHAR(100)
	,@RunID INT

  AS 

  DECLARE	@RowsAffected INT
			,@LastRunTimestamp DATETIME
			,@ProcessedTo DATETIME
			,@TemplateName VARCHAR(100) = 'TaskNotification'

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
	  ,[DateRequested] DATETIME
	  ,[GroupID] INT
	  ,[RequestID] INT
	  ,[Order] INT )

  INSERT INTO [#Expected]
	( [UserID]
	  ,[DateRequested]
	  ,[GroupID]
	  ,[RequestID]
	  ,[Order] )
  SELECT	DISTINCT [FN].[UserID]
			,[DateRequested]
			,[ReferringGroupID]
			,[RequestID] AS [RequestID]
			,[FN].[Order]
	FROM	(
				SELECT	[R].[ID] AS [RequestID]
						,[J].[ID] AS [JobID]
						,[R].[DateRequested]
						,[R].[ReferringGroupID]
				FROM	[RequestLatest].[Request]
							AS [R]
						LEFT JOIN
						[LookupLatest].[RequestType]
							AS [RT]
							ON [R].[RequestType] = [RT].[ID]
						LEFT JOIN
						[RequestLatest].[Job]
							AS [J]
							ON [R].[ID] = [J].[RequestID]
						LEFT JOIN
						(
						  SELECT	DISTINCT [JobID]
							FROM	[RequestLatest].[RequestJobStatus]
							WHERE	[JobStatusID] = (SELECT [ID] FROM [LookupLatest].[JobStatus] WHERE [Name] = 'Open')
						)
						  AS [JS]
						  ON [J].[ID] = [JS].[JobID]
				WHERE	[DateRequested] BETWEEN @LastRunTimestamp AND @ProcessedTo
							AND [RT].[Name] = 'Task'
							AND [JS].[JobID] IS NOT NULL
			)
				AS [A]
			CROSS APPLY
			[Analysis].[FN_GetUsersForNotification]
			([A].[JobID],[A].[DateRequested],@TemplateName)
				AS [FN]		

  DELETE	[NEW]
	FROM	[#Expected]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [EXISTING].[TemplateName] = @TemplateName
				   AND [NEW].[RequestID] = [EXISTING].[RequestID]
	WHERE	[EXISTING].[RecipientUserID] IS NOT NULL

  SELECT	@RowsAffected = COUNT(1)
	FROM	[#Expected]

  INSERT INTO [Monitoring].[ExpectedEmails]
	( [RecipientUserID]
	  ,[TemplateName]
	  ,[TimestampExpected]
	  ,[GroupID]
	  ,[RequestID]
	  ,[EmailsExpected]
	  ,[RecipientOrder] )
  SELECT	[NEW].[UserID]
			,@TemplateName
			,[NEW].[DateRequested]
			,[NEW].[GroupID]
			,[NEW].[RequestID]
			,1
			,[NEW].[Order]
	FROM	[#Expected]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [EXISTING].[TemplateName] = @TemplateName
				   AND [NEW].[RequestID] = [EXISTING].[RequestID]
	WHERE	[EXISTING].[RecipientUserID] IS NULL

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,@Trigger,0,GETDATE(),@RowsAffected,@ProcessedTo)
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP PROCEDURE [Monitoring].[SP_ExpectedTaskNotificationEmails]
            ");
        }
    }
}
