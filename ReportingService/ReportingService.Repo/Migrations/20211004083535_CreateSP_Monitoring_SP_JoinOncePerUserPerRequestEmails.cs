using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportingService.Repo.Migrations
{
    public partial class CreateSP_Monitoring_SP_JoinOncePerUserPerRequestEmails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE [Monitoring].[SP_JoinOncePerUserPerRequestEmails]
	@Trigger VARCHAR(100)
	,@Activity VARCHAR(100)
	,@RunID INT
	,@TemplateName VARCHAR(100)

  AS 

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,@Trigger,1,GETDATE(),NULL,NULL)

  DECLARE	@RowsAffected INT
			,@LastRunTimestamp DATETIME
			,@ProcessedTo DATETIME

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

  SELECT	@ProcessedTo = CASE	WHEN @ProcessedTo > MAX([DateFrom]) THEN MAX([DateFrom])
								ELSE @ProcessedTo
								END
	FROM	[Communication].[Event]
	WHERE	[TemplateName] = @TemplateName

  IF OBJECT_ID('tempdb..[#ActualEmails]') IS NOT NULL
    DROP TABLE [#ActualEmails]

  CREATE TABLE [#ActualEmails]
	( [RecipientUserID] INT
	  ,[TimestampProcessed] DATETIME
	  ,[TimestampDelivered] DATETIME
	  ,[TimestampDropped] DATETIME
	  ,[TimestampInteraction] DATETIME
	  ,[MessageID] VARCHAR(50)
	  ,[JobID] INT
	  ,[RequestID] INT
	  ,[GroupID] INT
	  ,[Matched] BIT )

  INSERT INTO [#ActualEmails]
	( [RecipientUserID]
	  ,[MessageID]
	  ,[TimestampProcessed]
	  ,[TimestampDelivered]
	  ,[TimestampDropped]
	  ,[TimestampInteraction]
	  ,[JobID]
	  ,[RequestID]
	  ,[GroupID] )
  SELECT	[E].[RecipientUserID]
			,[E].[MessageID]
			,MIN(CASE WHEN [Event] = 'Processed' THEN [EventDate] END)
			,MIN(CASE WHEN [Event] = 'delivered' THEN [EventDate] END)
			,MIN(CASE WHEN [Event] = 'dropped' THEN [EventDate] END)
			,MIN(CASE WHEN [Event] IN ('open','click') THEN [EventDate] END)
		    ,CASE	WHEN [JobID] = 'null' THEN NULL
					ELSE [JobID]
					END
		    ,CASE	WHEN [RequestID] = 'null' THEN NULL
					ELSE [RequestID]
					END
		    ,CASE	WHEN [GroupID] = 'null' THEN NULL
					ELSE [GroupID]
					END
	FROM	[Communication].[Event]
			  AS [E]
			RIGHT JOIN
			(
			  SELECT	[MessageID]
				FROM	[Communication].[Event]
				WHERE	[TemplateName] = @TemplateName
						  AND [DateFrom] BETWEEN @LastRunTimestamp AND @ProcessedTo
			)
			  AS [SAMPLE]
			  ON [E].[MessageID] = [SAMPLE].[MessageID]
  GROUP BY	[E].[RecipientUserID]
			,[E].[MessageID]
		    ,[JobID]
		    ,[RequestID]
		    ,[GroupID]

  IF OBJECT_ID('tempdb..[#ActualEmails_Grouped]') IS NOT NULL
    DROP TABLE [#ActualEmails_Grouped]

  CREATE TABLE [#ActualEmails_Grouped]
	( [RecipientUserID] INT
	  ,[JobID] INT
	  ,[RequestID] INT
	  ,[GroupID] INT
	  ,[Date] DATE
	  ,[MinTimestampProcessed] DATETIME
	  ,[MinTimestampDelivered] DATETIME
	  ,[MinTimestampDropped] DATETIME
	  ,[MinTimestampInteraction] DATETIME
	  ,[DistinctMessageIDs] INT
	  ,[SingleMessageID] VARCHAR(50) )

  INSERT INTO [#ActualEmails_Grouped]
	( [RecipientUserID]
	  ,[RequestID]
	  ,[GroupID]
	  ,[MinTimestampProcessed]
	  ,[MinTimestampDelivered]
	  ,[MinTimestampDropped]
	  ,[MinTimestampInteraction]
	  ,[DistinctMessageIDs]
	  ,[SingleMessageID] )
  SELECT	[RecipientUserID]
			,[RequestID]
			,[GroupID]
			,MIN([TimestampProcessed]) AS [MinTimestampProcessed]
			,MIN([TimestampDelivered]) AS [MinTimestampDelivered]
			,MIN([TimestampDropped]) AS [MinTimestampDropped]
			,MIN([TimestampInteraction]) AS [MinTimestampInteraction]
			,COUNT(DISTINCT [MessageID]) AS [DistinctMessageIDs]
			,CASE WHEN COUNT(DISTINCT [MessageID]) = 1 THEN MAX([MessageID]) END
	FROM	[#ActualEmails]
	GROUP BY [RecipientUserID]
			,[RequestID]
			,[GroupID]
			
  SELECT	@RowsAffected = COUNT(1)
	FROM	[#ActualEmails_Grouped]

  UPDATE	[EXP]
	SET		[MinTimestampProcessed] = [ACT].[MinTimestampProcessed]
			,[MinTimestampDelivered] = [ACT].[MinTimestampDelivered]
			,[MinTimestampDropped] = [ACT].[MinTimestampDropped]
			,[MinTimestampInteraction] = [ACT].[MinTimestampInteraction]
			,[DistinctMessageIDs] = [ACT].[DistinctMessageIDs]
			,[SingleMessageID] = [ACT].[SingleMessageID]
			,[JoinUpdated] = 1
	FROM	[Monitoring].[ExpectedEmails]
			  AS [EXP]
			LEFT JOIN
			[#ActualEmails_Grouped]
			  AS [ACT]
			  ON [EXP].[RecipientUserID] = [ACT].[RecipientUserID]
				   AND [EXP].[RequestID] = [ACT].[RequestID]
				   AND [EXP].[TemplateName] = @TemplateName
	WHERE	[ACT].[RecipientUserID] IS NOT NULL

  UPDATE	[Monitoring].[ExpectedEmails]
	SET		[JoinUpdated] = 1
	WHERE	[TimestampExpected] BETWEEN @LastRunTimestamp AND @ProcessedTo
			  AND [TemplateName] = @TemplateName

  UPDATE	[ACT]
	SET		[Matched] = 1
	FROM	[Monitoring].[ExpectedEmails]
			  AS [EXP]
			LEFT JOIN
			[#ActualEmails]
			  AS [ACT]
			  ON [EXP].[RecipientUserID] = [ACT].[RecipientUserID]
				   AND [EXP].[TemplateName] = @TemplateName
				   AND [EXP].[RequestID] = [ACT].[RequestID]
	WHERE	[EXP].[RecipientUserID] IS NOT NULL

  UPDATE	[CM]
	SET		[MatchedToExpectedEmail] = [ACT].[Matched]
	FROM	[Monitoring].[CommunicationMessage]
			  AS [CM]
			LEFT JOIN
			[#ActualEmails]
			  AS [ACT]
			  ON [CM].[MessageID] = [ACT].[MessageID]
	WHERE	[ACT].[MessageID] IS NOT NULL

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,@Trigger,0,GETDATE(),@RowsAffected,@ProcessedTo)
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP PROCEDURE [Monitoring].[SP_JoinOncePerUserPerRequestEmails]
            ");
        }
    }
}
