CREATE PROCEDURE [Monitoring].[SP_ExpectedPartRegEmails]
	@Trigger VARCHAR(100)
	,@Activity VARCHAR(100)
	,@RunID INT

  AS 

  DECLARE	@RowsAffected INT
			,@LastRunTimestamp DATETIME
			,@ProcessedTo DATETIME
			,@TemplateName VARCHAR(100) = 'PartialRegistration'

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
	  ,[DateCompleted] DATETIME
	  ,[Details] VARCHAR(100)
	  ,[GroupID] INT )

  INSERT INTO [#Expected]
	( [UserID]
	  ,[DateCompleted]
	  ,[Details]
	  ,[GroupID] )
  SELECT	[1].[UserID]
			,[1].[DateCompleted]
			,CASE	WHEN [2].[UserID] IS NULL THEN CONCAT('Abandoned at registration step ',[1].[RegistrationStep]) 
					ELSE CONCAT('Paused at registration step ',[1].[RegistrationStep],' for ',CAST(FLOOR(DATEDIFF(SS,[1].[DateCompleted],[2].[DateCompleted]) / 60.0) AS INT),' min(s)')
					END AS [Details]
			,[U].[ReferringGroupID]
	FROM	(
				SELECT	*
						,ROW_NUMBER() OVER (PARTITION BY [UserID] ORDER BY [DateCompleted]) AS [RowNum]
				FROM	[UserLatest].[RegistrationHistory]
				WHERE	[UserID] IN (SELECT [UserID] FROM [UserLatest].[RegistrationHistory] WHERE [DateCompleted] BETWEEN @LastRunTimestamp AND @ProcessedTo)
			)
				AS [1]
			LEFT JOIN
			(
				SELECT	*
						,ROW_NUMBER() OVER (PARTITION BY [UserID] ORDER BY [DateCompleted]) AS [RowNum]
				FROM	[UserLatest].[RegistrationHistory]
				WHERE	[UserID] IN (SELECT [UserID] FROM [UserLatest].[RegistrationHistory] WHERE [DateCompleted] BETWEEN @LastRunTimestamp AND @ProcessedTo)
			)
				AS [2]
				ON [1].[UserID] = [2].[UserID]
					AND [1].[RowNum] = ([2].[RowNum] - 1)
			LEFT JOIN
			[UserLatest].[User]
			  AS [U]
			  ON [1].[UserID] = [U].[ID]
	WHERE	[1].[RegistrationStep] < 3
				AND ISNULL([2].[DateCompleted],GETDATE()) > DATEADD(MI,30,[1].[DateCompleted])

  DELETE	[NEW]
	FROM	[#Expected]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [EXISTING].[TemplateName] = @TemplateName
				   AND [NEW].[DateCompleted] = [EXISTING].[TimestampExpected]
	WHERE	ISNULL([NEW].[Details],'') = ISNULL([EXISTING].[Details],'')
			  AND [EXISTING].[RecipientUserID] IS NOT NULL

  SELECT	@RowsAffected = COUNT(1)
	FROM	[#Expected]

  INSERT INTO [Monitoring].[ExpectedEmails]
	( [RecipientUserID]
	  ,[TemplateName]
	  ,[TimestampExpected]
	  ,[Details]
	  ,[GroupID] )
  SELECT	[NEW].[UserID]
			,'PartialRegistration'
			,[NEW].[DateCompleted]
			,[NEW].[Details]
			,[NEW].[GroupID]
	FROM	[#Expected]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [EXISTING].[TemplateName] = 'PartialRegistration'
				   AND [NEW].[DateCompleted] = [EXISTING].[TimestampExpected]
	WHERE	[EXISTING].[RecipientUserID] IS NULL

  UPDATE	[EXISTING]
	SET		[Details] = [NEW].[Details]
	FROM	[#Expected]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [EXISTING].[TemplateName] = 'PartialRegistration'
				   AND [NEW].[DateCompleted] = [EXISTING].[TimestampExpected]
	WHERE	ISNULL([NEW].[Details],'') <> ISNULL([EXISTING].[Details],'')
	
  UPDATE	[EXP]
	SET		[EmailsExpected] = [C].[COUNT]
	FROM	[Monitoring].[ExpectedEmails]
			  AS [EXP]
			LEFT JOIN
			(
			  SELECT	[RecipientUserID]
						,COUNT(1) AS [COUNT]
				FROM	[Monitoring].[ExpectedEmails]
				WHERE	[RecipientUserID] IN (SELECT [UserID] FROM [#Expected])
						  AND [TemplateName] = @TemplateName
				GROUP BY [RecipientUserID]
			)
			  AS [C]
			  ON [EXP].[RecipientUserID] = [C].[RecipientUserID]
	WHERE	[C].[RecipientUserID] IS NOT NULL
			  AND [EXP].[TemplateName] = @TemplateName

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,@Trigger,0,GETDATE(),@RowsAffected,@ProcessedTo)