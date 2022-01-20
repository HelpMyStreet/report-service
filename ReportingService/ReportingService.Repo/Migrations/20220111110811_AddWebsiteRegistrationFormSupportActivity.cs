using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ReportingService.Repo.Migrations
{
    public partial class AddWebsiteRegistrationFormSupportActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistrationFormSupportActivity",
                schema: "Website",
                columns: table => new
                {
                    RequestHelpFormVariantID = table.Column<int>(nullable: false),
                    SupportActivityID = table.Column<int>(nullable: false),
                    Label = table.Column<string>(maxLength:200, nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true),
                    IsPreSelected = table.Column<bool>(nullable: true),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationFormSupportActivity", x => new { x.RequestHelpFormVariantID, x.SupportActivityID,  x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.Sql(@"
                CREATE view [WebsiteLatest].[RegistrationFormSupportActivity] AS SELECT a.[RequestHelpFormVariantID],a.[SupportActivityID],a.[Label],a.[DisplayOrder],a.[IsPreSelected],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Website].[RegistrationFormSupportActivity] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion, RequestHelpFormVariantID, SupportActivityID from [Website].[RegistrationFormSupportActivity] group by RequestHelpFormVariantID, SupportActivityID ) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.RequestHelpFormVariantID = latest.RequestHelpFormVariantID AND a.SupportActivityID=Latest.SupportActivityID WHERE [SYS_CHANGE_OPERATION]<>'d'
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrationFormSupportActivity",
                schema: "Website");

            migrationBuilder.Sql(@"
                DROP view [WebsiteLatest].[RegistrationFormSupportActivity]
                ");
        }
    }
}
