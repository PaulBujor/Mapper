using Microsoft.EntityFrameworkCore.Migrations;

namespace DataServer.Migrations
{
    public partial class SecondMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlaceReports",
                columns: table => new
                {
                    reportId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    reportedItemid = table.Column<long>(type: "INTEGER", nullable: true),
                    reportedClass = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    resolved = table.Column<bool>(type: "INTEGER", nullable: false),
                    category = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceReports", x => x.reportId);
                    table.ForeignKey(
                        name: "FK_PlaceReports_Places_reportedItemid",
                        column: x => x.reportedItemid,
                        principalTable: "Places",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReviewReports",
                columns: table => new
                {
                    reportId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    reportedItemid = table.Column<long>(type: "INTEGER", nullable: true),
                    reportedClass = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    resolved = table.Column<bool>(type: "INTEGER", nullable: false),
                    category = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewReports", x => x.reportId);
                    table.ForeignKey(
                        name: "FK_ReviewReports_Reviews_reportedItemid",
                        column: x => x.reportedItemid,
                        principalTable: "Reviews",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserReports",
                columns: table => new
                {
                    reportId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    reportedItemid = table.Column<long>(type: "INTEGER", nullable: true),
                    reportedClass = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    resolved = table.Column<bool>(type: "INTEGER", nullable: false),
                    category = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReports", x => x.reportId);
                    table.ForeignKey(
                        name: "FK_UserReports_Users_reportedItemid",
                        column: x => x.reportedItemid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaceReports_reportedItemid",
                table: "PlaceReports",
                column: "reportedItemid");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewReports_reportedItemid",
                table: "ReviewReports",
                column: "reportedItemid");

            migrationBuilder.CreateIndex(
                name: "IX_UserReports_reportedItemid",
                table: "UserReports",
                column: "reportedItemid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaceReports");

            migrationBuilder.DropTable(
                name: "ReviewReports");

            migrationBuilder.DropTable(
                name: "UserReports");
        }
    }
}
