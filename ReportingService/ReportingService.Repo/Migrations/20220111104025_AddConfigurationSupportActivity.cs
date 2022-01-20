using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ReportingService.Repo.Migrations
{
    public partial class AddConfigurationSupportActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Configuration");

            migrationBuilder.EnsureSchema(
                name: "ConfigurationLatest");

            migrationBuilder.CreateTable(
                name: "SupportActivity",
                schema: "Configuration",
                columns: table => new
                {
                    SupportActivityID = table.Column<int>(nullable: false),
                    AutoSignUpWhenOtherSelected = table.Column<bool>(nullable:true),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationSupportActivity", x => new { x.SupportActivityID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.Sql(@"
                CREATE view [ConfigurationLatest].[SupportActivity] AS SELECT a.[SupportActivityID],a.[AutoSignUpWhenOtherSelected],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Configuration].[SupportActivity] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,SupportActivityID from [Configuration].[SupportActivity] group by SupportActivityID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.SupportActivityID=Latest.SupportActivityID WHERE [SYS_CHANGE_OPERATION]<>'d'
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupportActivity",
                schema: "Configuration");

            migrationBuilder.Sql(@"
                DROP view [ConfigurationLatest].[SupportActivity]
                ");

            migrationBuilder.DropSchema(
                name: "ConfigurationLatest");

            migrationBuilder.DropSchema(
                name: "Configuration");
        }
    }
}
