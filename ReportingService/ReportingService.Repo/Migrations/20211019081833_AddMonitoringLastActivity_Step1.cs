using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportingService.Repo.Migrations
{
    public partial class AddMonitoringLastActivity_Step1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LastActivity",
                schema: "Monitoring",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false),
                    GroupName = table.Column<string>(nullable: true),
                    GroupCount = table.Column<int>(nullable: true),
                    LastActiveDate = table.Column<DateTime>(nullable: true),
                    EverActive = table.Column<double>(name: "% Ever Active", nullable: true),
                    Activewithinlast90days = table.Column<double>(name: "% Active within last 90 days", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastActivity", x => x.GroupId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LastActivity",
                schema: "Monitoring");
        }
    }
}
