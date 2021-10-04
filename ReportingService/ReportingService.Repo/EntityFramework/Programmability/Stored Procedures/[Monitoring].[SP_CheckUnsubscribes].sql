CREATE PROCEDURE [Monitoring].[SP_CheckUnsubscribes]
	@Trigger VARCHAR(100)
	,@Activity VARCHAR(100)
	,@RunID INT

  AS 

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,@Trigger,1,GETDATE(),NULL,NULL)

  DECLARE	@RowsAffected INT
			,@TargetUserID INT
			,@TargetTemplateName VARCHAR(100)
			,@TargetTimestamp DATETIME
			,@Unsubscribed BIT = 0
			,@ProcessedTo DATETIME

  SELECT	@RowsAffected = COUNT(1)
			,@ProcessedTo = MAX([TimestampExpected])
	FROM	[Monitoring].[ExpectedEmails]
	WHERE	[Unsubscribed] IS NULL

  UPDATE	[A]
	SET		[Unsubscribed] = 0
	FROM	[Monitoring].[ExpectedEmails]
			  AS [A]
			LEFT JOIN
			[Monitoring].[EmailUnsubscribes]
			  AS [B]
			  ON [A].[RecipientUserID] = [B].[RecipientUserID]
	WHERE	[A].[Unsubscribed] IS NULL
			  AND [B].[RecipientUserID] IS NULL

  SELECT	@TargetUserID = [RecipientUserID]
			,@TargetTemplateName = [TemplateName]
			,@TargetTimestamp = [TimestampExpected]
	FROM	[Monitoring].[ExpectedEmails]
	WHERE	[Unsubscribed] IS NULL	 
	ORDER BY [TemplateName]
			,[TimestampExpected]

  WHILE		@TargetUserID IS NOT NULL
	BEGIN
			  SELECT	@Unsubscribed = [Analysis].[FN_CheckUnsubscribes](@TargetUserID,@TargetTemplateName,@TargetTimestamp)

			 -- SELECT	@Unsubscribed = CASE	WHEN [Event] LIKE '%unsubscribe%' THEN 1
				--								ELSE 0
				--								END
				--FROM	(
				--		  SELECT	*
				--					,ROW_NUMBER() OVER (ORDER BY [EventDate] DESC) AS [RowNum]
				--			FROM	[Monitoring].[EmailUnsubscribes]
				--			WHERE	[RecipientUserID] = @TargetUserID
				--					  AND ([TemplateName] = @TargetTemplateName OR [TemplateName] IN (SELECT [TemplateName] FROM [Analysis].[EmailTemplates] WHERE [GroupName] = (SELECT [GroupName] FROM [Analysis].[EmailTemplates] WHERE [TemplateName] = @TargetTemplateName)))
				--					  AND [EventDate] <= @TargetTimestamp
				--					  AND [Event] LIKE '%subscribe%'
				--		)
				--		  AS [A]
				--WHERE	[RowNum] = 1

			  UPDATE	[Monitoring].[ExpectedEmails]
				SET		[Unsubscribed] = @Unsubscribed
				WHERE	[RecipientUserID] = @TargetUserID
						  AND [TemplateName] = @TargetTemplateName
						  AND [TimestampExpected] = @TargetTimestamp

			  SELECT	@TargetUserID = NULL
						,@Unsubscribed = 0

			  SELECT	@TargetUserID = [RecipientUserID]
						,@TargetTemplateName = [TemplateName]
						,@TargetTimestamp = [TimestampExpected]
				FROM	[Monitoring].[ExpectedEmails]
				WHERE	[Unsubscribed] IS NULL	 
				ORDER BY [TemplateName]
						,[TimestampExpected]

	END
	
  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,@Trigger,0,GETDATE(),@RowsAffected,@ProcessedTo)