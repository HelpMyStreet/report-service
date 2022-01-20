using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ReportingService.Repo.Migrations
{
    public partial class AddLookupUrgentRequestNotificationStrategy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UrgentRequestNotificationStrategy",
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
                    table.PrimaryKey("PK_UrgentRequestNotificationStrategy", x => new { x.ID, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.Sql(@"
                CREATE view [LookupLatest].[UrgentRequestNotificationStrategy] AS SELECT a.[ID],a.[Name],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Lookup].[UrgentRequestNotificationStrategy] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[UrgentRequestNotificationStrategy] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>'d'
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UrgentRequestNotificationStrategy",
                schema: "Lookup");

            migrationBuilder.Sql(@"
                DROP view [LookupLatest].[UrgentRequestNotificationStrategy]
                ");
        }
    }
}
