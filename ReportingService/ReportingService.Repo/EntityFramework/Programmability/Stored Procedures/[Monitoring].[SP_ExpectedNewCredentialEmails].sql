CREATE PROCEDURE [Monitoring].[SP_ExpectedNewCredentialEmails]
	@Trigger VARCHAR(100)
	,@Activity VARCHAR(100)
	,@RunID INT

  AS 

  DECLARE	@RowsAffected INT
			,@LastRunTimestamp DATETIME
			,@ProcessedTo DATETIME
			,@TemplateName VARCHAR(100) = 'NewCredentials'

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
	  ,[DateAdded] DATETIME
	  ,[Details] VARCHAR(100)
	  ,[GroupID] INT )

  INSERT INTO [#Expected]
	( [UserID]
	  ,[DateAdded]
	  ,[Details]
	  ,[GroupID] )
  SELECT	[UserID]
			,[DateAdded]
			,[C].[Name]
			,[GroupID]
	FROM	[Group].[UserCredential]
			  AS [UC]
			LEFT JOIN
			[GroupLatest].[Credential]
			  AS [C]
			  ON [UC].[CredentialID] = [C].[ID]
	WHERE	[DateAdded] BETWEEN @LastRunTimestamp AND @ProcessedTo
			  AND [CredentialID] NOT IN (SELECT [ID] FROM [Group].[Credential] WHERE [Name] = 'IdentityVerifiedByYoti')

  DELETE	[NEW]
	FROM	[#Expected]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [EXISTING].[TemplateName] = @TemplateName
				   AND [NEW].[DateAdded] = [EXISTING].[TimestampExpected]
	WHERE	[EXISTING].[RecipientUserID] IS NOT NULL

  SELECT	@RowsAffected = COUNT(1)
	FROM	[#Expected]

  INSERT INTO [Monitoring].[ExpectedEmails]
	( [RecipientUserID]
	  ,[TemplateName]
	  ,[TimestampExpected]
	  ,[Details]
	  ,[GroupID] )
  SELECT	[UserID]
			,@TemplateName
			,[DateAdded]
			,[Details]
			,[GroupID]
	FROM	[#Expected]

  UPDATE	[EXP]
	SET		[EmailsExpected] = [C].[COUNT]
	FROM	[Monitoring].[ExpectedEmails]
			  AS [EXP]
			LEFT JOIN
			(
			  SELECT	[RecipientUserID]
						,[GroupID]
						,COUNT(1) AS [COUNT]
				FROM	[Monitoring].[ExpectedEmails]
				WHERE	[RecipientUserID] IN (SELECT [UserID] FROM [#Expected])
						  AND [TemplateName] = @TemplateName
				GROUP BY [RecipientUserID]
						,[GroupID]
			)
			  AS [C]
			  ON [EXP].[RecipientUserID] = [C].[RecipientUserID]
				   AND [EXP].[GroupID] = [C].[GroupID]
	WHERE	[C].[RecipientUserID] IS NOT NULL
			  AND [EXP].[TemplateName] = @TemplateName

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,@Trigger,0,GETDATE(),@RowsAffected,@ProcessedTo)