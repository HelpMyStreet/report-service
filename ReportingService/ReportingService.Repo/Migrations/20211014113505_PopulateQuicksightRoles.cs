using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportingService.Repo.Migrations
{
    public partial class PopulateQuicksightRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Quicksight",
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { -33, "AgeUKMidMersey_Admin" },
                    { -3, "AgeUKLSL_Admin" },
                    { -5, "Tankersley_Admin" },
                    { -6, "Ruddington_Admin" },
                    { -7, "AgeUKWirral_Admin" },
                    { -8, "AgeUKNottsBalderton_Admin" },
                    { -9, "AgeUKNorthWestKent_Admin" },
                    { -10, "AgeUKNottsNorthMuskham_Admin" },
                    { -11, "AgeUKSouthKentCoast_Admin" },
                    { -12, "LincolnshireVolunteers_Admin" },
                    { -13, "AgeUKFavershamAndSittingbourne_Admin" },
                    { -14, "EastLindseyPCN_Admin" },
                    { -17, "StamfordPCN_Admin" },
                    { -20, "LincolnPCN_Admin" },
                    { -22, "Sandbox_Admin" },
                    { -23, "AgeConnectsCardiff_Admin" },
                    { -31, "Southwell_Admin" },
                    { -32, "ApexBankStaff_Admin" },
                    { -2, "FTLOS_Admin" },
                    { -1, "Generic_Admin" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -33);

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -32);

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -31);

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -23);

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -22);

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -20);

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -17);

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -14);

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -13);

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -12);

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -11);

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                schema: "Quicksight",
                table: "Role",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
