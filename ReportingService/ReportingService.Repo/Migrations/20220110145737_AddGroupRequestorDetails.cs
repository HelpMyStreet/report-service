using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ReportingService.Repo.Migrations
{
    public partial class AddGroupRequestorDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestorDetails",
                schema: "Group",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LastName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    AddressLine1 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    AddressLine2 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    AddressLine3 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Locality = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Postcode = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    EmailAddress = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    MobilePhone = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    OtherPhone = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    SYS_CHANGE_VERSION = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SYS_CHANGE_OPERATION = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestorDetails", x => new { x.GroupId, x.SYS_CHANGE_VERSION });
                });

            migrationBuilder.Sql(@"
                CREATE view [GroupLatest].[RequestorDetails] AS SELECT a.[GroupId],a.[FirstName],a.[LastName],a.[AddressLine1],a.[AddressLine2],
                    a.[AddressLine3],a.[Locality],a.[Postcode],a.[EmailAddress],a.[MobilePhone],a.[OtherPhone], a.[DateFrom],a.[SYS_CHANGE_OPERATION] 
                FROM [Group].[RequestorDetails] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,GroupID from [Group].[RequestorDetails] group by GroupId) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.GroupID=Latest.GroupID WHERE [SYS_CHANGE_OPERATION]<>'d'
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestorDetails",
                schema: "Group");

            migrationBuilder.Sql(@"
                DROP view [GroupLatest].[RequestorDetails]
                ");


        }
    }
}
