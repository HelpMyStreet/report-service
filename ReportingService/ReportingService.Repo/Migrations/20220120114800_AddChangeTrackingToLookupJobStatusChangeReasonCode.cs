using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ReportingService.Repo.Migrations
{
    public partial class AddChangeTrackingToLookupJobStatusChangeReasonCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobStatusChangeReasonCode",
                schema: "Lookup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TriggersStatusChangeEmail = table.Column<bool>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobStatusChangeReasonCode", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.Sql(@"
                CREATE view [LookupLatest].[JobStatusChangeReasonCode] AS SELECT a.[ID],a.[Name],a.[TriggersStatusChangeEmail], a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Lookup].[JobStatusChangeReasonCode] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[JobStatusChangeReasonCode] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>'d'
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobStatusChangeReasonCode",
                schema: "Lookup");

            migrationBuilder.Sql(@"
                DROP view [LookupLatest].[JobStatusChangeReasonCode]
                ");


        }
    }
}
