CREATE PROCEDURE [Monitoring].[SP_CalculateIssueFlag]
	@Trigger VARCHAR(100)
	,@Activity VARCHAR(100)
	,@RunID INT

  AS 

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,@Trigger,1,GETDATE(),NULL,NULL)

  DECLARE	@RowsAffected INT
			,@ProcessedTo DATETIME

  /* Ensure job updates records where a valid email has been sent to a previous suspect invalid email address */
  UPDATE	[Monitoring].[ExpectedEmails]
	SET		[JoinUpdated] = 1
	WHERE	[IssueDescription] = 'Suspected invalid email address'
			  AND [RecipientUserID] NOT IN (SELECT [RecipientUserID] FROM [Monitoring].[viewDroppedEmailAddresses])

  /* Ensure job doesn't flag emails to default user ID with no email address */
  UPDATE	[Monitoring].[ExpectedEmails]
	SET		[JoinUpdated] = NULL
			,[Issue] = 1
			,[IssueDescription] = 'Reporting - no unique user ID or email address on record'
	WHERE	[RecipientUserID] = -1
			  AND [RecipientEmailAddress] IS NULL

  SELECT	@ProcessedTo = MAX([TimestampExpected])
			,@RowsAffected = COUNT(1)
	FROM	[Monitoring].[ExpectedEmails]
	WHERE	[JoinUpdated] = 1

  UPDATE	[EXP]
	SET		[IssueDescription] = CASE	/* Set to NULL if email pre-dates latest template update */
										WHEN [EXP].[TimestampExpected] < [T].[DateLastModified] THEN NULL
										/* No issue if:
										   The number of emails expected is the same as the number of distinct message IDs sent
											 AND  If only one email is expected, the email was sent within an hour of expected timestamp 
											 AND  User has not unsubscribed from the mailing list */									
										WHEN [EXP].[EmailsExpected] = [EXP].[DistinctMessageIDs]
											   AND (([EXP].[EmailsExpected] = 1 AND [EXP].[MinTimestampProcessed] BETWEEN [EXP].[TimestampExpected] AND DATEADD(MINUTE,60,[EXP].[TimestampExpected]))
													  OR [EXP].[EmailsExpected] > 1)
											   AND [Unsubscribed] = 0 THEN 'None'
										/* No issue if:
										   The user has unsubcribed from the mailing list and no message IDs have been recorded */
										WHEN [Unsubscribed] = 1 AND ISNULL([DistinctMessageIDs],0) = 0 THEN 'None'
										/* No issue if:
										   The user has unsubcribed from the mailing list and a message has been processed and subsequently dropped */
										WHEN [Unsubscribed] = 1 AND [EXP].[MinTimestampProcessed] IS NULL AND [EXP].[MinTimestampDropped] IS NOT NULL THEN 'None'
										/* No issue if:
										   The group-specific max. email cap has been reached and no email has been sent */
										WHEN [RecipientOrder] > [MaxVolunteer] AND [DistinctMessageIDs] IS NULL THEN 'None'
										/* Suspect invalid email address */
										WHEN [D].[RecipientUserID] IS NOT NULL THEN 'Suspected invalid email address'
										/* No message ID recorded  on email record */
										WHEN ISNULL([EXP].[DistinctMessageIDs],0) = 0 AND ([EXP].[MinTimestampProcessed] IS NOT NULL OR [EXP].[MinTimestampDropped] IS NOT NULL) THEN 'Reporting - No Message ID'
										/* More unique message IDs than expected emails */
										WHEN [EXP].[DistinctMessageIDs] > [EXP].[EmailsExpected] THEN CONCAT('Unexpected email - ',ISNULL([EXP].[EmailsExpected],0),' expected, ',ISNULL([EXP].[DistinctMessageIDs],0),' recorded')
										/* Fewer unique message IDs than expected emails */
										WHEN ISNULL([EXP].[DistinctMessageIDs],0) < [EXP].[EmailsExpected] THEN CONCAT('Missing email - ',ISNULL([EXP].[EmailsExpected],0),' expected, ',ISNULL([EXP].[DistinctMessageIDs],0),' recorded')
										/* Email triggered before it was expected (single emails only) */
										WHEN [EXP].[EmailsExpected] = 1 AND [EXP].[MinTimestampProcessed] < [EXP].[TimestampExpected] THEN 'Timing - Email triggered early'
										/* Email triggered over an hour after it was expected (single emails only) */
										WHEN [EXP].[EmailsExpected] = 1 AND [EXP].[MinTimestampProcessed] > DATEADD(MINUTE,60,[EXP].[TimestampExpected]) THEN 'Timing - Email triggered late'
										/* User is unsubcribed from mailing list but still receiving an email */
										WHEN [EXP].[Unsubscribed] = 1 AND [EXP].[MinTimestampDelivered] IS NOT NULL THEN 'Unexpected email - User unsubscribed'
										/* User has recieved emails previously, is not unsubscribed but email has been dropped */
										WHEN [D].[RecipientUserID] IS NULL AND [EXP].[Unsubscribed] = 0 AND [EXP].[MinTimestampDropped] IS NOT NULL THEN 'Missing email - Dropped email'
										/* User has interacted with an email but there is no record of it being delivered */
										WHEN [EXP].[MinTimestampInteraction] IS NOT NULL AND [EXP].[MinTimestampDelivered] IS NULL THEN 'Reporting - No record of delivery'
										/* Email delivered but there is no record of it being processed */
										WHEN [EXP].[MinTimestampDelivered] IS NOT NULL AND [EXP].[MinTimestampProcessed] IS NULL THEN 'Reporting - No record of processing'
										ELSE 'Unknown'
										END
	FROM	[Monitoring].[ExpectedEmails]
			  AS [EXP]
			LEFT JOIN
			[Analysis].[EmailTemplates]
			  AS [T]
			  ON [EXP].[TemplateName] = [T].[TemplateName]
			LEFT JOIN
			(
			  SELECT	[A].[GroupID]
						,[A].[NewRequestNotificationStrategyID]
						,[A].[MaxVolunteer]
						,[A].[DateFrom]
						,[B].[DateFrom] AS [DateTo]
				FROM	(
						  SELECT	*
									,ROW_NUMBER() OVER (PARTITION BY [GroupID] ORDER BY [DateFrom]) AS [RowNum]
							FROM	[Group].[NewRequestNotificationStrategy]
						)
						  AS [A]
						LEFT JOIN
						(
						  SELECT	*
									,ROW_NUMBER() OVER (PARTITION BY [GroupID] ORDER BY [DateFrom]) AS [RowNum]
							FROM	[Group].[NewRequestNotificationStrategy]
						)
						  AS [B]
						  ON [A].[GroupID] = [B].[GroupID]
							   AND [A].[RowNum] = [B].[RowNum] - 1
			)
			  AS [NS]
			  ON [EXP].[GroupID] = [NS].[GroupID]
				   AND [EXP].[TimestampExpected] >= [NS].[DateFrom]
				   AND ([NS].[DateTo] IS NULL OR [EXP].[TimestampExpected] <= [NS].[DateTo])
			LEFT JOIN
			[Monitoring].[viewDroppedEmailAddresses]
			  AS [D]
			  ON [EXP].[RecipientUserID] = [D].[RecipientUserID]
	WHERE	[JoinUpdated] = 1

  UPDATE	[Monitoring].[ExpectedEmails]
	SET		[Issue] = CASE	WHEN [IssueDescription] = 'None' THEN 0
							WHEN [IssueDescription] IS NULL THEN NULL
							ELSE 1
							END
			,[JoinUpdated] = 0
	WHERE	[JoinUpdated] = 1

  INSERT INTO [Monitoring].[MonitoringTimestamps]
	VALUES (@Activity,@RunID,@Trigger,0,GETDATE(),@RowsAffected,@ProcessedTo)