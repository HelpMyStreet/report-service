CREATE PROCEDURE [Monitoring].[SP_EmailMonitoring]
	AS 

  DECLARE	@Activity VARCHAR(50) = 'Expected emails'
			,@RunID INT
			,@RowsAffected INT
			,@LastRunTimestamp DATETIME
			,@Trigger VARCHAR(100)
			,@ProcessedTo DATETIME

  /* Get the next RunID */
  SELECT	@RunID = MAX([RunID])
	FROM	[Monitoring].[MonitoringTimestamps]
	WHERE	[Activity] = @Activity

  SELECT	@RunID = ISNULL(@RunID,0) + 1

  /*******************************************************************************************************/
  /** 1. Stored Procs to generate expected emails														**/
  /*******************************************************************************************************/
		  /**	1.1		HelpMyStreet welcome emails														**/
		  /**			Triggered when volunteers complete registration									**/
		  /************ Job disabled and replaced with group welcome email *******************************/
		  /***********************************************************************************************/
		  /*	  EXECUTE [Monitoring].[SP_ExpectedWelcomeEmails]
		  		@Trigger = 'SP_ExpectedWelcomeEmails'
				,@Activity = @Activity
				,@RunID = @RunID */

		  /***********************************************************************************************/
		  /**	1.2		Partial registration emails														**/
		  /**			Triggered when volunteers abandon registration process for 30 minutes or more	**/
		  /***********************************************************************************************/
			  EXECUTE [Monitoring].[SP_ExpectedPartRegEmails]
				@Trigger = 'SP_ExpectedPartRegEmails'
				,@Activity = @Activity
				,@RunID = @RunID

		  /***********************************************************************************************/
		  /**	1.3		New credentials email															**/
		  /**			Triggered when an admin manually adds a credential (non-Yoti)					**/
		  /***********************************************************************************************/
			  EXECUTE [Monitoring].[SP_ExpectedNewCredentialEmails]
				@Trigger = 'SP_ExpectedNewCredentialEmails'
				,@Activity = @Activity
				,@RunID = @RunID

		  /***********************************************************************************************/
		  /**	1.4		Task reminder email																**/
		  /**			Volunteer notification triggered TBC days before a task request is due			**/
		  /***********************************************************************************************/
			  EXECUTE [Monitoring].[SP_ExpectedTaskReminderEmails]
				@Trigger = 'SP_ExpectedTaskReminderEmails'
				,@Activity = @Activity
				,@RunID = @RunID
				
		  /***********************************************************************************************/
		  /**	1.5		Shift reminder email															**/
		  /**			Volunteer notification triggered TBC days before a shift request is due			**/
		  /***********************************************************************************************/
			  EXECUTE [Monitoring].[SP_ExpectedShiftReminderEmails]
				@Trigger = 'SP_ExpectedShiftReminderEmails'
				,@Activity = @Activity
				,@RunID = @RunID
				
		  /***********************************************************************************************/
		  /**	1.6		Daily digest email																**/
		  /**			Currently sent twice weekly (monday and Friday) to all users where one or		**/
		  /**			more open requests meet the criteria they signed up with						**/
		  /***********************************************************************************************/
			  EXECUTE [Monitoring].[SP_ExpectedDailyDigestEmails]
				@Trigger = 'SP_ExpectedDailyDigestEmails'
				,@Activity = @Activity
				,@RunID = @RunID

		  /***********************************************************************************************/
		  /**	1.7		Requester notification email													**/
		  /**			Sent to requester's email address immediately after submitting a request		**/
		  /***********************************************************************************************/
			  EXECUTE [Monitoring].[SP_ExpectedRequesterNotificationEmails]
				@Trigger = 'SP_ExpectedRequesterNotificationEmails'
				,@Activity = @Activity
				,@RunID = @RunID

		  /***********************************************************************************************/
		  /**	1.8		Task notification email															**/
		  /**			Sent to relevant users immediately after a task request is submitted			**/
		  /***********************************************************************************************/
			  EXECUTE [Monitoring].[SP_ExpectedTaskNotificationEmails]
				@Trigger = 'SP_ExpectedTaskNotificationEmails'
				,@Activity = @Activity
				,@RunID = @RunID
				
		  /***********************************************************************************************/
		  /**	1.9		Shift notification email														**/
		  /**			Batched notification sent to relevant users on the hour after a shift request 	**/
		  /**			is submitted																	**/
		  /***********************************************************************************************/
			  EXECUTE [Monitoring].[SP_ExpectedShiftNotificationEmails]
				@Trigger = 'SP_ExpectedShiftNotificationEmails'
				,@Activity = @Activity
				,@RunID = @RunID

		  /***********************************************************************************************/
		  /**	1.10	Request update email															**/
		  /**			Notification sent to relevant users after a request is updated in the system	**/
		  /***********************************************************************************************/
			  EXECUTE [Monitoring].[SP_ExpectedRequestUpdateEmails]
				@Trigger = 'SP_ExpectedRequestUpdateEmails'
				,@Activity = @Activity
				,@RunID = @RunID

		  /***********************************************************************************************/
		  /**	1.11	New group welcome email															**/
		  /**			Group specific welcome email sent when a user becomes a member of a group		**/
		  /***********************************************************************************************/
			  EXECUTE [Monitoring].[SP_ExpectedGroupWelcomeEmails]
				@Trigger = 'SP_ExpectedGroupWelcomeEmails'
				,@Activity = @Activity
				,@RunID = @RunID

		  /***********************************************************************************************/
		  /**	1.12	New task pending approval email													**/
		  /**			Notification to task admins when a new task is added that requires approval		**/
		  /**			from task admins before the request is made available to volunteers				**/
		  /***********************************************************************************************/
			  EXECUTE [Monitoring].[SP_ExpectedNewTaskPendingApprovalNotificationEmails]
				@Trigger = 'SP_ExpectedNewTaskPendingApprovalNotificationEmails'
				,@Activity = @Activity
				,@RunID = @RunID

  /*******************************************************************************************************/
  /** 2. Stored Proc to flag unsubscribes																**/
  /*******************************************************************************************************/
		  /***********************************************************************************************/
		  /**	2.1		Populate the table [Analysis].[EmailUnsubscribes] to speed up the query			**/
		  /***********************************************************************************************/
			  EXECUTE [Monitoring].[SP_PopulateUnsubscribed]
				@Trigger = 'SP_PopulateUnsubscribed'
				,@Activity = @Activity
				,@RunID = @RunID

		  /***********************************************************************************************/
		  /**	2.2		Update NULL unsubscribe flag													**/
		  /***********************************************************************************************/
			  EXECUTE [Monitoring].[SP_CheckUnsubscribes]
				@Trigger = 'SP_CheckUnsubscribes'
				,@Activity = @Activity
				,@RunID = @RunID

  /*******************************************************************************************************/
  /** 3. Stored Procs to join on actual emails															**/
  /*******************************************************************************************************/
		  /**	3.1		Create a list of message IDs to flag unexpected email							**/
		  /***********************************************************************************************/
			  EXECUTE [Monitoring].[SP_PopulateCommunication_Message]
				@Trigger = 'SP_PopulateCommunication_Message' 
				,@Activity = @Activity
				,@RunID = @RunID

		  /***********************************************************************************************/
		  /**	3.1		Join once per user per template name											**/
		  /***********************************************************************************************/
		  /************ Job disabled and replaced with group welcome email *******************************/
		  /*	  EXECUTE [Analysis].[SP_JoinOncePerUserEmails]
				@Trigger = 'SP_JoinOncePerUserEmails_Welcome' 
				,@Activity = @Activity
				,@RunID = @RunID
				,@TemplateName = 'Welcome' */

			  EXECUTE [Monitoring].[SP_JoinOncePerUserEmails]
				@Trigger = 'SP_JoinOncePerUserEmails_PartialRegistration' 
				,@Activity = @Activity
				,@RunID = @RunID
				,@TemplateName = 'PartialRegistration'
				
		  /***********************************************************************************************/
		  /**	3.2		Join once per user per template name per group									**/
		  /***********************************************************************************************/
			  EXECUTE [Monitoring].[SP_JoinOncePerUserPerGroupEmails]
				@Trigger = 'SP_JoinOncePerUserPerGroupEmails_NewCredentials' 
				,@Activity = @Activity
				,@RunID = @RunID
				,@TemplateName = 'NewCredentials'
				
		  /***********************************************************************************************/
		  /**	3.3		Join once per user per template name per job per day							**/
		  /***********************************************************************************************/
			  EXECUTE [Monitoring].[SP_JoinOncePerUserPerJobPerDayEmails]
				@Trigger = 'SP_JoinOncePerUserPerJobPerDayEmails_TaskReminder' 
				,@Activity = @Activity
				,@RunID = @RunID
				,@TemplateName = 'TaskReminder'
								
			  EXECUTE [Monitoring].[SP_JoinOncePerUserPerJobPerDayEmails]
				@Trigger = 'SP_JoinOncePerUserPerJobPerDayEmails_RequestReminder' 
				,@Activity = @Activity
				,@RunID = @RunID
				,@TemplateName = 'ShiftReminder'

			  EXECUTE [Monitoring].[SP_JoinOncePerUserPerJobPerDayEmails]
				@Trigger = 'SP_JoinOncePerUserPerJobPerDayEmails_TaskUpdateSimplified' 
				,@Activity = @Activity
				,@RunID = @RunID
				,@TemplateName = 'TaskUpdateSimplified'
				
		  /***********************************************************************************************/
		  /**	3.4		Join once per user per template name per day									**/
		  /***********************************************************************************************/
			  EXECUTE [Monitoring].[SP_JoinOncePerUserPerDayEmails]
				@Trigger = 'SP_JoinOncePerUserPerDayEmails_DailyDigest' 
				,@Activity = @Activity
				,@RunID = @RunID
				,@TemplateName = 'DailyDigest'
				
		  /***********************************************************************************************/
		  /**	3.5		Join once per user per template name per request								**/
		  /***********************************************************************************************/
			  EXECUTE [Monitoring].[SP_JoinOncePerUserPerRequestEmails]
				@Trigger = 'SP_JoinOncePerUserPerRequestEmails_RequestorNotification' 
				,@Activity = @Activity
				,@RunID = @RunID
				,@TemplateName = 'RequestorTaskNotification'
				
			  EXECUTE [Monitoring].[SP_JoinOncePerUserPerRequestEmails]
				@Trigger = 'SP_JoinOncePerUserPerRequestEmails_TaskNotification' 
				,@Activity = @Activity
				,@RunID = @RunID
				,@TemplateName = 'TaskNotification'
							
			  EXECUTE [Monitoring].[SP_JoinOncePerUserPerRequestEmails]
				@Trigger = 'SP_JoinOncePerUserPerRequestEmails_NewTaskPendingApprovalNotification' 
				,@Activity = @Activity
				,@RunID = @RunID
				,@TemplateName = 'NewTaskPendingApprovalNotification'
				
		  /***********************************************************************************************/
		  /**	3.6		Join once per user per user per group per day									**/
		  /***********************************************************************************************/
			  EXECUTE [Monitoring].[SP_JoinOncePerUserPerGroupPerDayEmails]
				@Trigger = 'SP_JoinOncePerUserPerGroupPerDayEmails_GroupWelcome' 
				,@Activity = @Activity
				,@RunID = @RunID
				,@TemplateName = 'GroupWelcome'

		  /***********************************************************************************************/
		  /**	3.4		Join once per user per template name per hour									**/
		  /***********************************************************************************************/
			  EXECUTE [Monitoring].[SP_JoinOncePerUserPerHourEmails]
				@Trigger = 'SP_JoinOncePerUserPerHourEmails_RequestNotification' 
				,@Activity = @Activity
				,@RunID = @RunID
				,@TemplateName = 'RequestNotification'
												
  /*******************************************************************************************************/
  /** 4. Stored Proc to flag issues																		**/
  /*******************************************************************************************************/
  EXECUTE [Monitoring].[SP_CalculateIssueFlag]
	@Trigger = 'SP_CalculateIssueFlag'
	,@Activity = @Activity
	,@RunID = @RunID

  /*******************************************************************************************************/
  /** 5. Query to show outpt																			**/
  /*******************************************************************************************************/
 
  SELECT	[Date]
			,[TemplateName]
			,SUM(CASE WHEN [Issue] = 0 THEN [Count] END) AS [OK]
			,SUM(CASE WHEN [Issue] = 1 THEN [Count] END) AS [Issue]
			,SUM(CASE WHEN [Issue] IS NULL THEN [Count] END) AS [NULL]
			,SUM(CASE WHEN [Issue] = 0 THEN [Count] END) * 1.0 /SUM([Count]) AS [PercentOK]
	FROM	[Monitoring].[viewEmailMonitoring_Daily]
	WHERE	[Date] >= CAST(DATEADD(DD,-7,GETDATE()) AS DATE)
	GROUP BY [Date]
			,[TemplateName]
	ORDER BY [TemplateName]
			,[Date] DESC