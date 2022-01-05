using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportingService.Repo.Migrations
{
    public partial class AddFriendlyNameToSupportActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FriendlyName",
                schema: "Lookup",
                table: "SupportActivity",
                nullable: true);

            migrationBuilder.Sql(@"
                ALTER view [LookupLatest].[SupportActivity] AS SELECT a.[ID],a.[Name],a.[FriendlyName], a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Lookup].[SupportActivity] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[SupportActivity] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>'d'
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FriendlyName",
                schema: "Lookup",
                table: "SupportActivity");

            migrationBuilder.Sql(@"
                ALTER view [LookupLatest].[SupportActivity] AS SELECT a.[ID],a.[Name],a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Lookup].[SupportActivity] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,ID from [Lookup].[SupportActivity] group by ID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.ID=Latest.ID WHERE [SYS_CHANGE_OPERATION]<>'d'
                ");
        }
    }
}
