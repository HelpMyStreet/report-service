using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportingService.Repo.Migrations
{
    public partial class AddJobStatusChangeReasonCodeToRequestJobStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "JobStatusChangeReasonCodeID",
                schema: "Request",
                table: "RequestJobStatus",
                nullable: true);

            migrationBuilder.Sql(@"
                ALTER view [RequestLatest].[RequestJobStatus] AS SELECT a.[JobID],a.[JobStatusID],a.[DateCreated],a.[VolunteerUserID],a.[CreatedByUserID],a.[JobStatusChangeReasonCodeID], a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Request].[RequestJobStatus] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,DateCreated,JobID,JobStatusID from [Request].[RequestJobStatus] group by DateCreated,JobID,JobStatusID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.DateCreated=Latest.DateCreated AND a.JobID=Latest.JobID AND a.JobStatusID=Latest.JobStatusID WHERE [SYS_CHANGE_OPERATION]<>'d'
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobStatusChangeReasonCodeID",
                schema: "Request",
                table: "RequestJobStatus");

            migrationBuilder.Sql(@"
                ALTER view [RequestLatest].[RequestJobStatus] AS SELECT a.[JobID],a.[JobStatusID],a.[DateCreated],a.[VolunteerUserID],a.[CreatedByUserID], a.[DateFrom],a.[SYS_CHANGE_OPERATION] FROM [Request].[RequestJobStatus] a inner join (select max(SYS_CHANGE_VERSION) as MaxVersion,DateCreated,JobID,JobStatusID from [Request].[RequestJobStatus] group by DateCreated,JobID,JobStatusID) latest on a.SYS_CHANGE_VERSION = latest.MaxVersion AND a.DateCreated=Latest.DateCreated AND a.JobID=Latest.JobID AND a.JobStatusID=Latest.JobStatusID WHERE [SYS_CHANGE_OPERATION]<>'d'
                ");
        }
    }
}
