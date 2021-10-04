using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportingService.Repo.Migrations
{
    public partial class CreateSP_Monitoring_SP_ExpectedWelcomeEmails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE [Monitoring].[SP_ExpectedWelcomeEmails]
	@Trigger VARCHAR(100)
	,@Activity VARCHAR(100)
	,@RunID INT

  AS 

  DECLARE	@RowsAffected INT
			,@LastRunTimestamp DATETIME
			,@ProcessedTo DATETIME
			,@TemplateName VARCHAR(100) = 'Welcome'

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
	  ,[DateCompleted] DATETIME )

  INSERT INTO [#Expected]
	( [UserID]
	  ,[DateCompleted] )
  SELECT	[UserID]
			,[DateCompleted]
	FROM	[User].[RegistrationHistory]
	WHERE	[DateCompleted] >= @LastRunTimestamp
			  AND [DateCompleted] <= @ProcessedTo
			  AND [RegistrationStep] = 3
			  AND [DateCompleted] IS NOT NULL

  DELETE	[NEW]
	FROM	[#Expected]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [EXISTING].[TemplateName] = @TemplateName
	WHERE	[EXISTING].[RecipientUserID] IS NOT NULL

  SELECT	@RowsAffected = COUNT(1)
	FROM	[#Expected]

  INSERT INTO [Monitoring].[ExpectedEmails]
	( [RecipientUserID]
	  ,[TemplateName]
	  ,[TimestampExpected]
	  ,[EmailsExpected] )
  SELECT	[UserID]
			,@TemplateName
			,[DateCompleted]
			,1
	FROM	[#Expected]

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,@Trigger,0,GETDATE(),@RowsAffected,@ProcessedTo)
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP PROCEDURE [Monitoring].[SP_ExpectedWelcomeEmails]
            ");
        }
    }
}
