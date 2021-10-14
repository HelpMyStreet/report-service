using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportingService.Repo.Migrations
{
    public partial class PopulateQuicksightGroupRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Quicksight",
                table: "RoleGroups",
                columns: new[] { "RoleId", "GroupId" },
                values: new object[,]
                {
                    { -33, -33 },
                    { -1, -32 },
                    { -1, -31 },
                    { -1, -23 },
                    { -1, -22 },
                    { -1, -20 },
                    { -1, -17 },
                    { -1, -14 },
                    { -1, -33 },
                    { -1, -13 },
                    { -1, -11 },
                    { -1, -10 },
                    { -1, -9 },
                    { -1, -8 },
                    { -1, -7 },
                    { -1, -6 },
                    { -1, -5 },
                    { -1, -12 },
                    { -1, -3 },
                    { -1, -1 },
                    { -3, -3 },
                    { -32, -32 },
                    { -31, -31 },
                    { -23, -23 },
                    { -22, -22 },
                    { -20, -20 },
                    { -17, -17 },
                    { -14, -14 },
                    { -2, -2 },
                    { -13, -13 },
                    { -11, -11 },
                    { -10, -10 },
                    { -9, -9 },
                    { -8, -8 },
                    { -7, -7 },
                    { -6, -6 },
                    { -5, -5 },
                    { -12, -12 },
                    { -1, -2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -33, -33 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -32, -32 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -31, -31 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -23, -23 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -22, -22 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -20, -20 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -17, -17 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -14, -14 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -13, -13 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -12, -12 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -11, -11 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -10, -10 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -9, -9 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -8, -8 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -7, -7 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -6, -6 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -5, -5 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -3, -3 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -2, -2 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -1, -33 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -1, -32 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -1, -31 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -1, -23 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -1, -22 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -1, -20 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -1, -17 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -1, -14 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -1, -13 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -1, -12 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -1, -11 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -1, -10 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -1, -9 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -1, -8 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -1, -7 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -1, -6 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -1, -5 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -1, -3 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -1, -2 });

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "RoleGroups",
                keyColumns: new[] { "RoleId", "GroupId" },
                keyValues: new object[] { -1, -1 });

            migrationBuilder.UpdateData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -33,
                column: "RoleName",
                value: "AgeUKMidMersey_Admin");

            migrationBuilder.UpdateData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -32,
                column: "RoleName",
                value: "ApexBankStaff_Admin");

            migrationBuilder.UpdateData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -31,
                column: "RoleName",
                value: "Southwell_Admin");

            migrationBuilder.UpdateData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -23,
                column: "RoleName",
                value: "AgeConnectsCardiff_Admin");

            migrationBuilder.UpdateData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -22,
                column: "RoleName",
                value: "Sandbox_Admin");

            migrationBuilder.UpdateData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -20,
                column: "RoleName",
                value: "LincolnPCN_Admin");

            migrationBuilder.UpdateData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -17,
                column: "RoleName",
                value: "StamfordPCN_Admin");

            migrationBuilder.UpdateData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -14,
                column: "RoleName",
                value: "EastLindseyPCN_Admin");

            migrationBuilder.UpdateData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -13,
                column: "RoleName",
                value: "AgeUKFavershamAndSittingbourne_Admin");

            migrationBuilder.UpdateData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -12,
                column: "RoleName",
                value: "LincolnshireVolunteers_Admin");

            migrationBuilder.UpdateData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -11,
                column: "RoleName",
                value: "AgeUKSouthKentCoast_Admin");

            migrationBuilder.UpdateData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -10,
                column: "RoleName",
                value: "AgeUKNottsNorthMuskham_Admin");

            migrationBuilder.UpdateData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -9,
                column: "RoleName",
                value: "AgeUKNorthWestKent_Admin");

            migrationBuilder.UpdateData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -8,
                column: "RoleName",
                value: "AgeUKNottsBalderton_Admin");

            migrationBuilder.UpdateData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -7,
                column: "RoleName",
                value: "AgeUKWirral_Admin");

            migrationBuilder.UpdateData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -6,
                column: "RoleName",
                value: "Ruddington_Admin");

            migrationBuilder.UpdateData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -5,
                column: "RoleName",
                value: "Tankersley_Admin");

            migrationBuilder.UpdateData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -3,
                column: "RoleName",
                value: "AgeUKLSL_Admin");

            migrationBuilder.UpdateData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -2,
                column: "RoleName",
                value: "FTLOS_Admin");

            migrationBuilder.UpdateData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -1,
                column: "RoleName",
                value: "Generic_Admin");
        }
    }
}
