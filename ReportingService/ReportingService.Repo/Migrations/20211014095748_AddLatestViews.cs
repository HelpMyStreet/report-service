﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportingService.Repo.Migrations
{
    public partial class AddLatestViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

                EXEC('CREATE SCHEMA [AddressLatest];')
                EXEC('CREATE SCHEMA [FeedbackLatest]; ')
                EXEC('CREATE SCHEMA [GroupLatest];')
                EXEC('CREATE SCHEMA [LookupLatest];')
                EXEC('CREATE SCHEMA [QuestionSetLatest];')
                EXEC('CREATE SCHEMA [RequestLatest];')
                EXEC('CREATE SCHEMA [UserLatest];')
                EXEC('CREATE SCHEMA [VerificationLatest];')
                EXEC('CREATE SCHEMA [WebsiteLatest];')
                EXEC('CREATE view [AddressLatest].[AddressDetail] AS SELECT a.[Id],a.[PostcodeId],a.[AddressLine1],a.[AddressLine2],a.[AddressLine3],a.[Locality],a.[LastUpdated],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Address].[AddressDetail] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,Id from [Address].[AddressDetail] group by Id) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.Id=Latest.Id WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [AddressLatest].[PreComputedNearestPostcodes] AS SELECT a.[Id],a.[Postcode],a.[CompressedNearestPostcodes],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Address].[PreComputedNearestPostcodes] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,Id from [Address].[PreComputedNearestPostcodes] group by Id) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.Id=Latest.Id WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [AddressLatest].[Location] AS SELECT a.[Id],a.[Name],a.[ShortName],a.[AddressLine1],a.[AddressLine2],a.[AddressLine3],a.[Locality],a.[PostCode],a.[Latitude],a.[Longitude],a.[Instructions],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Address].[Location] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,Id from [Address].[Location] group by Id) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.Id=Latest.Id WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [FeedbackLatest].[Feedback] AS SELECT a.[ID],a.[FeedbackDate],a.[JobId],a.[UserId],a.[RequestRoleTypeID],a.[FeedbackRatingTypeID],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Feedback].[Feedback] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Feedback].[Feedback] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [GroupLatest].[Credential] AS SELECT a.[ID],a.[Name],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Group].[Credential] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Group].[Credential] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [GroupLatest].[CredentialSet] AS SELECT a.[ID],a.[GroupID],a.[CredentialID],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Group].[CredentialSet] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,CredentialID,GroupID,ID from [Group].[CredentialSet] group by CredentialID,GroupID,ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.CredentialID=Latest.CredentialID AND a.GroupID=Latest.GroupID AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [GroupLatest].[GroupCredential] AS SELECT a.[GroupID],a.[CredentialID],a.[CredentialTypeID],a.[Name],a.[HowToAchieve],a.[DisplayOrder],a.[CredentialVerifiedById],a.[HowToAchieve_CTA_Destination],a.[WhatIsThis],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Group].[GroupCredential] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,CredentialID,GroupID from [Group].[GroupCredential] group by CredentialID,GroupID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.CredentialID=Latest.CredentialID AND a.GroupID=Latest.GroupID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [GroupLatest].[GroupLocation] AS SELECT a.[GroupID],a.[LocationID],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Group].[GroupLocation] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,GroupID,LocationID from [Group].[GroupLocation] group by GroupID,LocationID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.GroupID=Latest.GroupID AND a.LocationID=Latest.LocationID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [GroupLatest].[NewRequestNotificationStrategy] AS SELECT a.[GroupID],a.[NewRequestNotificationStrategyId],a.[MaxVolunteer],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Group].[NewRequestNotificationStrategy] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,GroupID from [Group].[NewRequestNotificationStrategy] group by GroupID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.GroupID=Latest.GroupID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [GroupLatest].[SecurityConfiguration] AS SELECT a.[GroupID],a.[AllowAutonomousJoinersAndLeavers],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Group].[SecurityConfiguration] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,GroupID from [Group].[SecurityConfiguration] group by GroupID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.GroupID=Latest.GroupID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [GroupLatest].[SupportActivityInstructions] AS SELECT a.[SupportActivityInstructionsID],a.[Instructions],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Group].[SupportActivityInstructions] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,SupportActivityInstructionsID from [Group].[SupportActivityInstructions] group by SupportActivityInstructionsID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.SupportActivityInstructionsID=Latest.SupportActivityInstructionsID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [GroupLatest].[UserCredential] AS SELECT a.[GroupID],a.[UserID],a.[CredentialID],a.[DateAdded],a.[ValidUntil],a.[AuthorisedByUserID],a.[Reference],a.[Notes],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Group].[UserCredential] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,CredentialID,DateAdded,GroupID,UserID from [Group].[UserCredential] group by CredentialID,DateAdded,GroupID,UserID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.CredentialID=Latest.CredentialID AND a.DateAdded=Latest.DateAdded AND a.GroupID=Latest.GroupID AND a.UserID=Latest.UserID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [GroupLatest].[UserRole] AS SELECT a.[UserID],a.[RoleID],a.[GroupID],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Group].[UserRole] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,GroupID,RoleID,UserID from [Group].[UserRole] group by GroupID,RoleID,UserID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.GroupID=Latest.GroupID AND a.RoleID=Latest.RoleID AND a.UserID=Latest.UserID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [GroupLatest].[UserRoleAudit] AS SELECT a.[Id],a.[AuthorisedByUserID],a.[UserID],a.[GroupID],a.[RoleID],a.[DateRequested],a.[ActionID],a.[Success],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Group].[UserRoleAudit] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,Id from [Group].[UserRoleAudit] group by Id) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.Id=Latest.Id WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [GroupLatest].[GroupSupportActivityConfiguration] AS SELECT a.[GroupID],a.[SupportActivityID],a.[SupportActivityInstructionsID],a.[DateFrom],a.[SYS_CHANGE_OPERATION],a.[Radius] FROM [Group].[GroupSupportActivityConfiguration] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,GroupID,SupportActivityID from [Group].[GroupSupportActivityConfiguration] group by GroupID,SupportActivityID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.GroupID=Latest.GroupID AND a.SupportActivityID=Latest.SupportActivityID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [GroupLatest].[ActivityCredentialSet] AS SELECT a.[GroupID],a.[ActivityID],a.[CredentialSetID],a.[DateFrom],a.[SYS_CHANGE_OPERATION],a.[DisplayOrder] FROM [Group].[ActivityCredentialSet] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ActivityID,CredentialSetID,GroupID from [Group].[ActivityCredentialSet] group by ActivityID,CredentialSetID,GroupID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ActivityID=Latest.ActivityID AND a.CredentialSetID=Latest.CredentialSetID AND a.GroupID=Latest.GroupID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [GroupLatest].[Group] AS SELECT a.[Id],a.[GroupName],a.[ParentGroupId],a.[GroupKey],a.[DateFrom],a.[SYS_CHANGE_OPERATION],a.[ShiftsEnabled],a.[HomepageEnabled],a.[TasksEnabled],a.[GeographicName],a.[GroupType],a.[FriendlyName],a.[LinkURL],a.[ShortName],a.[JoinGroupPopUpDetail] FROM [Group].[Group] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,Id from [Group].[Group] group by Id) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.Id=Latest.Id WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [GroupLatest].[GroupEmailConfiguration] AS SELECT a.[GroupID],a.[Configuration],a.[CommunicationJobTypeID],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Group].[GroupEmailConfiguration] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,CommunicationJobTypeID,GroupID from [Group].[GroupEmailConfiguration] group by CommunicationJobTypeID,GroupID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.CommunicationJobTypeID=Latest.CommunicationJobTypeID AND a.GroupID=Latest.GroupID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [GroupLatest].[GroupMapDetails] AS SELECT a.[GroupID],a.[MapLocationID],a.[Latitude],a.[Longitude],a.[ZoomLevel],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Group].[GroupMapDetails] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,GroupID,MapLocationID from [Group].[GroupMapDetails] group by GroupID,MapLocationID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.GroupID=Latest.GroupID AND a.MapLocationID=Latest.MapLocationID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [LookupLatest].[RequestEvent] AS SELECT a.[ID],a.[Name],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Lookup].[RequestEvent] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[RequestEvent] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [LookupLatest].[Role] AS SELECT a.[ID],a.[Name],a.[DateFrom],a.[SYS_CHANGE_OPERATION],a.[IsAdmin] FROM [Lookup].[Role] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[Role] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [LookupLatest].[GroupType] AS SELECT a.[ID],a.[Name],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Lookup].[GroupType] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[GroupType] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [LookupLatest].[FeedbackRating] AS SELECT a.[ID],a.[Name],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Lookup].[FeedbackRating] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[FeedbackRating] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [LookupLatest].[RequestRoles] AS SELECT a.[ID],a.[Name],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Lookup].[RequestRoles] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[RequestRoles] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [LookupLatest].[RequestorType] AS SELECT a.[ID],a.[Name],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Lookup].[RequestorType] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[RequestorType] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [LookupLatest].[CredentialTypes] AS SELECT a.[ID],a.[Name],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Lookup].[CredentialTypes] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[CredentialTypes] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [LookupLatest].[DueDateType] AS SELECT a.[ID],a.[Name],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Lookup].[DueDateType] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[DueDateType] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [LookupLatest].[JobStatus] AS SELECT a.[ID],a.[Name],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Lookup].[JobStatus] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[JobStatus] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [LookupLatest].[Location] AS SELECT a.[ID],a.[Name],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Lookup].[Location] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[Location] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [LookupLatest].[NewRequestNotificationStrategy] AS SELECT a.[ID],a.[Name],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Lookup].[NewRequestNotificationStrategy] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[NewRequestNotificationStrategy] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [LookupLatest].[Question] AS SELECT a.[ID],a.[Name],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Lookup].[Question] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[Question] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [LookupLatest].[QuestionType] AS SELECT a.[ID],a.[Name],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Lookup].[QuestionType] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[QuestionType] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [LookupLatest].[RegistrationFormVariant] AS SELECT a.[ID],a.[Name],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Lookup].[RegistrationFormVariant] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[RegistrationFormVariant] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [LookupLatest].[RequestFormStage] AS SELECT a.[ID],a.[Name],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Lookup].[RequestFormStage] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[RequestFormStage] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [LookupLatest].[RequestFormVariant] AS SELECT a.[ID],a.[Name],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Lookup].[RequestFormVariant] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[RequestFormVariant] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [LookupLatest].[RequestHelpFormVariant] AS SELECT a.[ID],a.[Name],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Lookup].[RequestHelpFormVariant] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[RequestHelpFormVariant] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [LookupLatest].[RequestType] AS SELECT a.[ID],a.[Name],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Lookup].[RequestType] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[RequestType] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [LookupLatest].[SupportActivity] AS SELECT a.[ID],a.[Name],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Lookup].[SupportActivity] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[SupportActivity] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [LookupLatest].[SupportActivityInstructions] AS SELECT a.[ID],a.[Name],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Lookup].[SupportActivityInstructions] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[SupportActivityInstructions] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [LookupLatest].[TargetGroup] AS SELECT a.[ID],a.[Name],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Lookup].[TargetGroup] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[TargetGroup] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [QuestionSetLatest].[ActivityQuestions] AS SELECT a.[RequestFormVariantID],a.[ActivityID],a.[QuestionID],a.[Order],a.[Required],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [QuestionSet].[ActivityQuestions] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ActivityID,QuestionID,RequestFormVariantID from [QuestionSet].[ActivityQuestions] group by ActivityID,QuestionID,RequestFormVariantID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ActivityID=Latest.ActivityID AND a.QuestionID=Latest.QuestionID AND a.RequestFormVariantID=Latest.RequestFormVariantID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [QuestionSetLatest].[Question] AS SELECT a.[ID],a.[Name],a.[QuestionType],a.[Required],a.[AdditionalData],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [QuestionSet].[Question] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [QuestionSet].[Question] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [RequestLatest].[JobAvailableToGroup] AS SELECT a.[JobID],a.[GroupID],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Request].[JobAvailableToGroup] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,GroupID,JobID from [Request].[JobAvailableToGroup] group by GroupID,JobID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.GroupID=Latest.GroupID AND a.JobID=Latest.JobID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [RequestLatest].[JobQuestions] AS SELECT a.[JobID],a.[QuestionID],a.[Answer],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Request].[JobQuestions] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,JobID,QuestionID from [Request].[JobQuestions] group by JobID,QuestionID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.JobID=Latest.JobID AND a.QuestionID=Latest.QuestionID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [RequestLatest].[LogRequestEvent] AS SELECT a.[RequestId],a.[DateRequested],a.[RequestEventId],a.[JobId],a.[UserId],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Request].[LogRequestEvent] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,DateRequested,RequestEventId,RequestId from [Request].[LogRequestEvent] group by DateRequested,RequestEventId,RequestId) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.DateRequested=Latest.DateRequested AND a.RequestEventId=Latest.RequestEventId AND a.RequestId=Latest.RequestId WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [RequestLatest].[Job] AS SELECT a.[ID],a.[RequestId],a.[SupportActivityID],a.[Details],a.[DueDate],a.[IsHealthCritical],a.[JobStatusID],a.[VolunteerUserID],a.[DateFrom],a.[SYS_CHANGE_OPERATION],a.[DueDateTypeId],a.[Reference],a.[NotBeforeDate] FROM [Request].[Job] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Request].[Job] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [RequestLatest].[SupportActivities] AS SELECT a.[RequestID],a.[ActivityID],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Request].[SupportActivities] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ActivityID,RequestID from [Request].[SupportActivities] group by ActivityID,RequestID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ActivityID=Latest.ActivityID AND a.RequestID=Latest.RequestID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [RequestLatest].[Shift] AS SELECT a.[RequestId],a.[StartDate],a.[ShiftLength],a.[LocationId],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Request].[Shift] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,RequestId from [Request].[Shift] group by RequestId) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.RequestId=Latest.RequestId WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [RequestLatest].[Request] AS SELECT a.[ID],a.[PostCode],a.[DateRequested],a.[IsFulfillable],a.[CommunicationSent],a.[FulfillableStatus],a.[ForRequestor],a.[OtherDetails],a.[PersonID_Recipient],a.[PersonID_Requester],a.[ReadPrivacyNotice],a.[AcceptedTerms],a.[SpecialCommunicationNeeds],a.[CreatedByUserID],a.[DateFrom],a.[SYS_CHANGE_OPERATION],a.[RequestorType],a.[OrganisationName],a.[ReferringGroupId],a.[Source],a.[Archive],a.[Guid],a.[RequestorDefinedByGroup],a.[RequestType],a.[SuppressRecipientPersonalDetail],a.[MultiVolunteer],a.[Repeat],a.[ParentGuid] FROM [Request].[Request] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Request].[Request] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [RequestLatest].[RequestSubmission] AS SELECT a.[RequestID],a.[FreqencyID],a.[NumberOfRepeats],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Request].[RequestSubmission] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,RequestID from [Request].[RequestSubmission] group by RequestID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.RequestID=Latest.RequestID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [RequestLatest].[RequestJobStatus] AS SELECT a.[JobID],a.[JobStatusID],a.[DateCreated],a.[VolunteerUserID],a.[CreatedByUserID],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Request].[RequestJobStatus] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,DateCreated,JobID,JobStatusID from [Request].[RequestJobStatus] group by DateCreated,JobID,JobStatusID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.DateCreated=Latest.DateCreated AND a.JobID=Latest.JobID AND a.JobStatusID=Latest.JobStatusID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [UserLatest].[ChampionPostcode] AS SELECT a.[UserID],a.[PostalCode],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [User].[ChampionPostcode] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,PostalCode,UserID from [User].[ChampionPostcode] group by PostalCode,UserID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.PostalCode=Latest.PostalCode AND a.UserID=Latest.UserID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [UserLatest].[RegistrationHistory] AS SELECT a.[UserID],a.[RegistrationStep],a.[DateCompleted],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [User].[RegistrationHistory] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,RegistrationStep,UserID from [User].[RegistrationHistory] group by RegistrationStep,UserID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.RegistrationStep=Latest.RegistrationStep AND a.UserID=Latest.UserID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [UserLatest].[SupportActivity] AS SELECT a.[UserID],a.[ActivityID],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [User].[SupportActivity] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ActivityID,UserID from [User].[SupportActivity] group by ActivityID,UserID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ActivityID=Latest.ActivityID AND a.UserID=Latest.UserID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [UserLatest].[User] AS SELECT a.[ID],a.[FirebaseUID],a.[PostalCode],a.[EmailSharingConsent],a.[MobileSharingConsent],a.[OtherPhoneSharingConsent],a.[HMSContactConsent],a.[IsVolunteer],a.[IsVerified],a.[DateCreated],a.[StreetChampionRoleUnderstood],a.[SupportVolunteersByPhone],a.[SupportRadiusMiles],a.[DateFrom],a.[SYS_CHANGE_OPERATION],a.[ReferringGroupId],a.[Source] FROM [User].[User] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [User].[User] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [WebsiteLatest].[RegistrationJourney] AS SELECT a.[GroupId],a.[Source],a.[RegistrationFormVariant],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Website].[RegistrationJourney] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,GroupId,Source from [Website].[RegistrationJourney] group by GroupId,Source) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.GroupId=Latest.GroupId AND a.Source=Latest.Source WHERE [SYS_CHANGE_OPERATION]<>''d''')
                EXEC('CREATE view [WebsiteLatest].[RequestHelpJourney] AS SELECT a.[GroupId],a.[Source],a.[RequestHelpFormVariant],a.[TargetGroups],a.[DateFrom],a.[SYS_CHANGE_OPERATION],a.[AccessRestrictedByRole],a.[RequestorDefinedByGroup],a.[RequestsRequireApproval],a.[SuppressRecipientPersonalDetails] FROM [Website].[RequestHelpJourney] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,GroupId,Source from [Website].[RequestHelpJourney] group by GroupId,Source) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.GroupId=Latest.GroupId AND a.Source=Latest.Source WHERE [SYS_CHANGE_OPERATION]<>''d''')
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}