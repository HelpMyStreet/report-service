using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportingService.Repo.Migrations
{
    public partial class CreateSP_Monitoring_SP_PopulateUnsubscribed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE [Monitoring].[SP_PopulateUnsubscribed]
	@Trigger VARCHAR(100)
	,@Activity VARCHAR(100)
	,@RunID INT

  AS 

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,@Trigger,1,GETDATE(),NULL,NULL)

  DECLARE	@RowsAffected INT
			,@ProcessedTo DATETIME

  SELECT	@ProcessedTo = MAX([ProcessedTo])
	FROM	[Monitoring].[MonitoringTimestamps]
	WHERE	[Activity] = @Activity
			  AND [Trigger] = @Trigger

  SELECT	@ProcessedTo = ISNULL(@ProcessedTo,'2020-01-01')

  SELECT	@RowsAffected = COUNT(1)
	FROM	[Monitoring].[EmailUnsubscribes]

  INSERT INTO [Monitoring].[EmailUnsubscribes]
	( [RecipientUserID]
	  ,[TemplateName]
	  ,[Event]
	  ,[EventDate]
	  ,[DateFrom]
	  ,[MessageId]
	  ,[GroupId]
	  ,[JobId]
	  ,[RequestId] )
  SELECT	[RecipientUserID]
			,[TemplateName]
			,[Event]
			,CAST([EventDate] AS DATETIME)
			,[DateFrom]
			,[MessageId]
			,CASE	WHEN [GroupId] = 'null' THEN NULL
					ELSE CAST([GroupId] AS INT)
					END
			,CASE	WHEN [JobId] = 'null' THEN NULL
					ELSE CAST([JobId] AS INT)
					END
			,CASE	WHEN [RequestId] = 'null' THEN NULL
					ELSE CAST([RequestId] AS INT)
					END
	FROM	[Communication].[Event]
			  AS [A]
	WHERE	[DateFrom] > @ProcessedTo
			  AND [Event] LIKE '%subscribe%'
	
  SELECT	@RowsAffected = COUNT(1) - @RowsAffected
	FROM	[Monitoring].[EmailUnsubscribes]
	
  SELECT	@ProcessedTo = MAX([DateFrom])
	FROM	[Communication].[Event]

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,@Trigger,0,GETDATE(),@RowsAffected,@ProcessedTo)
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP PROCEDURE [Monitoring].[SP_PopulateUnsubscribed]
            ");
        }
    }
}
