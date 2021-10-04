CREATE PROCEDURE [Monitoring].[SP_PopulateCommunication_Message]
	@Trigger VARCHAR(100)
	,@Activity VARCHAR(100)
	,@RunID INT

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

  SELECT	@LastRunTimestamp = ISNULL(@LastRunTimestamp,'2021-01-01')

  SELECT	@ProcessedTo = CASE	WHEN GETDATE() > DATEADD(MM,1,@LastRunTimestamp) THEN DATEADD(MM,1,@LastRunTimestamp)
								ELSE GETDATE() 
								END

  IF OBJECT_ID('tempdb..[#Emails]') IS NOT NULL
    DROP TABLE [#Emails]

  CREATE TABLE [#Emails]
	( [MessageID] VARCHAR(50)
	  ,PRIMARY KEY([MessageID]) )

  INSERT INTO [#Emails]
	( [MessageID] )
  SELECT	[MessageID]
	FROM	[Communication].[Event]
	WHERE	CAST([DateFrom] AS DATE) BETWEEN @LastRunTimestamp AND @ProcessedTo
			  AND [MessageID] IS NOT NULL
			  AND [Event] NOT LIKE '%subscribe%'
	GROUP BY [MessageID]

  DELETE	[#Emails]
	WHERE	[MessageID] IN (SELECT [MessageID] FROM [Monitoring].[CommunicationMessage])

  SELECT	@RowsAffected = COUNT(1)
	FROM	[#Emails]

  INSERT INTO [Monitoring].[CommunicationMessage]
	( [MessageID] )
  SELECT	[MessageID]
	FROM	[#Emails]

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,@Trigger,0,GETDATE(),@RowsAffected,@ProcessedTo)