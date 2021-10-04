CREATE PROCEDURE [Monitoring].[SP_ExpectedDailyDigestEmails]
	@Trigger VARCHAR(100)
	,@Activity VARCHAR(100)
	,@RunID INT

  AS 

  DECLARE	@RowsAffected INT
			,@LastRunTimestamp DATETIME
			,@ProcessedTo DATETIME
			,@TemplateName VARCHAR(100) = 'DailyDigest'

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
	VALUES (@Activity,@RunID,CONCAT(@Trigger,' - Date table'),1,GETDATE(),NULL,NULL)

  IF OBJECT_ID('tempdb..[#TT1]') IS NOT NULL
    DROP TABLE [#TT1]

  CREATE TABLE [#TT1]
	( [Date] DATE );

  WITH [DateRange]
	( [Date] ) AS 

	(
	  SELECT	CAST(@LastRunTimestamp AS DATE)
	  UNION ALL
	  SELECT	DATEADD(D,1,[Date])
		FROM	[DateRange]
		WHERE	[Date] < CAST(@ProcessedTo AS DATE)
	)

  INSERT INTO [#TT1]
  SELECT	[Date]
	FROM	[DateRange]
	OPTION	(MAXRECURSION 0)

  DELETE [#TT1]
	WHERE	CAST(@LastRunTimestamp AS TIME) >= '06:00'
			  AND [Date] = CAST(@LastRunTimestamp AS DATE)

  SELECT	@RowsAffected = COUNT(1)
	FROM	[#TT1]
  
  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,CONCAT(@Trigger,' - Date table'),0,GETDATE(),@RowsAffected,@ProcessedTo)

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,@Trigger,1,GETDATE(),NULL,NULL)

  IF OBJECT_ID('tempdb..[#Expected]') IS NOT NULL
    DROP TABLE [#Expected]

  CREATE TABLE [#Expected]
	( [UserID] INT
	  ,[DigestDue] DATETIME
	  ,[Details] VARCHAR(100)
	  ,[Unsubscribed] BIT )

  INSERT INTO [#Expected]
	( [UserID]
	  ,[DigestDue]
	  ,[Details]
	  ,[Unsubscribed] )
	SELECT	[FN].[UserID]
			,[D].[DigestDue]
			,CONCAT(COUNT(DISTINCT [D].[RequestID]),' Request(s)') AS [Details]
			,[FN].[Unsubscribed]
	FROM	(
				SELECT	[DigestDue]
						,[JobID]
						,[RequestID]
				FROM	(
						  SELECT	[B].*
									,[RJS].*
									,[J].[RequestID]
									,[JS].[Name] AS [JobStatus]
									,ROW_NUMBER() OVER (PARTITION BY [JobID],[DigestDue] ORDER BY [DateCreated] DESC) AS [RowNum]
							FROM	(
									  SELECT	DATEADD(HH,6,CAST([Date] AS DATETIME)) AS [DigestDue]
										FROM	[#TT1]
										WHERE	DATENAME(DW,[Date]) IN ('Tuesday','Thursday','Saturday')
									)
									  AS [B]
									LEFT JOIN
									(
									  SELECT	*
										FROM	[RequestLatest].[RequestJobStatus]
										WHERE	[JobID] NOT IN (SELECT [ID] FROM [RequestLatest].[Job] WHERE [JobStatusID] IN (SELECT [ID] FROM [Lookup].[JobStatus] WHERE [Name] IN ('Done','Cancelled')) AND CAST([DateFrom] AS DATE) < DATEADD(DD,-7,CAST(GETDATE() AS DATE)))
									)
									  AS [RJS]
									  ON [B].[DigestDue] >= [RJS].[DateCreated]
									LEFT JOIN
									[LookupLatest].[JobStatus]
									  AS [JS]
									  ON [RJS].[JobStatusID] = [JS].[ID]
									LEFT JOIN
									[RequestLatest].[Job]
									  AS [J]
									  ON [RJS].[JobID] = [J].[ID]
						)
						  AS [C]
				WHERE	[C].[RowNum] = 1
						  AND [C].[JobStatus] = 'Open'
			)
			  AS [D]
			CROSS APPLY
			[Analysis].[FN_GetUsersForNotification]
			([D].[JobID],[D].[DigestDue],@TemplateName)
				AS [FN]		  
	GROUP BY [FN].[UserID]
			,[D].[DigestDue]
			,[FN].[Unsubscribed]

  DELETE	[NEW]
	FROM	[#Expected]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [EXISTING].[TemplateName] = @TemplateName
				   AND [NEW].[DigestDue] = [EXISTING].[TimestampExpected]
	WHERE	[EXISTING].[RecipientUserID] IS NOT NULL

  SELECT	@RowsAffected = COUNT(1)
	FROM	[#Expected]

  INSERT INTO [Monitoring].[ExpectedEmails]
	( [RecipientUserID]
	  ,[TemplateName]
	  ,[TimestampExpected]
	  ,[Details]
	  ,[EmailsExpected]
	  ,[Unsubscribed] )
  SELECT	[NEW].[UserID]
			,@TemplateName
			,[NEW].[DigestDue]
			,[NEW].[Details]
			,1
			,[NEW].[Unsubscribed]
	FROM	[#Expected]
			  AS [NEW]
			LEFT JOIN
			[Monitoring].[ExpectedEmails]
			  AS [EXISTING]
			  ON [NEW].[UserID] = [EXISTING].[RecipientUserID]
				   AND [EXISTING].[TemplateName] = @TemplateName
				   AND [NEW].[DigestDue] = [EXISTING].[TimestampExpected]
	WHERE	[EXISTING].[RecipientUserID] IS NULL

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,@Trigger,0,GETDATE(),@RowsAffected,@ProcessedTo)