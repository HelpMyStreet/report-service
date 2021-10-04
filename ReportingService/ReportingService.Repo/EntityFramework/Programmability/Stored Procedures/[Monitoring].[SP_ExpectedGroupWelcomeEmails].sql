CREATE PROCEDURE [Monitoring].[SP_ExpectedGroupWelcomeEmails]
	@Trigger VARCHAR(100)
	,@Activity VARCHAR(100)
	,@RunID INT

  AS 

  DECLARE	@RowsAffected INT
			,@LastRunTimestamp DATETIME
			,@ProcessedTo DATETIME
			,@TemplateName VARCHAR(100) = 'GroupWelcome'

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
	  ,[GroupID] INT
	  ,[DateRequested] DATETIME )

  INSERT INTO [#Expected]
	( [UserID]
	  ,[GroupID]
	  ,[DateRequested] )
  SELECT	[R].[UserID]
			,[R].[GroupID]
			,[R].[DateRequested]
	FROM	[Group].[UserRoleAudit]
			  AS [R]
			LEFT JOIN
			[UserLatest].[User]
			  AS [U]
			  ON [R].[UserID] = [U].[ID]
	WHERE	[DateRequested] >= @LastRunTimestamp
			  AND [DateRequested] <= @ProcessedTo
			  AND [RoleID] = (SELECT [ID] FROM [Lookup].[Role] WHERE [Name] = 'Member')
			  AND [ActionID] = 1 /* 1 = Joined group */
			  AND [Success] = 1
			  AND NOT ([R].[GroupID] = -1 AND [U].[ReferringGroupID] <> -1)

  DELETE	[NEW]
	FROM	[#Expected]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [NEW].[GroupID] = [EXISTING].[GroupID]
				   AND [NEW].[DateRequested] = [EXISTING].[TimestampExpected]
				   AND [EXISTING].[TemplateName] = @TemplateName
	WHERE	[EXISTING].[RecipientUserID] IS NOT NULL

  SELECT	@RowsAffected = COUNT(1)
	FROM	[#Expected]

  INSERT INTO [Monitoring].[ExpectedEmails]
	( [RecipientUserID]
	  ,[TemplateName]
	  ,[GroupID]
	  ,[TimestampExpected]
	  ,[EmailsExpected] )
  SELECT	[UserID]
			,@TemplateName
			,[GroupID]
			,MIN([DateRequested])
			,COUNT(1)
	FROM	[#Expected]
	GROUP BY [UserID]
			,[GroupID]
			,CAST([DateRequested] AS DATE)

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,@Trigger,0,GETDATE(),@RowsAffected,@ProcessedTo)