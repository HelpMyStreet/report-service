CREATE PROCEDURE [Monitoring].[SP_ExpectedNewTaskPendingApprovalNotificationEmails]
	@Trigger VARCHAR(100)
	,@Activity VARCHAR(100)
	,@RunID INT

  AS 

  DECLARE	@RowsAffected INT
			,@LastRunTimestamp DATETIME
			,@ProcessedTo DATETIME
			,@TemplateName VARCHAR(100) = 'NewTaskPendingApprovalNotification'

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
	( [DateRequested] DATETIME
	  ,[GroupID] INT
	  ,[RequestID] INT )

  INSERT INTO [#Expected]
	( [DateRequested]
	  ,[GroupID]
	  ,[RequestID] )
  SELECT	[R].[DateRequested]
			,[R].[ReferringGroupID]
			,[R].[ID]
	FROM	(
			  SELECT	[JobID]
						,[JobStatusID]
						,[DateCreated]
						,[CreatedByUserID]
						,ROW_NUMBER() OVER (PARTITION BY [JobID] ORDER BY [DateCreated]) AS [RowNum]
				FROM	[Request].[RequestJobStatus]
				WHERE	[JobID] IN (SELECT [ID] FROM [RequestLatest].[Job] WHERE [RequestID] IN (SELECT [ID] FROM [RequestLatest].[Request] WHERE [DateRequested] BETWEEN @LastRunTimestamp AND @ProcessedTo))
			)
			  AS [A]
			LEFT JOIN
			(
			  SELECT	[JobID]
						,[JobStatusID]
						,[DateCreated]
						,[CreatedByUserID]
						,ROW_NUMBER() OVER (PARTITION BY [JobID] ORDER BY [DateCreated]) AS [RowNum]
				FROM	[Request].[RequestJobStatus]
				WHERE	[JobID] IN (SELECT [ID] FROM [RequestLatest].[Job] WHERE [RequestID] IN (SELECT [ID] FROM [RequestLatest].[Request] WHERE [DateRequested] BETWEEN @LastRunTimestamp AND @ProcessedTo))
			)
			  AS [B]
			  ON [A].[JobID] = [B].[JobID]
				   AND [A].[RowNum] = [B].[RowNum] - 1
			LEFT JOIN
			[RequestLatest].[Job]
			  AS [J]
			  ON [A].[JobID] = [J].[ID]
			LEFT JOIN
			[RequestLatest].[Request]
			  AS [R]
			  ON [J].[RequestID] = [R].[ID]
	WHERE	[A].[JobStatusID] = (SELECT [ID] FROM [LookupLatest].[JobStatus] WHERE [Name] = 'New')
			  AND ([B].[JobStatusID] = (SELECT [ID] FROM [LookupLatest].[JobStatus] WHERE [Name] = 'Open') OR [B].[JobStatusID] IS NULL)
			  AND ([B].[CreatedByUserID] <> -1 OR [B].[CreatedByUserID] IS NULL)
			  AND [R].[DateRequested] BETWEEN @LastRunTimestamp AND @ProcessedTo

  IF OBJECT_ID('tempdb..[#TaskAdmins]') IS NOT NULL
    DROP TABLE [#TaskAdmins]

  CREATE TABLE [#TaskAdmins]
	( [GroupID] INT
	  ,[UserID] INT
	  ,[ActionID] INT
	  ,[DateFrom] DATETIME
	  ,[DateTo] DATETIME )

  INSERT INTO [#TaskAdmins]
	( [GroupID]
	  ,[UserID]
	  ,[ActionID]
	  ,[DateFrom]
	  ,[DateTo] )
  SELECT	[A].[GroupID]
			,[A].[UserID]
			,[A].[ActionID]
			,[A].[DateRequested] AS [DateFrom]
			,[B].[DateRequested] AS [DateTo]
	FROM	(
			  SELECT	[GroupID]
						,[UserID]
						,[DateRequested]
						,[ActionID]
						,ROW_NUMBER() OVER (PARTITION BY [GroupID],[UserID] ORDER BY [DateRequested]) AS [RowNum]
				FROM	[GroupLatest].[UserRoleAudit]
				WHERE	[GroupID] IN (SELECT [GroupID] FROM [#Expected])
						  AND [RoleID] = (SELECT [ID] FROM [LookupLatest].[Role] WHERE [Name] = 'TaskAdmin')
						  AND [Success] = 1
			)
			  AS [A]
			LEFT JOIN
			(
			  SELECT	[GroupID]
						,[UserID]
						,[DateRequested]
						,[ActionID]
						,ROW_NUMBER() OVER (PARTITION BY [GroupID],[UserID] ORDER BY [DateRequested]) AS [RowNum]
				FROM	[GroupLatest].[UserRoleAudit]
				WHERE	[GroupID] IN (SELECT [GroupID] FROM [#Expected])
						  AND [RoleID] = (SELECT [ID] FROM [LookupLatest].[Role] WHERE [Name] = 'TaskAdmin')
						  AND [Success] = 1
			)
			  AS [B]
			  ON [A].[GroupID] = [B].[GroupID]
				   AND [A].[UserID] = [B].[UserID]
				   AND [A].[RowNum] = [B].[RowNum] - 1

  IF OBJECT_ID('tempdb..[#ExpectedEmails]') IS NOT NULL
    DROP TABLE [#ExpectedEmails]

  CREATE TABLE [#ExpectedEmails]
	( [GroupID] INT
	  ,[UserID] INT
	  ,[DateRequested] DATETIME
	  ,[RequestID] INT )

  INSERT INTO [#ExpectedEmails]
	( [GroupID]
	  ,[UserID]
	  ,[DateRequested]
	  ,[RequestID] )
  SELECT	[E].[GroupID]
			,[A].[UserID]
			,[E].[DateRequested]
			,[E].[RequestID]
	FROM	[#Expected]
			  AS [E]
			LEFT JOIN
			[#TaskAdmins]
			  AS [A]
			  ON [E].[GroupID] = [A].[GroupID]
				   AND [E].[DateRequested] >= [A].[DateFrom]
				   AND ([E].[DateRequested] <= [A].[DateTo] OR [A].[DateTo] IS NULL)
				   AND [A].[ActionID] = 1
	WHERE	[A].[UserID] IS NOT NULL

  DELETE	[NEW]
	FROM	[#ExpectedEmails]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [EXISTING].[TemplateName] = @TemplateName
				   AND [NEW].[RequestID] = [EXISTING].[RequestID]
	WHERE	[EXISTING].[RecipientUserID] IS NOT NULL

  SELECT	@RowsAffected = COUNT(1)
	FROM	[#ExpectedEmails]

  INSERT INTO [Monitoring].[ExpectedEmails]
	( [RecipientUserID]
	  ,[TemplateName]
	  ,[TimestampExpected]
	  ,[GroupID]
	  ,[RequestID]
	  ,[EmailsExpected] )
  SELECT	[NEW].[UserID]
			,@TemplateName
			,[NEW].[DateRequested]
			,[NEW].[GroupID]
			,[NEW].[RequestID]
			,1
	FROM	[#ExpectedEmails]
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