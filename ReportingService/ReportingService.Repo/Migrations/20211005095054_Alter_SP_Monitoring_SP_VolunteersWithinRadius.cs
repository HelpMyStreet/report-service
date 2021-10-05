using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportingService.Repo.Migrations
{
    public partial class Alter_SP_Monitoring_SP_VolunteersWithinRadius : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER PROCEDURE [Analysis].[SP_VolunteersWithinRadius]
	@Postcode VARCHAR(10)
	,@Activity VARCHAR(100)

  AS
  --DummyCommit
  DECLARE	@Coordinates GEOGRAPHY
			,@ActivityID INT 

  SELECT	@Coordinates = [Coordinates]
	FROM	[AddressLatest].[Postcode]
	WHERE	[Postcode] = @Postcode

  SELECT	@ActivityID = [ID]
	FROM	[Lookup].[SupportActivity]
	WHERE	[Name] = @Activity

  SELECT	@Postcode AS [Postcode]
			,'Any' AS [ActivityType]
			,COUNT(DISTINCT CASE WHEN [Coordinates].STDistance(@Coordinates) / 1000 * 0.621371 <= 5 THEN [ID] END) AS [VolsWithin5Miles]
			,COUNT(DISTINCT CASE WHEN [Coordinates].STDistance(@Coordinates) / 1000 * 0.621371 <= 10 THEN [ID] END) AS [VolsWithin10Miles]
			,COUNT(DISTINCT CASE WHEN [Coordinates].STDistance(@Coordinates) / 1000 * 0.621371 <= 15 THEN [ID] END) AS [VolsWithin15Miles]
			,COUNT(DISTINCT CASE WHEN [Coordinates].STDistance(@Coordinates) / 1000 * 0.621371 <= 20 THEN [ID] END) AS [VolsWithin20Miles]
	FROM	[TableView].[User]
  UNION
  SELECT	@Postcode AS [Postcode]
			,@Activity
			,COUNT(DISTINCT CASE WHEN [Coordinates].STDistance(@Coordinates) / 1000 * 0.621371 <= 5 THEN [ID] END) AS [VolsWithin5Miles]
			,COUNT(DISTINCT CASE WHEN [Coordinates].STDistance(@Coordinates) / 1000 * 0.621371 <= 10 THEN [ID] END) AS [VolsWithin10Miles]
			,COUNT(DISTINCT CASE WHEN [Coordinates].STDistance(@Coordinates) / 1000 * 0.621371 <= 15 THEN [ID] END) AS [VolsWithin15Miles]
			,COUNT(DISTINCT CASE WHEN [Coordinates].STDistance(@Coordinates) / 1000 * 0.621371 <= 20 THEN [ID] END) AS [VolsWithin20Miles]
	FROM	[TableView].[User]
	WHERE	[ID] IN (SELECT [UserID] FROM [UserLatest].[SupportActivity] WHERE [ActivityID] = @ActivityID)
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER PROCEDURE [Analysis].[SP_VolunteersWithinRadius]
	@Postcode VARCHAR(10)
	,@Activity VARCHAR(100)

  AS

  DECLARE	@Coordinates GEOGRAPHY
			,@ActivityID INT 

  SELECT	@Coordinates = [Coordinates]
	FROM	[AddressLatest].[Postcode]
	WHERE	[Postcode] = @Postcode

  SELECT	@ActivityID = [ID]
	FROM	[Lookup].[SupportActivity]
	WHERE	[Name] = @Activity

  SELECT	@Postcode AS [Postcode]
			,'Any' AS [ActivityType]
			,COUNT(DISTINCT CASE WHEN [Coordinates].STDistance(@Coordinates) / 1000 * 0.621371 <= 5 THEN [ID] END) AS [VolsWithin5Miles]
			,COUNT(DISTINCT CASE WHEN [Coordinates].STDistance(@Coordinates) / 1000 * 0.621371 <= 10 THEN [ID] END) AS [VolsWithin10Miles]
			,COUNT(DISTINCT CASE WHEN [Coordinates].STDistance(@Coordinates) / 1000 * 0.621371 <= 15 THEN [ID] END) AS [VolsWithin15Miles]
			,COUNT(DISTINCT CASE WHEN [Coordinates].STDistance(@Coordinates) / 1000 * 0.621371 <= 20 THEN [ID] END) AS [VolsWithin20Miles]
	FROM	[TableView].[User]
  UNION
  SELECT	@Postcode AS [Postcode]
			,@Activity
			,COUNT(DISTINCT CASE WHEN [Coordinates].STDistance(@Coordinates) / 1000 * 0.621371 <= 5 THEN [ID] END) AS [VolsWithin5Miles]
			,COUNT(DISTINCT CASE WHEN [Coordinates].STDistance(@Coordinates) / 1000 * 0.621371 <= 10 THEN [ID] END) AS [VolsWithin10Miles]
			,COUNT(DISTINCT CASE WHEN [Coordinates].STDistance(@Coordinates) / 1000 * 0.621371 <= 15 THEN [ID] END) AS [VolsWithin15Miles]
			,COUNT(DISTINCT CASE WHEN [Coordinates].STDistance(@Coordinates) / 1000 * 0.621371 <= 20 THEN [ID] END) AS [VolsWithin20Miles]
	FROM	[TableView].[User]
	WHERE	[ID] IN (SELECT [UserID] FROM [UserLatest].[SupportActivity] WHERE [ActivityID] = @ActivityID)

GO
            ");
        }
    }
}
