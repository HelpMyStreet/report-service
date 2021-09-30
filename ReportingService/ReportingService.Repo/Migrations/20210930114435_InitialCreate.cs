using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportingService.Repo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Group");

            migrationBuilder.EnsureSchema(
                name: "QuestionSet");

            migrationBuilder.EnsureSchema(
                name: "Address");

            migrationBuilder.EnsureSchema(
                name: "User");

            migrationBuilder.EnsureSchema(
                name: "Monitoring");

            migrationBuilder.EnsureSchema(
                name: "Lookup");

            migrationBuilder.EnsureSchema(
                name: "Analysis");

            migrationBuilder.EnsureSchema(
                name: "Communication");

            migrationBuilder.EnsureSchema(
                name: "Feedback");

            migrationBuilder.EnsureSchema(
                name: "Request");

            migrationBuilder.EnsureSchema(
                name: "Website");

            migrationBuilder.EnsureSchema(
                name: "Maintenance");

            migrationBuilder.EnsureSchema(
                name: "Verification");

            migrationBuilder.CreateTable(
                name: "AddressDetail",
                schema: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    PostcodeId = table.Column<int>(nullable: true),
                    AddressLine1 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    AddressLine2 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    AddressLine3 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Locality = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressDetail", x => new { x.Id, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    ShortName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    AddressLine1 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    AddressLine2 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    AddressLine3 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Locality = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    PostCode = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9, 6)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(9, 6)", nullable: true),
                    Instructions = table.Column<string>(unicode: false, nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => new { x.Id, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "Postcode",
                schema: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Postcode = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(0)", nullable: true, defaultValueSql: "(getutcdate())"),
                    Latitude = table.Column<decimal>(type: "decimal(9, 6)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(9, 6)", nullable: true),
                    FriendlyName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postcode", x => new { x.Id, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "PreComputedNearestPostcodes",
                schema: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Postcode = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    CompressedNearestPostcodes = table.Column<byte[]>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreComputedNearestPostcodes", x => new { x.Id, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                schema: "Analysis",
                columns: table => new
                {
                    TemplateName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    GroupName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    DateLastModified = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EmailTem__A6C2DA676F71E846", x => x.TemplateName);
                });

            migrationBuilder.CreateTable(
                name: "LocationPostcodes",
                schema: "Analysis",
                columns: table => new
                {
                    Location = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    Postcode = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Area = table.Column<string>(unicode: false, nullable: true),
                    GroupID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Location__512B029FCCC038BB", x => new { x.Location, x.Postcode });
                });

            migrationBuilder.CreateTable(
                name: "PostcodeLookup",
                schema: "Analysis",
                columns: table => new
                {
                    PostcodeDistrict = table.Column<string>(unicode: false, maxLength: 4, nullable: false),
                    Locality = table.Column<string>(unicode: false, nullable: true),
                    Town = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    Region = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    ActivePostcodes = table.Column<int>(nullable: true),
                    Country = table.Column<string>(unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Postcode__6235C9C1310092D5", x => x.PostcodeDistrict);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                schema: "Communication",
                columns: table => new
                {
                    RecipientUserID = table.Column<int>(nullable: true),
                    TemplateName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Event = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    EventDate = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    MessageId = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    GroupId = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    JobId = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    RequestId = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "EventHistory",
                schema: "Communication",
                columns: table => new
                {
                    RecipientUserID = table.Column<int>(nullable: true),
                    TemplateName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Event = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    EventDate = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    MessageId = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    GroupId = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    JobId = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    RequestId = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                schema: "Feedback",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    FeedbackDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    JobId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    RequestRoleTypeID = table.Column<byte>(nullable: true),
                    FeedbackRatingTypeID = table.Column<byte>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "ActivityCredentialSet",
                schema: "Group",
                columns: table => new
                {
                    GroupID = table.Column<int>(nullable: false),
                    ActivityID = table.Column<int>(nullable: false),
                    CredentialSetID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    DisplayOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityCredentialSet", x => new { x.GroupID, x.ActivityID, x.CredentialSetID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "Credential",
                schema: "Group",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credential", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "CredentialSet",
                schema: "Group",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    GroupID = table.Column<int>(nullable: false),
                    CredentialID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CredentialSet", x => new { x.ID, x.GroupID, x.CredentialID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    GroupName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ParentGroupId = table.Column<int>(nullable: true),
                    GroupKey = table.Column<string>(maxLength: 450, nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    ShiftsEnabled = table.Column<bool>(nullable: true),
                    HomepageEnabled = table.Column<bool>(nullable: true),
                    TasksEnabled = table.Column<bool>(nullable: true),
                    GeographicName = table.Column<string>(nullable: true),
                    GroupType = table.Column<byte>(nullable: true),
                    FriendlyName = table.Column<string>(nullable: true),
                    LinkURL = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    JoinGroupPopUpDetail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => new { x.Id, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "GroupCredential",
                schema: "Group",
                columns: table => new
                {
                    GroupID = table.Column<int>(nullable: false),
                    CredentialID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    CredentialTypeID = table.Column<byte>(nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    HowToAchieve = table.Column<string>(unicode: false, maxLength: 400, nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true),
                    CredentialVerifiedById = table.Column<byte>(nullable: true),
                    HowToAchieve_CTA_Destination = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    WhatIsThis = table.Column<string>(unicode: false, maxLength: 400, nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GROUP_CREDENTIAL", x => new { x.GroupID, x.CredentialID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "GroupEmailConfiguration",
                schema: "Group",
                columns: table => new
                {
                    GroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunicationJobTypeID = table.Column<byte>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Configuration = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupEmailConfiguration", x => new { x.GroupID, x.CommunicationJobTypeID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "GroupLocation",
                schema: "Group",
                columns: table => new
                {
                    GroupID = table.Column<int>(nullable: false),
                    LocationID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GROUP_LOCATION", x => new { x.GroupID, x.LocationID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "GroupMapDetails",
                schema: "Group",
                columns: table => new
                {
                    GroupID = table.Column<int>(nullable: false),
                    MapLocationID = table.Column<byte>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(9, 6)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(9, 6)", nullable: true),
                    ZoomLevel = table.Column<decimal>(type: "decimal(9, 6)", nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GROUP_GROUP_MAP_DETAILS", x => new { x.GroupID, x.MapLocationID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "GroupSupportActivityConfiguration",
                schema: "Group",
                columns: table => new
                {
                    GroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupportActivityID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    SupportActivityInstructionsID = table.Column<short>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    Radius = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupSupportActivityInstructions", x => new { x.GroupID, x.SupportActivityID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "NewRequestNotificationStrategy",
                schema: "Group",
                columns: table => new
                {
                    GroupID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    NewRequestNotificationStrategyId = table.Column<byte>(nullable: true),
                    MaxVolunteer = table.Column<int>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewRequestNotificationStrategy", x => new { x.GroupID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "SecurityConfiguration",
                schema: "Group",
                columns: table => new
                {
                    GroupID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    AllowAutonomousJoinersAndLeavers = table.Column<bool>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityConfiguration", x => new { x.GroupID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "SupportActivityInstructions",
                schema: "Group",
                columns: table => new
                {
                    SupportActivityInstructionsID = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Instructions = table.Column<string>(unicode: false, nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportActivityInstructions", x => new { x.SupportActivityInstructionsID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "UserCredential",
                schema: "Group",
                columns: table => new
                {
                    GroupID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    CredentialID = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "datetime", nullable: true),
                    AuthorisedByUserID = table.Column<int>(nullable: true),
                    Reference = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Notes = table.Column<string>(unicode: false, nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCredential", x => new { x.GroupID, x.UserID, x.CredentialID, x.DateAdded, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "Group",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false),
                    GroupID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserID, x.RoleID, x.GroupID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "UserRoleAudit",
                schema: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    AuthorisedByUserID = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: true),
                    GroupID = table.Column<int>(nullable: true),
                    RoleID = table.Column<int>(nullable: true),
                    DateRequested = table.Column<DateTime>(type: "datetime", nullable: true),
                    ActionID = table.Column<byte>(nullable: true),
                    Success = table.Column<bool>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleAudit", x => new { x.Id, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "CredentialTypes",
                schema: "Lookup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CredentialTypes", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "DueDateType",
                schema: "Lookup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DueDateType", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "FeedbackRating",
                schema: "Lookup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackRating", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "GroupType",
                schema: "Lookup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupType", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "JobStatus",
                schema: "Lookup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobStatus", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "Lookup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "NewRequestNotificationStrategy",
                schema: "Lookup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewRequestNotificationStrategy", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "Question",
                schema: "Lookup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "QuestionType",
                schema: "Lookup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionType", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "RegistrationFormVariant",
                schema: "Lookup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationFormVariant", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "RequestEvent",
                schema: "Lookup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestEvent", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "RequestFormStage",
                schema: "Lookup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestFormStage", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "RequestFormVariant",
                schema: "Lookup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestFormVariant", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "RequestHelpFormVariant",
                schema: "Lookup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestHelpFormVariant", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "RequestorType",
                schema: "Lookup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestorType", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "RequestRoles",
                schema: "Lookup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestRoles", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "RequestType",
                schema: "Lookup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestType", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "Lookup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    IsAdmin = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "SupportActivity",
                schema: "Lookup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportActivity", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "SupportActivityInstructions",
                schema: "Lookup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportActivityInstructions", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "TargetGroup",
                schema: "Lookup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetGroup", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "TestRequests",
                schema: "Maintenance",
                columns: table => new
                {
                    RequestID = table.Column<int>(nullable: false),
                    Details = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TestRequ__33A8519AEEE3E890", x => x.RequestID);
                });

            migrationBuilder.CreateTable(
                name: "CommunicationMessage",
                schema: "Monitoring",
                columns: table => new
                {
                    MessageID = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    MatchedToExpectedEmail = table.Column<bool>(nullable: true),
                    Comments = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommMess", x => x.MessageID);
                });

            migrationBuilder.CreateTable(
                name: "EmailUnsubscribes",
                schema: "Monitoring",
                columns: table => new
                {
                    RecipientUserID = table.Column<int>(nullable: true),
                    TemplateName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Event = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    EventDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: true),
                    MessageId = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    GroupId = table.Column<int>(nullable: true),
                    JobId = table.Column<int>(nullable: true),
                    RequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ExpectedEmails",
                schema: "Monitoring",
                columns: table => new
                {
                    RecipientUserID = table.Column<int>(nullable: true),
                    RecipientEmailAddress = table.Column<byte[]>(fixedLength: true, maxLength: 1, nullable: true),
                    TemplateName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    TimestampExpected = table.Column<DateTime>(type: "datetime", nullable: true),
                    GroupID = table.Column<int>(nullable: true),
                    JobID = table.Column<int>(nullable: true),
                    RequestID = table.Column<int>(nullable: true),
                    Details = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Unsubscribed = table.Column<bool>(nullable: true),
                    MinTimestampProcessed = table.Column<DateTime>(type: "datetime", nullable: true),
                    MinTimestampDelivered = table.Column<DateTime>(type: "datetime", nullable: true),
                    MinTimestampDropped = table.Column<DateTime>(type: "datetime", nullable: true),
                    DistinctMessageIDs = table.Column<int>(nullable: true),
                    Issue = table.Column<bool>(nullable: true),
                    IssueDescription = table.Column<string>(unicode: false, nullable: true),
                    EmailsExpected = table.Column<int>(nullable: true),
                    JoinUpdated = table.Column<bool>(nullable: true),
                    RecipientOrder = table.Column<int>(nullable: true),
                    MinTimestampInteraction = table.Column<DateTime>(type: "datetime", nullable: true),
                    SingleMessageID = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MonitoringTimestamps",
                schema: "Monitoring",
                columns: table => new
                {
                    Activity = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    RunID = table.Column<int>(nullable: false),
                    Trigger = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Start = table.Column<bool>(nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowsAffected = table.Column<int>(nullable: true),
                    ProcessedTo = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Monitori__EA1CFA03357523B9", x => new { x.Activity, x.RunID, x.Trigger, x.Start });
                });

            migrationBuilder.CreateTable(
                name: "MonthlyStats",
                schema: "Monitoring",
                columns: table => new
                {
                    GroupID = table.Column<int>(nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    TimePeriod = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    GroupName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Subgroup = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Members = table.Column<int>(nullable: true),
                    Admins = table.Column<int>(nullable: true),
                    ActiveVols = table.Column<int>(nullable: true),
                    NonMemberVols = table.Column<int>(nullable: true),
                    YotiIDs = table.Column<int>(nullable: true),
                    OtherCredentials = table.Column<int>(nullable: true),
                    Requests = table.Column<int>(nullable: true),
                    Jobs = table.Column<int>(nullable: true),
                    Jobs_Cancelled = table.Column<string>(unicode: false, maxLength: 6, nullable: true),
                    Jobs_Completed = table.Column<string>(unicode: false, maxLength: 6, nullable: true),
                    Jobs_Overdue = table.Column<string>(unicode: false, maxLength: 6, nullable: true),
                    TopActivities = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MonthlyS__EC10CAA9CA65B25F", x => new { x.GroupID, x.Timestamp });
                });

            migrationBuilder.CreateTable(
                name: "ActivityQuestions",
                schema: "QuestionSet",
                columns: table => new
                {
                    RequestFormVariantID = table.Column<int>(nullable: false),
                    ActivityID = table.Column<int>(nullable: false),
                    QuestionID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: true),
                    Required = table.Column<int>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityQuestions", x => new { x.RequestFormVariantID, x.ActivityID, x.QuestionID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "Question",
                schema: "QuestionSet",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    QuestionType = table.Column<byte>(nullable: true),
                    Required = table.Column<bool>(nullable: true),
                    AdditionalData = table.Column<string>(unicode: false, nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "Job",
                schema: "Request",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    RequestId = table.Column<int>(nullable: true),
                    SupportActivityID = table.Column<byte>(nullable: true),
                    Details = table.Column<string>(unicode: false, nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsHealthCritical = table.Column<bool>(nullable: true),
                    JobStatusID = table.Column<byte>(nullable: true),
                    VolunteerUserID = table.Column<int>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    DueDateTypeId = table.Column<byte>(nullable: true),
                    Reference = table.Column<string>(nullable: true),
                    NotBeforeDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "JobAvailableToGroup",
                schema: "Request",
                columns: table => new
                {
                    JobID = table.Column<int>(nullable: false),
                    GroupID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobAvailableToGroup", x => new { x.JobID, x.GroupID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "JobQuestions",
                schema: "Request",
                columns: table => new
                {
                    JobID = table.Column<int>(nullable: false),
                    QuestionID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Answer = table.Column<string>(unicode: false, nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobQuestions", x => new { x.JobID, x.QuestionID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "LogRequestEvent",
                schema: "Request",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime", nullable: false),
                    RequestEventId = table.Column<byte>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    JobId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogRequestEvent", x => new { x.RequestId, x.RequestEventId, x.DateRequested, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "Request",
                schema: "Request",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    PostCode = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    DateRequested = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsFulfillable = table.Column<bool>(nullable: false),
                    CommunicationSent = table.Column<bool>(nullable: true),
                    FulfillableStatus = table.Column<byte>(nullable: true),
                    ForRequestor = table.Column<bool>(nullable: true),
                    OtherDetails = table.Column<string>(unicode: false, nullable: true),
                    PersonID_Recipient = table.Column<int>(nullable: true),
                    PersonID_Requester = table.Column<int>(nullable: true),
                    ReadPrivacyNotice = table.Column<bool>(nullable: true),
                    AcceptedTerms = table.Column<bool>(nullable: true),
                    SpecialCommunicationNeeds = table.Column<string>(unicode: false, nullable: true),
                    CreatedByUserID = table.Column<int>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    RequestorType = table.Column<byte>(nullable: true),
                    OrganisationName = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    ReferringGroupId = table.Column<int>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    Archive = table.Column<bool>(nullable: true),
                    Guid = table.Column<Guid>(nullable: true),
                    RequestorDefinedByGroup = table.Column<bool>(nullable: true),
                    RequestType = table.Column<byte>(nullable: true),
                    SuppressRecipientPersonalDetail = table.Column<bool>(nullable: true),
                    MultiVolunteer = table.Column<bool>(nullable: true),
                    Repeat = table.Column<bool>(nullable: true),
                    ParentGuid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "RequestJobStatus",
                schema: "Request",
                columns: table => new
                {
                    JobID = table.Column<int>(nullable: false),
                    JobStatusID = table.Column<byte>(nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    VolunteerUserID = table.Column<int>(nullable: true),
                    CreatedByUserID = table.Column<int>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestJobStatus", x => new { x.JobID, x.DateCreated, x.JobStatusID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "RequestSubmission",
                schema: "Request",
                columns: table => new
                {
                    RequestID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    FreqencyID = table.Column<byte>(nullable: true),
                    NumberOfRepeats = table.Column<int>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestSubmission", x => new { x.RequestID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                schema: "Request",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShiftLength = table.Column<int>(nullable: true),
                    LocationId = table.Column<int>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => new { x.RequestId, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "SupportActivities",
                schema: "Request",
                columns: table => new
                {
                    RequestID = table.Column<int>(nullable: false),
                    ActivityID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportActivities", x => new { x.RequestID, x.ActivityID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "UpdateHistory",
                schema: "Request",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false),
                    JobId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    FieldChanged = table.Column<string>(unicode: false, nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    CreatedByUserID = table.Column<int>(nullable: true),
                    OldValue = table.Column<string>(unicode: false, nullable: true),
                    NewValue = table.Column<string>(unicode: false, nullable: true),
                    QuestionId = table.Column<int>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpddateHistory", x => new { x.RequestId, x.JobId, x.DateCreated, x.FieldChanged, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "ChampionPostcode",
                schema: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    PostalCode = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionPostcode", x => new { x.UserID, x.PostalCode, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "RegistrationHistory",
                schema: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    RegistrationStep = table.Column<byte>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationHistory", x => new { x.UserID, x.RegistrationStep, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "SupportActivity",
                schema: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    ActivityID = table.Column<byte>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportActivity", x => new { x.UserID, x.ActivityID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    FirebaseUID = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    EmailSharingConsent = table.Column<bool>(nullable: true),
                    MobileSharingConsent = table.Column<bool>(nullable: true),
                    OtherPhoneSharingConsent = table.Column<bool>(nullable: true),
                    HMSContactConsent = table.Column<bool>(nullable: true),
                    IsVolunteer = table.Column<bool>(nullable: true),
                    IsVerified = table.Column<bool>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    StreetChampionRoleUnderstood = table.Column<bool>(nullable: true),
                    SupportVolunteersByPhone = table.Column<bool>(nullable: true),
                    SupportRadiusMiles = table.Column<double>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    ReferringGroupId = table.Column<int>(nullable: true),
                    Source = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "VerificationAttempt",
                schema: "Verification",
                columns: table => new
                {
                    DateOfAttempt = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    YotiRememberMeId = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Verified = table.Column<bool>(nullable: true),
                    DobMatch = table.Column<bool>(nullable: true),
                    AgeMatch = table.Column<bool>(nullable: true),
                    NotPreviouslyVerified = table.Column<bool>(nullable: true),
                    UserServiceUpdated = table.Column<bool>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "VerificationAttempt2",
                schema: "Verification",
                columns: table => new
                {
                    DateOfAttempt = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    YotiRememberMeId = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Verified = table.Column<bool>(nullable: true),
                    DobMatch = table.Column<bool>(nullable: true),
                    AgeMatch = table.Column<bool>(nullable: true),
                    NotPreviouslyVerified = table.Column<bool>(nullable: true),
                    UserServiceUpdated = table.Column<bool>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "RegistrationJourney",
                schema: "Website",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false),
                    Source = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    RegistrationFormVariant = table.Column<byte>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationJourney", x => new { x.GroupId, x.Source, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.CreateTable(
                name: "RequestHelpJourney",
                schema: "Website",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false),
                    Source = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    RequestHelpFormVariant = table.Column<byte>(nullable: true),
                    TargetGroups = table.Column<int>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    AccessRestrictedByRole = table.Column<bool>(nullable: true),
                    RequestorDefinedByGroup = table.Column<bool>(nullable: true),
                    RequestsRequireApproval = table.Column<bool>(nullable: true),
                    SuppressRecipientPersonalDetails = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestHelpJourney", x => new { x.GroupId, x.Source, x.SYS_CHANGE_VERSION });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressDetail",
                schema: "Address");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "Address");

            migrationBuilder.DropTable(
                name: "Postcode",
                schema: "Address");

            migrationBuilder.DropTable(
                name: "PreComputedNearestPostcodes",
                schema: "Address");

            migrationBuilder.DropTable(
                name: "EmailTemplates",
                schema: "Analysis");

            migrationBuilder.DropTable(
                name: "LocationPostcodes",
                schema: "Analysis");

            migrationBuilder.DropTable(
                name: "PostcodeLookup",
                schema: "Analysis");

            migrationBuilder.DropTable(
                name: "Event",
                schema: "Communication");

            migrationBuilder.DropTable(
                name: "EventHistory",
                schema: "Communication");

            migrationBuilder.DropTable(
                name: "Feedback",
                schema: "Feedback");

            migrationBuilder.DropTable(
                name: "ActivityCredentialSet",
                schema: "Group");

            migrationBuilder.DropTable(
                name: "Credential",
                schema: "Group");

            migrationBuilder.DropTable(
                name: "CredentialSet",
                schema: "Group");

            migrationBuilder.DropTable(
                name: "Group",
                schema: "Group");

            migrationBuilder.DropTable(
                name: "GroupCredential",
                schema: "Group");

            migrationBuilder.DropTable(
                name: "GroupEmailConfiguration",
                schema: "Group");

            migrationBuilder.DropTable(
                name: "GroupLocation",
                schema: "Group");

            migrationBuilder.DropTable(
                name: "GroupMapDetails",
                schema: "Group");

            migrationBuilder.DropTable(
                name: "GroupSupportActivityConfiguration",
                schema: "Group");

            migrationBuilder.DropTable(
                name: "NewRequestNotificationStrategy",
                schema: "Group");

            migrationBuilder.DropTable(
                name: "SecurityConfiguration",
                schema: "Group");

            migrationBuilder.DropTable(
                name: "SupportActivityInstructions",
                schema: "Group");

            migrationBuilder.DropTable(
                name: "UserCredential",
                schema: "Group");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "Group");

            migrationBuilder.DropTable(
                name: "UserRoleAudit",
                schema: "Group");

            migrationBuilder.DropTable(
                name: "CredentialTypes",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "DueDateType",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "FeedbackRating",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "GroupType",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "JobStatus",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "NewRequestNotificationStrategy",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "Question",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "QuestionType",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "RegistrationFormVariant",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "RequestEvent",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "RequestFormStage",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "RequestFormVariant",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "RequestHelpFormVariant",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "RequestorType",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "RequestRoles",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "RequestType",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "SupportActivity",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "SupportActivityInstructions",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "TargetGroup",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "TestRequests",
                schema: "Maintenance");

            migrationBuilder.DropTable(
                name: "CommunicationMessage",
                schema: "Monitoring");

            migrationBuilder.DropTable(
                name: "EmailUnsubscribes",
                schema: "Monitoring");

            migrationBuilder.DropTable(
                name: "ExpectedEmails",
                schema: "Monitoring");

            migrationBuilder.DropTable(
                name: "MonitoringTimestamps",
                schema: "Monitoring");

            migrationBuilder.DropTable(
                name: "MonthlyStats",
                schema: "Monitoring");

            migrationBuilder.DropTable(
                name: "ActivityQuestions",
                schema: "QuestionSet");

            migrationBuilder.DropTable(
                name: "Question",
                schema: "QuestionSet");

            migrationBuilder.DropTable(
                name: "Job",
                schema: "Request");

            migrationBuilder.DropTable(
                name: "JobAvailableToGroup",
                schema: "Request");

            migrationBuilder.DropTable(
                name: "JobQuestions",
                schema: "Request");

            migrationBuilder.DropTable(
                name: "LogRequestEvent",
                schema: "Request");

            migrationBuilder.DropTable(
                name: "Request",
                schema: "Request");

            migrationBuilder.DropTable(
                name: "RequestJobStatus",
                schema: "Request");

            migrationBuilder.DropTable(
                name: "RequestSubmission",
                schema: "Request");

            migrationBuilder.DropTable(
                name: "Shift",
                schema: "Request");

            migrationBuilder.DropTable(
                name: "SupportActivities",
                schema: "Request");

            migrationBuilder.DropTable(
                name: "UpdateHistory",
                schema: "Request");

            migrationBuilder.DropTable(
                name: "ChampionPostcode",
                schema: "User");

            migrationBuilder.DropTable(
                name: "RegistrationHistory",
                schema: "User");

            migrationBuilder.DropTable(
                name: "SupportActivity",
                schema: "User");

            migrationBuilder.DropTable(
                name: "User",
                schema: "User");

            migrationBuilder.DropTable(
                name: "VerificationAttempt",
                schema: "Verification");

            migrationBuilder.DropTable(
                name: "VerificationAttempt2",
                schema: "Verification");

            migrationBuilder.DropTable(
                name: "RegistrationJourney",
                schema: "Website");

            migrationBuilder.DropTable(
                name: "RequestHelpJourney",
                schema: "Website");
        }
    }
}
