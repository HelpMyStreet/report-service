using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ReportingService.Repo.EntityFramework.Models;
using ReportingService.Repo.Extensions;
using ReportingService.Repo.Helpers;
using Scaffolding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportingService.Repo
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            if (Database.IsSqlServer())
            {
                SqlConnection conn = (SqlConnection)Database.GetDbConnection();
                conn.AddAzureToken();
            }
        }

        public virtual DbSet<ActivityCredentialSet> ActivityCredentialSet { get; set; }
        public virtual DbSet<ActivityCredentialSet1> ActivityCredentialSet1 { get; set; }
        public virtual DbSet<ActivityQuestions> ActivityQuestions { get; set; }
        public virtual DbSet<ActivityQuestions1> ActivityQuestions1 { get; set; }
        public virtual DbSet<AddressDetail> AddressDetail { get; set; }
        public virtual DbSet<AddressDetail1> AddressDetail1 { get; set; }
        public virtual DbSet<ChampionPostcode> ChampionPostcode { get; set; }
        public virtual DbSet<ChampionPostcode1> ChampionPostcode1 { get; set; }
        public virtual DbSet<CommunicationEvent> CommunicationEvent { get; set; }
        public virtual DbSet<CommunicationMessage> CommunicationMessage { get; set; }
        public virtual DbSet<Credential> Credential { get; set; }
        public virtual DbSet<Credential1> Credential1 { get; set; }
        public virtual DbSet<CredentialSet> CredentialSet { get; set; }
        public virtual DbSet<CredentialSet1> CredentialSet1 { get; set; }
        public virtual DbSet<CredentialTypes> CredentialTypes { get; set; }
        public virtual DbSet<CredentialTypes1> CredentialTypes1 { get; set; }
        public virtual DbSet<DueDateType> DueDateType { get; set; }
        public virtual DbSet<DueDateType1> DueDateType1 { get; set; }
        public virtual DbSet<EmailTemplates> EmailTemplates { get; set; }
        public virtual DbSet<EmailUnsubscribes> EmailUnsubscribes { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventHistory> EventHistory { get; set; }
        public virtual DbSet<ExpectedEmails> ExpectedEmails { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Feedback1> Feedback1 { get; set; }
        public virtual DbSet<Feedback2> Feedback2 { get; set; }
        public virtual DbSet<FeedbackFeedback> FeedbackFeedback { get; set; }
        public virtual DbSet<FeedbackRating> FeedbackRating { get; set; }
        public virtual DbSet<FeedbackRating1> FeedbackRating1 { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Group1> Group1 { get; set; }
        public virtual DbSet<GroupActivityCredentialSet> GroupActivityCredentialSet { get; set; }
        public virtual DbSet<GroupConfiguration> GroupConfiguration { get; set; }
        public virtual DbSet<GroupCredential> GroupCredential { get; set; }
        public virtual DbSet<GroupCredential1> GroupCredential1 { get; set; }
        public virtual DbSet<GroupEmailConfiguration> GroupEmailConfiguration { get; set; }
        public virtual DbSet<GroupEmailConfiguration1> GroupEmailConfiguration1 { get; set; }
        public virtual DbSet<GroupGroupCredential> GroupGroupCredential { get; set; }
        public virtual DbSet<GroupGroupEmailConfiguration> GroupGroupEmailConfiguration { get; set; }
        public virtual DbSet<GroupGroupLocation> GroupGroupLocation { get; set; }
        public virtual DbSet<GroupGroupMapDetails> GroupGroupMapDetails { get; set; }
        public virtual DbSet<GroupGroupSupportActivityConfiguration> GroupGroupSupportActivityConfiguration { get; set; }
        public virtual DbSet<GroupLocation> GroupLocation { get; set; }
        public virtual DbSet<GroupLocation1> GroupLocation1 { get; set; }
        public virtual DbSet<GroupMapDetails> GroupMapDetails { get; set; }
        public virtual DbSet<GroupMapDetails1> GroupMapDetails1 { get; set; }
        public virtual DbSet<GroupNewRequestNotificationStrategy> GroupNewRequestNotificationStrategy { get; set; }
        public virtual DbSet<GroupSupportActivityConfiguration> GroupSupportActivityConfiguration { get; set; }
        public virtual DbSet<GroupSupportActivityConfiguration1> GroupSupportActivityConfiguration1 { get; set; }
        public virtual DbSet<GroupType> GroupType { get; set; }
        public virtual DbSet<GroupType1> GroupType1 { get; set; }
        public virtual DbSet<GroupUserCredential> GroupUserCredential { get; set; }
        public virtual DbSet<GroupUserRole> GroupUserRole { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Job1> Job1 { get; set; }
        public virtual DbSet<JobAvailableToGroup> JobAvailableToGroup { get; set; }
        public virtual DbSet<JobAvailableToGroup1> JobAvailableToGroup1 { get; set; }
        public virtual DbSet<JobQuestions> JobQuestions { get; set; }
        public virtual DbSet<JobQuestions1> JobQuestions1 { get; set; }
        public virtual DbSet<JobStatus> JobStatus { get; set; }
        public virtual DbSet<JobStatus1> JobStatus1 { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Location1> Location1 { get; set; }
        public virtual DbSet<Location2> Location2 { get; set; }
        public virtual DbSet<Location3> Location3 { get; set; }
        public virtual DbSet<LocationPostcodes> LocationPostcodes { get; set; }
        public virtual DbSet<LogRequestEvent> LogRequestEvent { get; set; }
        public virtual DbSet<LogRequestEvent1> LogRequestEvent1 { get; set; }
        public virtual DbSet<MisalignedLatestViews> MisalignedLatestViews { get; set; }
        public virtual DbSet<MonitoringCommunicationMessage> MonitoringCommunicationMessage { get; set; }
        public virtual DbSet<MonitoringTimestamps> MonitoringTimestamps { get; set; }
        public virtual DbSet<MonthlyStats> MonthlyStats { get; set; }
        public virtual DbSet<NewRequestNotificationStrategy> NewRequestNotificationStrategy { get; set; }
        public virtual DbSet<NewRequestNotificationStrategy1> NewRequestNotificationStrategy1 { get; set; }
        public virtual DbSet<NewRequestNotificationStrategy2> NewRequestNotificationStrategy2 { get; set; }
        public virtual DbSet<NewRequestNotificationStrategy3> NewRequestNotificationStrategy3 { get; set; }
        public virtual DbSet<Postcode> Postcode { get; set; }
        public virtual DbSet<Postcode1> Postcode1 { get; set; }
        public virtual DbSet<PostcodeLookup> PostcodeLookup { get; set; }
        public virtual DbSet<PreComputedNearestPostcodes> PreComputedNearestPostcodes { get; set; }
        public virtual DbSet<PreComputedNearestPostcodes1> PreComputedNearestPostcodes1 { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Question1> Question1 { get; set; }
        public virtual DbSet<Question2> Question2 { get; set; }
        public virtual DbSet<Question3> Question3 { get; set; }
        public virtual DbSet<QuestionSetActivityQuestions> QuestionSetActivityQuestions { get; set; }
        public virtual DbSet<QuestionType> QuestionType { get; set; }
        public virtual DbSet<QuestionType1> QuestionType1 { get; set; }
        public virtual DbSet<RegistrationFormVariant> RegistrationFormVariant { get; set; }
        public virtual DbSet<RegistrationFormVariant1> RegistrationFormVariant1 { get; set; }
        public virtual DbSet<RegistrationHistory> RegistrationHistory { get; set; }
        public virtual DbSet<RegistrationHistory1> RegistrationHistory1 { get; set; }
        public virtual DbSet<RegistrationJourney> RegistrationJourney { get; set; }
        public virtual DbSet<RegistrationJourney1> RegistrationJourney1 { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<Request1> Request1 { get; set; }
        public virtual DbSet<RequestAnonymisation> RequestAnonymisation { get; set; }
        public virtual DbSet<RequestEvent> RequestEvent { get; set; }
        public virtual DbSet<RequestEvent1> RequestEvent1 { get; set; }
        public virtual DbSet<RequestFormStage> RequestFormStage { get; set; }
        public virtual DbSet<RequestFormStage1> RequestFormStage1 { get; set; }
        public virtual DbSet<RequestFormVariant> RequestFormVariant { get; set; }
        public virtual DbSet<RequestFormVariant1> RequestFormVariant1 { get; set; }
        public virtual DbSet<RequestHelpFormVariant> RequestHelpFormVariant { get; set; }
        public virtual DbSet<RequestHelpFormVariant1> RequestHelpFormVariant1 { get; set; }
        public virtual DbSet<RequestHelpJourney> RequestHelpJourney { get; set; }
        public virtual DbSet<RequestHelpJourney1> RequestHelpJourney1 { get; set; }
        public virtual DbSet<RequestJob> RequestJob { get; set; }
        public virtual DbSet<RequestJobAvailableToGroup> RequestJobAvailableToGroup { get; set; }
        public virtual DbSet<RequestJobQuestions> RequestJobQuestions { get; set; }
        public virtual DbSet<RequestJobStatus> RequestJobStatus { get; set; }
        public virtual DbSet<RequestJobStatus1> RequestJobStatus1 { get; set; }
        public virtual DbSet<RequestLogRequestEvent> RequestLogRequestEvent { get; set; }
        public virtual DbSet<RequestRequest> RequestRequest { get; set; }
        public virtual DbSet<RequestRoles> RequestRoles { get; set; }
        public virtual DbSet<RequestRoles1> RequestRoles1 { get; set; }
        public virtual DbSet<RequestShift> RequestShift { get; set; }
        public virtual DbSet<RequestSubmission> RequestSubmission { get; set; }
        public virtual DbSet<RequestSubmission1> RequestSubmission1 { get; set; }
        public virtual DbSet<RequestType> RequestType { get; set; }
        public virtual DbSet<RequestType1> RequestType1 { get; set; }
        public virtual DbSet<RequestorType> RequestorType { get; set; }
        public virtual DbSet<RequestorType1> RequestorType1 { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Role1> Role1 { get; set; }
        public virtual DbSet<SecurityConfiguration> SecurityConfiguration { get; set; }
        public virtual DbSet<SecurityConfiguration1> SecurityConfiguration1 { get; set; }
        public virtual DbSet<Shift> Shift { get; set; }
        public virtual DbSet<Shift1> Shift1 { get; set; }
        public virtual DbSet<SupportActivities> SupportActivities { get; set; }
        public virtual DbSet<SupportActivities1> SupportActivities1 { get; set; }
        public virtual DbSet<SupportActivity> SupportActivity { get; set; }
        public virtual DbSet<SupportActivity1> SupportActivity1 { get; set; }
        public virtual DbSet<SupportActivity2> SupportActivity2 { get; set; }
        public virtual DbSet<SupportActivity3> SupportActivity3 { get; set; }
        public virtual DbSet<SupportActivityInstructions> SupportActivityInstructions { get; set; }
        public virtual DbSet<SupportActivityInstructions1> SupportActivityInstructions1 { get; set; }
        public virtual DbSet<SupportActivityInstructions2> SupportActivityInstructions2 { get; set; }
        public virtual DbSet<SupportActivityInstructions3> SupportActivityInstructions3 { get; set; }
        public virtual DbSet<SuspectTestRequests> SuspectTestRequests { get; set; }
        public virtual DbSet<TargetGroup> TargetGroup { get; set; }
        public virtual DbSet<TargetGroup1> TargetGroup1 { get; set; }
        public virtual DbSet<TestRequests> TestRequests { get; set; }
        public virtual DbSet<UpdateHistory> UpdateHistory { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<User1> User1 { get; set; }
        public virtual DbSet<UserCredential> UserCredential { get; set; }
        public virtual DbSet<UserCredential1> UserCredential1 { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserRole1> UserRole1 { get; set; }
        public virtual DbSet<UserRoleAudit> UserRoleAudit { get; set; }
        public virtual DbSet<UserRoleAudit1> UserRoleAudit1 { get; set; }
        public virtual DbSet<UserSupportActivity> UserSupportActivity { get; set; }
        public virtual DbSet<UserUser> UserUser { get; set; }
        public virtual DbSet<VerificationAttempt> VerificationAttempt { get; set; }
        public virtual DbSet<VerificationAttempt1> VerificationAttempt1 { get; set; }
        public virtual DbSet<VerificationAttempt2> VerificationAttempt2 { get; set; }
        public virtual DbSet<VerificationVerificationAttempt> VerificationVerificationAttempt { get; set; }
        public virtual DbSet<ViewDroppedEmailAddresses> ViewDroppedEmailAddresses { get; set; }
        public virtual DbSet<ViewEmailMonitoring> ViewEmailMonitoring { get; set; }
        public virtual DbSet<ViewEmailMonitoringDaily> ViewEmailMonitoringDaily { get; set; }
        public virtual DbSet<ViewEmailTemplateUnsubscribes> ViewEmailTemplateUnsubscribes { get; set; }
        public virtual DbSet<ViewJobStatusTimestamps> ViewJobStatusTimestamps { get; set; }
        public virtual DbSet<ViewMonitoringTimestamps> ViewMonitoringTimestamps { get; set; }
        public virtual DbSet<ViewMonthlyStats> ViewMonthlyStats { get; set; }
        public virtual DbSet<ViewMonthlyStatsMonthToDate> ViewMonthlyStatsMonthToDate { get; set; }
        public virtual DbSet<ViewMonthlyStatsRecentActivity> ViewMonthlyStatsRecentActivity { get; set; }
        public virtual DbSet<ViewRecentActivity> ViewRecentActivity { get; set; }
        public virtual DbSet<ViewRequestVolume> ViewRequestVolume { get; set; }
        public virtual DbSet<ViewShiftFilling> ViewShiftFilling { get; set; }
        public virtual DbSet<ViewTimeTaken> ViewTimeTaken { get; set; }
        public virtual DbSet<WebsiteRegistrationJourney> WebsiteRegistrationJourney { get; set; }
        public virtual DbSet<WebsiteRequestHelpJourney> WebsiteRequestHelpJourney { get; set; }

        public virtual DbSet<QuicksightRoles> QuicksightRoles { get; set; }
        public virtual DbSet<QuicksightRoleGroups> QuicksightRoleGroups { get; set; }
        public virtual DbSet<QuicksightUsers> QuicksightUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityCredentialSet>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.ActivityId, e.CredentialSetId, e.SysChangeVersion });

                entity.ToTable("ActivityCredentialSet", "Group");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.CredentialSetId).HasColumnName("CredentialSetID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ActivityCredentialSet1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ActivityCredentialSet", "GroupLatest");

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.CredentialSetId).HasColumnName("CredentialSetID");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ActivityQuestions>(entity =>
            {
                entity.HasKey(e => new { e.RequestFormVariantId, e.ActivityId, e.QuestionId, e.SysChangeVersion });

                entity.ToTable("ActivityQuestions", "QuestionSet");

                entity.Property(e => e.RequestFormVariantId).HasColumnName("RequestFormVariantID");

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ActivityQuestions1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ActivityQuestions", "QuestionSetLatest");

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.RequestFormVariantId).HasColumnName("RequestFormVariantID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<AddressDetail>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("AddressDetail", "Address");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated).HasColumnType("datetime2(0)");

                entity.Property(e => e.Locality)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<AddressDetail1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("AddressDetail", "AddressLatest");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.LastUpdated).HasColumnType("datetime2(0)");

                entity.Property(e => e.Locality)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ChampionPostcode>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PostalCode, e.SysChangeVersion });

                entity.ToTable("ChampionPostcode", "User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ChampionPostcode1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ChampionPostcode", "UserLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<CommunicationEvent>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Communication_Event", "TableView");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Event)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.MessageId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecipientUserId).HasColumnName("RecipientUserID");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.TemplateName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CommunicationMessage>(entity =>
            {
                entity.HasKey(e => e.MessageId)
                    .HasName("PK_CommMess");

                entity.ToTable("CommunicationMessage", "Monitoring");

                entity.Property(e => e.MessageId)
                    .HasColumnName("MessageID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Comments).IsUnicode(false);
            });

            modelBuilder.Entity<Credential>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("Credential", "Group");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Credential1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Credential", "GroupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<CredentialSet>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.GroupId, e.CredentialId, e.SysChangeVersion });

                entity.ToTable("CredentialSet", "Group");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.CredentialId).HasColumnName("CredentialID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<CredentialSet1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CredentialSet", "GroupLatest");

                entity.Property(e => e.CredentialId).HasColumnName("CredentialID");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<CredentialTypes>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("CredentialTypes", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<CredentialTypes1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CredentialTypes", "LookupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<DueDateType>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("DueDateType", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<DueDateType1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DueDateType", "LookupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<EmailTemplates>(entity =>
            {
                entity.HasKey(e => e.TemplateName)
                    .HasName("PK__EmailTem__A6C2DA676F71E846");

                entity.ToTable("EmailTemplates", "Analysis");

                entity.Property(e => e.TemplateName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateLastModified).HasColumnType("datetime");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmailUnsubscribes>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EmailUnsubscribes", "Monitoring");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Event)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.MessageId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecipientUserId).HasColumnName("RecipientUserID");

                entity.Property(e => e.TemplateName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Event", "Communication");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Event1)
                    .HasColumnName("Event")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EventDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.JobId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MessageId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecipientUserId).HasColumnName("RecipientUserID");

                entity.Property(e => e.RequestId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TemplateName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EventHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EventHistory", "Communication");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Event)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EventDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.JobId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MessageId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecipientUserId).HasColumnName("RecipientUserID");

                entity.Property(e => e.RequestId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TemplateName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExpectedEmails>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ExpectedEmails", "Monitoring");

                entity.Property(e => e.Details)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DistinctMessageIds).HasColumnName("DistinctMessageIDs");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.IssueDescription).IsUnicode(false);

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.MinTimestampDelivered).HasColumnType("datetime");

                entity.Property(e => e.MinTimestampDropped).HasColumnType("datetime");

                entity.Property(e => e.MinTimestampInteraction).HasColumnType("datetime");

                entity.Property(e => e.MinTimestampProcessed).HasColumnType("datetime");

                entity.Property(e => e.RecipientEmailAddress)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.RecipientUserId).HasColumnName("RecipientUserID");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.SingleMessageId)
                    .HasColumnName("SingleMessageID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TemplateName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TimestampExpected).HasColumnType("datetime");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Feedback", "Analysis");

                entity.Property(e => e.GroupAdmin)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.GroupName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.Recipient)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Requester)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Volunteer)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Feedback1>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("Feedback", "Feedback");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FeedbackDate).HasColumnType("datetime");

                entity.Property(e => e.FeedbackRatingTypeId).HasColumnName("FeedbackRatingTypeID");

                entity.Property(e => e.RequestRoleTypeId).HasColumnName("RequestRoleTypeID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Feedback2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Feedback", "FeedbackLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.FeedbackDate).HasColumnType("datetime");

                entity.Property(e => e.FeedbackRatingTypeId).HasColumnName("FeedbackRatingTypeID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RequestRoleTypeId).HasColumnName("RequestRoleTypeID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<FeedbackFeedback>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Feedback_Feedback", "TableView");

                entity.Property(e => e.FeedbackDate).HasColumnType("datetime");

                entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");

                entity.Property(e => e.Group)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<FeedbackRating>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("FeedbackRating", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<FeedbackRating1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("FeedbackRating", "LookupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("Group", "Group");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GroupKey).HasMaxLength(450);

                entity.Property(e => e.GroupName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LinkUrl).HasColumnName("LinkURL");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Group1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Group", "GroupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.GroupKey).HasMaxLength(450);

                entity.Property(e => e.GroupName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LinkUrl).HasColumnName("LinkURL");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<GroupActivityCredentialSet>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Group_ActivityCredentialSet", "TableView");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GroupConfiguration>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GroupConfiguration", "Analysis");

                entity.Property(e => e.Group)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.GroupKey).HasMaxLength(450);

                entity.Property(e => e.LinkUrl).HasColumnName("LinkURL");

                entity.Property(e => e.ParentGroup)
                    .HasMaxLength(115)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GroupCredential>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.CredentialId, e.SysChangeVersion })
                    .HasName("PK_GROUP_CREDENTIAL");

                entity.ToTable("GroupCredential", "Group");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.CredentialId).HasColumnName("CredentialID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.CredentialTypeId).HasColumnName("CredentialTypeID");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.HowToAchieve)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.HowToAchieveCtaDestination)
                    .HasColumnName("HowToAchieve_CTA_Destination")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.WhatIsThis)
                    .HasMaxLength(400)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GroupCredential1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GroupCredential", "GroupLatest");

                entity.Property(e => e.CredentialId).HasColumnName("CredentialID");

                entity.Property(e => e.CredentialTypeId).HasColumnName("CredentialTypeID");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.HowToAchieve)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.HowToAchieveCtaDestination)
                    .HasColumnName("HowToAchieve_CTA_Destination")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.WhatIsThis)
                    .HasMaxLength(400)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GroupEmailConfiguration>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.CommunicationJobTypeId, e.SysChangeVersion });

                entity.ToTable("GroupEmailConfiguration", "Group");

                entity.Property(e => e.GroupId)
                    .HasColumnName("GroupID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CommunicationJobTypeId).HasColumnName("CommunicationJobTypeID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<GroupEmailConfiguration1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GroupEmailConfiguration", "GroupLatest");

                entity.Property(e => e.CommunicationJobTypeId).HasColumnName("CommunicationJobTypeID");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<GroupGroupCredential>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Group_GroupCredential", "TableView");

                entity.Property(e => e.Credential)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Group)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.HowToAchieve)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.WhatIsThisText)
                    .HasMaxLength(400)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GroupGroupEmailConfiguration>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Group_GroupEmailConfiguration", "TableView");

                entity.Property(e => e.CommunicationJobTypeId).HasColumnName("CommunicationJobTypeID");

                entity.Property(e => e.Group)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.GroupPs).HasColumnName("GroupPS");
            });

            modelBuilder.Entity<GroupGroupLocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Group_GroupLocation", "TableView");

                entity.Property(e => e.Group)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(215)
                    .IsUnicode(false);

                entity.Property(e => e.Postcode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GroupGroupMapDetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Group_GroupMapDetails", "TableView");

                entity.Property(e => e.Group)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.MapLocationId).HasColumnName("MapLocationID");

                entity.Property(e => e.ZoomLevel).HasColumnType("decimal(9, 6)");
            });

            modelBuilder.Entity<GroupGroupSupportActivityConfiguration>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Group_GroupSupportActivityConfiguration", "TableView");

                entity.Property(e => e.Activity).IsRequired();

                entity.Property(e => e.ActivityDetails).IsUnicode(false);

                entity.Property(e => e.Close).IsUnicode(false);

                entity.Property(e => e.Group)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Intro).IsUnicode(false);

                entity.Property(e => e.Steps).IsUnicode(false);

                entity.Property(e => e.SupportActivityInstructions).IsRequired();
            });

            modelBuilder.Entity<GroupLocation>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.LocationId, e.SysChangeVersion })
                    .HasName("PK_GROUP_LOCATION");

                entity.ToTable("GroupLocation", "Group");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<GroupLocation1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GroupLocation", "GroupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<GroupMapDetails>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.MapLocationId, e.SysChangeVersion })
                    .HasName("PK_GROUP_GROUP_MAP_DETAILS");

                entity.ToTable("GroupMapDetails", "Group");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.MapLocationId).HasColumnName("MapLocationID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ZoomLevel).HasColumnType("decimal(9, 6)");
            });

            modelBuilder.Entity<GroupMapDetails1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GroupMapDetails", "GroupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.MapLocationId).HasColumnName("MapLocationID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ZoomLevel).HasColumnType("decimal(9, 6)");
            });

            modelBuilder.Entity<GroupNewRequestNotificationStrategy>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Group_NewRequestNotificationStrategy", "TableView");

                entity.Property(e => e.Group)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");
            });

            modelBuilder.Entity<GroupSupportActivityConfiguration>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.SupportActivityId, e.SysChangeVersion })
                    .HasName("PK_GroupSupportActivityInstructions");

                entity.ToTable("GroupSupportActivityConfiguration", "Group");

                entity.Property(e => e.GroupId)
                    .HasColumnName("GroupID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SupportActivityId).HasColumnName("SupportActivityID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SupportActivityInstructionsId).HasColumnName("SupportActivityInstructionsID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<GroupSupportActivityConfiguration1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GroupSupportActivityConfiguration", "GroupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.SupportActivityId).HasColumnName("SupportActivityID");

                entity.Property(e => e.SupportActivityInstructionsId).HasColumnName("SupportActivityInstructionsID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<GroupType>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("GroupType", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<GroupType1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GroupType", "LookupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<GroupUserCredential>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Group_UserCredential", "TableView");

                entity.Property(e => e.AuthorisedByUserId).HasColumnName("AuthorisedByUserID");

                entity.Property(e => e.Credential)
                    .IsRequired()
                    .HasMaxLength(65)
                    .IsUnicode(false);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.Group)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Reference)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ValidUntil).HasColumnType("date");
            });

            modelBuilder.Entity<GroupUserRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Group_UserRole", "TableView");

                entity.Property(e => e.Group)
                    .IsRequired()
                    .HasMaxLength(115)
                    .IsUnicode(false);

                entity.Property(e => e.Role).IsRequired();

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("Job", "Request");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Details).IsUnicode(false);

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.JobStatusId).HasColumnName("JobStatusID");

                entity.Property(e => e.NotBeforeDate).HasColumnType("datetime");

                entity.Property(e => e.SupportActivityId).HasColumnName("SupportActivityID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VolunteerUserId).HasColumnName("VolunteerUserID");
            });

            modelBuilder.Entity<Job1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Job", "RequestLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Details).IsUnicode(false);

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.JobStatusId).HasColumnName("JobStatusID");

                entity.Property(e => e.NotBeforeDate).HasColumnType("datetime");

                entity.Property(e => e.SupportActivityId).HasColumnName("SupportActivityID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VolunteerUserId).HasColumnName("VolunteerUserID");
            });

            modelBuilder.Entity<JobAvailableToGroup>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.GroupId, e.SysChangeVersion });

                entity.ToTable("JobAvailableToGroup", "Request");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<JobAvailableToGroup1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("JobAvailableToGroup", "RequestLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<JobQuestions>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.QuestionId, e.SysChangeVersion });

                entity.ToTable("JobQuestions", "Request");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.Answer).IsUnicode(false);

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<JobQuestions1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("JobQuestions", "RequestLatest");

                entity.Property(e => e.Answer).IsUnicode(false);

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<JobStatus>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("JobStatus", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<JobStatus1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("JobStatus", "LookupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("Location", "Address");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Instructions).IsUnicode(false);

                entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Locality)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PostCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Location1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Location", "AddressLatest");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Instructions).IsUnicode(false);

                entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Locality)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PostCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Location2>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("Location", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Location3>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Location", "LookupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<LocationPostcodes>(entity =>
            {
                entity.HasKey(e => new { e.Location, e.Postcode })
                    .HasName("PK__Location__512B029FCCC038BB");

                entity.ToTable("LocationPostcodes", "Analysis");

                entity.Property(e => e.Location)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Postcode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Area).IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");
            });

            modelBuilder.Entity<LogRequestEvent>(entity =>
            {
                entity.HasKey(e => new { e.RequestId, e.RequestEventId, e.DateRequested, e.SysChangeVersion });

                entity.ToTable("LogRequestEvent", "Request");

                entity.Property(e => e.DateRequested).HasColumnType("datetime");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<LogRequestEvent1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LogRequestEvent", "RequestLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.DateRequested).HasColumnType("datetime");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<MisalignedLatestViews>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MisalignedLatestViews", "Maintenance");

                entity.Property(e => e.Schema).HasMaxLength(128);

                entity.Property(e => e.Table)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<MonitoringCommunicationMessage>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Monitoring_CommunicationMessage", "TableView");

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.DateLastModified).HasColumnType("datetime");

                entity.Property(e => e.MessageId)
                    .IsRequired()
                    .HasColumnName("MessageID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MinTimestamp)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RecipientUserId).HasColumnName("RecipientUserID");

                entity.Property(e => e.TemplateName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MonitoringTimestamps>(entity =>
            {
                entity.HasKey(e => new { e.Activity, e.RunId, e.Trigger, e.Start })
                    .HasName("PK__Monitori__EA1CFA03357523B9");

                entity.ToTable("MonitoringTimestamps", "Monitoring");

                entity.Property(e => e.Activity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RunId).HasColumnName("RunID");

                entity.Property(e => e.Trigger)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProcessedTo).HasColumnType("datetime");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<MonthlyStats>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.Timestamp })
                    .HasName("PK__MonthlyS__EC10CAA9CA65B25F");

                entity.ToTable("MonthlyStats", "Monitoring");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JobsCancelled)
                    .HasColumnName("Jobs_Cancelled")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.JobsCompleted)
                    .HasColumnName("Jobs_Completed")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.JobsOverdue)
                    .HasColumnName("Jobs_Overdue")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Subgroup)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TimePeriod)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TopActivities).IsUnicode(false);

                entity.Property(e => e.YotiIds).HasColumnName("YotiIDs");
            });

            modelBuilder.Entity<NewRequestNotificationStrategy>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.SysChangeVersion });

                entity.ToTable("NewRequestNotificationStrategy", "Group");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<NewRequestNotificationStrategy1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("NewRequestNotificationStrategy", "GroupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<NewRequestNotificationStrategy2>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("NewRequestNotificationStrategy", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<NewRequestNotificationStrategy3>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("NewRequestNotificationStrategy", "LookupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Postcode>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("Postcode", "Address");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FriendlyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Postcode1)
                    .HasColumnName("Postcode")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Postcode1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Postcode", "AddressLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.FriendlyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdated).HasColumnType("datetime2(0)");

                entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Postcode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<PostcodeLookup>(entity =>
            {
                entity.HasKey(e => e.PostcodeDistrict)
                    .HasName("PK__Postcode__6235C9C1310092D5");

                entity.ToTable("PostcodeLookup", "Analysis");

                entity.Property(e => e.PostcodeDistrict)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Locality).IsUnicode(false);

                entity.Property(e => e.Region)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Town)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PreComputedNearestPostcodes>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("PreComputedNearestPostcodes", "Address");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Postcode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<PreComputedNearestPostcodes1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PreComputedNearestPostcodes", "AddressLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Postcode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("Question", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Question1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Question", "LookupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Question2>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("Question", "QuestionSet");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.AdditionalData).IsUnicode(false);

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Question3>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Question", "QuestionSetLatest");

                entity.Property(e => e.AdditionalData).IsUnicode(false);

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<QuestionSetActivityQuestions>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("QuestionSet_ActivityQuestions", "TableView");

                entity.Property(e => e.Activity).IsRequired();

                entity.Property(e => e.AddtionalData).IsUnicode(false);

                entity.Property(e => e.QuestionWording)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RequestFormVariant).IsRequired();
            });

            modelBuilder.Entity<QuestionType>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("QuestionType", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<QuestionType1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("QuestionType", "LookupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RegistrationFormVariant>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("RegistrationFormVariant", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RegistrationFormVariant1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("RegistrationFormVariant", "LookupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RegistrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RegistrationStep, e.SysChangeVersion });

                entity.ToTable("RegistrationHistory", "User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateCompleted).HasColumnType("datetime");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RegistrationHistory1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("RegistrationHistory", "UserLatest");

                entity.Property(e => e.DateCompleted).HasColumnType("datetime");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<RegistrationJourney>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.Source, e.SysChangeVersion });

                entity.ToTable("RegistrationJourney", "Website");

                entity.Property(e => e.Source)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RegistrationJourney1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("RegistrationJourney", "WebsiteLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("Request", "Request");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateRequested).HasColumnType("datetime");

                entity.Property(e => e.OrganisationName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OtherDetails).IsUnicode(false);

                entity.Property(e => e.PersonIdRecipient).HasColumnName("PersonID_Recipient");

                entity.Property(e => e.PersonIdRequester).HasColumnName("PersonID_Requester");

                entity.Property(e => e.PostCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpecialCommunicationNeeds).IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Request1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Request", "RequestLatest");

                entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.DateRequested).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OrganisationName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OtherDetails).IsUnicode(false);

                entity.Property(e => e.PersonIdRecipient).HasColumnName("PersonID_Recipient");

                entity.Property(e => e.PersonIdRequester).HasColumnName("PersonID_Requester");

                entity.Property(e => e.PostCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpecialCommunicationNeeds).IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RequestAnonymisation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("RequestAnonymisation", "Analysis");

                entity.Property(e => e.Anonymisation)
                    .IsRequired()
                    .HasMaxLength(28)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RequestEvent>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("RequestEvent", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RequestEvent1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("RequestEvent", "LookupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RequestFormStage>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("RequestFormStage", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RequestFormStage1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("RequestFormStage", "LookupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RequestFormVariant>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("RequestFormVariant", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RequestFormVariant1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("RequestFormVariant", "LookupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RequestHelpFormVariant>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("RequestHelpFormVariant", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RequestHelpFormVariant1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("RequestHelpFormVariant", "LookupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RequestHelpJourney>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.Source, e.SysChangeVersion });

                entity.ToTable("RequestHelpJourney", "Website");

                entity.Property(e => e.Source)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RequestHelpJourney1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("RequestHelpJourney", "WebsiteLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RequestJob>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Request_Job", "TableView");

                entity.Property(e => e.Activity).IsRequired();

                entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");

                entity.Property(e => e.DateDue).HasColumnType("datetime");

                entity.Property(e => e.DateRequested).HasColumnType("datetime");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.Postcode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ReferringGroup)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReferringGroupId).HasColumnName("ReferringGroupID");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.VolunteerUserId).HasColumnName("VolunteerUserID");
            });

            modelBuilder.Entity<RequestJobAvailableToGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Request_JobAvailableToGroup", "TableView");

                entity.Property(e => e.Group)
                    .IsRequired()
                    .HasMaxLength(115)
                    .IsUnicode(false);

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");
            });

            modelBuilder.Entity<RequestJobQuestions>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Request_JobQuestions", "TableView");

                entity.Property(e => e.Answer).IsUnicode(false);

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");
            });

            modelBuilder.Entity<RequestJobStatus>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.DateCreated, e.JobStatusId, e.SysChangeVersion });

                entity.ToTable("RequestJobStatus", "Request");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.JobStatusId).HasColumnName("JobStatusID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VolunteerUserId).HasColumnName("VolunteerUserID");
            });

            modelBuilder.Entity<RequestJobStatus1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("RequestJobStatus", "RequestLatest");

                entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.JobStatusId).HasColumnName("JobStatusID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VolunteerUserId).HasColumnName("VolunteerUserID");
            });

            modelBuilder.Entity<RequestLogRequestEvent>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Request_LogRequestEvent", "TableView");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.ReferringGroup)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<RequestRequest>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Request_Request", "TableView");

                entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");

                entity.Property(e => e.DateRequested).HasColumnType("datetime");

                entity.Property(e => e.OrganisationName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PersonIdRecipient).HasColumnName("PersonID_Recipient");

                entity.Property(e => e.PersonIdRequester).HasColumnName("PersonID_Requester");

                entity.Property(e => e.Postcode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ReferringGroup)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReferringGroupId).HasColumnName("ReferringGroupID");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");
            });

            modelBuilder.Entity<RequestRoles>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("RequestRoles", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RequestRoles1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("RequestRoles", "LookupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RequestShift>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Request_Shift", "TableView");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Group)
                    .IsRequired()
                    .HasMaxLength(115)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Postcode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<RequestSubmission>(entity =>
            {
                entity.HasKey(e => new { e.RequestId, e.SysChangeVersion });

                entity.ToTable("RequestSubmission", "Request");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FreqencyId).HasColumnName("FreqencyID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RequestSubmission1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("RequestSubmission", "RequestLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.FreqencyId).HasColumnName("FreqencyID");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RequestType>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("RequestType", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RequestType1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("RequestType", "LookupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RequestorType>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("RequestorType", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RequestorType1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("RequestorType", "LookupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("Role", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Role1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Role", "LookupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<SecurityConfiguration>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.SysChangeVersion });

                entity.ToTable("SecurityConfiguration", "Group");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<SecurityConfiguration1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SecurityConfiguration", "GroupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.HasKey(e => new { e.RequestId, e.SysChangeVersion });

                entity.ToTable("Shift", "Request");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Shift1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Shift", "RequestLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<SupportActivities>(entity =>
            {
                entity.HasKey(e => new { e.RequestId, e.ActivityId, e.SysChangeVersion });

                entity.ToTable("SupportActivities", "Request");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<SupportActivities1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SupportActivities", "RequestLatest");

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<SupportActivity>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("SupportActivity", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<SupportActivity1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SupportActivity", "LookupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<SupportActivity2>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ActivityId, e.SysChangeVersion });

                entity.ToTable("SupportActivity", "User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<SupportActivity3>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SupportActivity", "UserLatest");

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<SupportActivityInstructions>(entity =>
            {
                entity.HasKey(e => new { e.SupportActivityInstructionsId, e.SysChangeVersion });

                entity.ToTable("SupportActivityInstructions", "Group");

                entity.Property(e => e.SupportActivityInstructionsId)
                    .HasColumnName("SupportActivityInstructionsID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Instructions).IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<SupportActivityInstructions1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SupportActivityInstructions", "GroupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Instructions).IsUnicode(false);

                entity.Property(e => e.SupportActivityInstructionsId).HasColumnName("SupportActivityInstructionsID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<SupportActivityInstructions2>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("SupportActivityInstructions", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<SupportActivityInstructions3>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SupportActivityInstructions", "LookupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<SuspectTestRequests>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SuspectTestRequests", "Maintenance");

                entity.Property(e => e.Answer).IsUnicode(false);

                entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");

                entity.Property(e => e.DateRequested).HasColumnType("datetime");

                entity.Property(e => e.PostCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ReferringGroup)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.Requester)
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TargetGroup>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("TargetGroup", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TargetGroup1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TargetGroup", "LookupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TestRequests>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__TestRequ__33A8519AEEE3E890");

                entity.ToTable("TestRequests", "Maintenance");

                entity.Property(e => e.RequestId)
                    .HasColumnName("RequestID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Details).IsUnicode(false);
            });

            modelBuilder.Entity<UpdateHistory>(entity =>
            {
                entity.HasKey(e => new { e.RequestId, e.JobId, e.DateCreated, e.FieldChanged, e.SysChangeVersion })
                    .HasName("PK_UpddateHistory");

                entity.ToTable("UpdateHistory", "Request");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.FieldChanged).IsUnicode(false);

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NewValue).IsUnicode(false);

                entity.Property(e => e.OldValue).IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("User", "User");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FirebaseUid)
                    .HasColumnName("FirebaseUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HmscontactConsent).HasColumnName("HMSContactConsent");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<User1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("User", "UserLatest");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.FirebaseUid)
                    .HasColumnName("FirebaseUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HmscontactConsent).HasColumnName("HMSContactConsent");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<UserCredential>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.UserId, e.CredentialId, e.DateAdded, e.SysChangeVersion });

                entity.ToTable("UserCredential", "Group");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CredentialId).HasColumnName("CredentialID");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.AuthorisedByUserId).HasColumnName("AuthorisedByUserID");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Reference)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ValidUntil).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserCredential1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("UserCredential", "GroupLatest");

                entity.Property(e => e.AuthorisedByUserId).HasColumnName("AuthorisedByUserID");

                entity.Property(e => e.CredentialId).HasColumnName("CredentialID");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Reference)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ValidUntil).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId, e.GroupId, e.SysChangeVersion });

                entity.ToTable("UserRole", "Group");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<UserRole1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("UserRole", "GroupLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<UserRoleAudit>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SysChangeVersion });

                entity.ToTable("UserRoleAudit", "Group");

                entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");

                entity.Property(e => e.ActionId).HasColumnName("ActionID");

                entity.Property(e => e.AuthorisedByUserId).HasColumnName("AuthorisedByUserID");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateRequested).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<UserRoleAudit1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("UserRoleAudit", "GroupLatest");

                entity.Property(e => e.ActionId).HasColumnName("ActionID");

                entity.Property(e => e.AuthorisedByUserId).HasColumnName("AuthorisedByUserID");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.DateRequested).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.SysChangeOperation)
                    .IsRequired()
                    .HasColumnName("SYS_CHANGE_OPERATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<UserSupportActivity>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("User_SupportActivity", "TableView");

                entity.Property(e => e.Activity).IsRequired();

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<UserUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("User_User", "TableView");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Postcode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ReferringGroup)
                    .IsRequired()
                    .HasMaxLength(115)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<VerificationAttempt>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VerificationAttempt", "Verification");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfAttempt)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.YotiRememberMeId)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VerificationAttempt1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VerificationAttempt", "VerificationLatest");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.DateOfAttempt)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.YotiRememberMeId)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VerificationAttempt2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VerificationAttempt2", "Verification");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfAttempt)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.YotiRememberMeId)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VerificationVerificationAttempt>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Verification_VerificationAttempt", "TableView");

                entity.Property(e => e.AttemptDate).HasColumnType("datetime");

                entity.Property(e => e.CredentialAddedDate).HasColumnType("datetime");

                entity.Property(e => e.Dobmatch).HasColumnName("DOBMatch");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.YotiRememberMeId)
                    .HasColumnName("YotiRememberMeID")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewDroppedEmailAddresses>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewDroppedEmailAddresses", "Monitoring");

                entity.Property(e => e.RecipientUserId).HasColumnName("RecipientUserID");
            });

            modelBuilder.Entity<ViewEmailMonitoring>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewEmailMonitoring", "Monitoring");

                entity.Property(e => e.CountLast30Days).HasColumnName("Count_Last_30_Days");

                entity.Property(e => e.CountPrevious30Days).HasColumnName("Count_Previous_30_Days");

                entity.Property(e => e.IssueDescription).IsUnicode(false);

                entity.Property(e => e.Last30Days)
                    .HasColumnName("%_Last_30_Days")
                    .HasColumnType("decimal(18, 1)");

                entity.Property(e => e.Previous30Days)
                    .HasColumnName("%_Previous_30_Days")
                    .HasColumnType("decimal(18, 1)");

                entity.Property(e => e.TemplateName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewEmailMonitoringDaily>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewEmailMonitoring_Daily", "Monitoring");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.IssueDescription).IsUnicode(false);

                entity.Property(e => e.TemplateName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e._)
                    .HasColumnName("%")
                    .HasColumnType("decimal(18, 1)");
            });

            modelBuilder.Entity<ViewEmailTemplateUnsubscribes>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewEmailTemplateUnsubscribes", "Analysis");

                entity.Property(e => e.DateFrom)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateTo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Event)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RecipientUserId).HasColumnName("RecipientUserID");

                entity.Property(e => e.TemplateName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewJobStatusTimestamps>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewJobStatusTimestamps", "Analysis");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.JobStatusId).HasColumnName("JobStatusID");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.SupportActivityId).HasColumnName("SupportActivityID");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.VolunteerUserId).HasColumnName("VolunteerUserID");
            });

            modelBuilder.Entity<ViewMonitoringTimestamps>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewMonitoringTimestamps", "Monitoring");

                entity.Property(e => e.Activity)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProcessedTo).HasColumnType("datetime");

                entity.Property(e => e.RunId).HasColumnName("RunID");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.Trigger)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewMonthlyStats>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewMonthlyStats", "Analysis");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JobsCancelled)
                    .HasColumnName("Jobs_Cancelled")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.JobsCompleted)
                    .HasColumnName("Jobs_Completed")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.JobsOverdue)
                    .HasColumnName("Jobs_Overdue")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Subgroup)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TimePeriod)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.TopActivities).IsUnicode(false);

                entity.Property(e => e.YotiIds).HasColumnName("YotiIDs");
            });

            modelBuilder.Entity<ViewMonthlyStatsMonthToDate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewMonthlyStats_MonthToDate", "Analysis");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JobsCancelled)
                    .HasColumnName("Jobs_Cancelled")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.JobsCompleted)
                    .HasColumnName("Jobs_Completed")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.JobsOverdue)
                    .HasColumnName("Jobs_Overdue")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Subgroup)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TimePeriod)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TopActivities).IsUnicode(false);

                entity.Property(e => e.YotiIds).HasColumnName("YotiIDs");
            });

            modelBuilder.Entity<ViewMonthlyStatsRecentActivity>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewMonthlyStats_RecentActivity", "Analysis");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JobsCancelled)
                    .HasColumnName("Jobs_Cancelled")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.JobsCompleted)
                    .HasColumnName("Jobs_Completed")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.JobsOverdue)
                    .HasColumnName("Jobs_Overdue")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasMaxLength(58);

                entity.Property(e => e.Subgroup)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TimePeriod)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TopActivities).IsUnicode(false);

                entity.Property(e => e.YotiIds).HasColumnName("YotiIDs");
            });

            modelBuilder.Entity<ViewRecentActivity>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewRecentActivity", "Analysis");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NewUsersFromLandingPage)
                    .HasColumnName("NewUsers(FromLandingPage)")
                    .HasMaxLength(27)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewRequestVolume>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewRequestVolume", "Analysis");

                entity.Property(e => e.AvgMinsToFill).HasColumnType("numeric(38, 0)");

                entity.Property(e => e.AvgTimeTakenToFill)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateRequested).HasColumnType("datetime");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.ParentGroup)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReferringGroup)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.WeekCommencing).HasColumnType("date");
            });

            modelBuilder.Entity<ViewShiftFilling>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewShiftFilling", "Analysis");

                entity.Property(e => e.AcceptedDone).HasColumnName("Accepted/Done");

                entity.Property(e => e.DateRequested).HasColumnType("datetime");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MaxMinsToAccept)
                    .HasColumnName("MAX_MinsToAccept")
                    .HasColumnType("numeric(17, 0)");

                entity.Property(e => e.MinMinsToAccept)
                    .HasColumnName("MIN_MinsToAccept")
                    .HasColumnType("numeric(17, 0)");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ViewTimeTaken>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewTimeTaken", "Analysis");

                entity.Property(e => e.DateAccepted).HasColumnType("datetime");

                entity.Property(e => e.DateApproved).HasColumnType("datetime");

                entity.Property(e => e.DateCancelled).HasColumnType("datetime");

                entity.Property(e => e.DateCompleted).HasColumnType("datetime");

                entity.Property(e => e.DateRequested).HasColumnType("datetime");

                entity.Property(e => e.HrsAcceptToComplete).HasColumnType("numeric(17, 0)");

                entity.Property(e => e.HrsOpenToAccept).HasColumnType("numeric(17, 0)");

                entity.Property(e => e.HrsRequestToApprove).HasColumnType("numeric(17, 0)");

                entity.Property(e => e.HrsRequestToCancel).HasColumnType("numeric(17, 0)");

                entity.Property(e => e.JobId).HasColumnName("JobID");
            });

            modelBuilder.Entity<WebsiteRegistrationJourney>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Website_RegistrationJourney", "TableView");

                entity.Property(e => e.Group)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.RegistrationFormVariant).IsRequired();

                entity.Property(e => e.Source)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WebsiteRequestHelpJourney>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Website_RequestHelpJourney", "TableView");

                entity.Property(e => e.Group)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.RequestHelpFormVariant).IsRequired();

                entity.Property(e => e.Source)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QuicksightRoles>(entity =>
            {
                entity.ToTable("Role", "Quicksight");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .ValueGeneratedOnAdd()
                    .IsUnicode(false);

                entity.SetQuickSightRolesData();
            });

            modelBuilder.Entity<QuicksightRoleGroups>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.GroupId });

                entity.ToTable("RoleGroups", "Quicksight");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleGroups)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleGroups_RoleID");
            });

            modelBuilder.Entity<QuicksightUsers>(entity =>
            {
                entity.ToTable("Users", "Quicksight");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_RoleID");
            });
        }
    }
}
