using Microsoft.EntityFrameworkCore.Migrations;

namespace DataServer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserData",
                columns: table => new
                {
                    userId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    username = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserData", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    email = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    auth = table.Column<int>(type: "INTEGER", nullable: false),
                    firstName = table.Column<string>(type: "TEXT", nullable: true),
                    lastName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    longitude = table.Column<double>(type: "REAL", nullable: false),
                    latitude = table.Column<double>(type: "REAL", nullable: false),
                    title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    addedByuserId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.id);
                    table.ForeignKey(
                        name: "FK_Places_UserData_addedByuserId",
                        column: x => x.addedByuserId,
                        principalTable: "UserData",
                        principalColumn: "userId",
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
                name: "PlaceUser",
                columns: table => new
                {
                    savedPlacesid = table.Column<long>(type: "INTEGER", nullable: false),
                    usersid = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceUser", x => new { x.savedPlacesid, x.usersid });
                    table.ForeignKey(
                        name: "FK_PlaceUser_Places_savedPlacesid",
                        column: x => x.savedPlacesid,
                        principalTable: "Places",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaceUser_Users_usersid",
                        column: x => x.usersid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    rating = table.Column<int>(type: "INTEGER", nullable: false),
                    comment = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    addedByuserId = table.Column<long>(type: "INTEGER", nullable: true),
                    Placeid = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reviews_Places_Placeid",
                        column: x => x.Placeid,
                        principalTable: "Places",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_UserData_addedByuserId",
                        column: x => x.addedByuserId,
                        principalTable: "UserData",
                        principalColumn: "userId",
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

            migrationBuilder.CreateIndex(
                name: "IX_PlaceReports_reportedItemid",
                table: "PlaceReports",
                column: "reportedItemid");

            migrationBuilder.CreateIndex(
                name: "IX_Places_addedByuserId",
                table: "Places",
                column: "addedByuserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceUser_usersid",
                table: "PlaceUser",
                column: "usersid");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewReports_reportedItemid",
                table: "ReviewReports",
                column: "reportedItemid");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_addedByuserId",
                table: "Reviews",
                column: "addedByuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_Placeid",
                table: "Reviews",
                column: "Placeid");

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
                name: "PlaceUser");

            migrationBuilder.DropTable(
                name: "ReviewReports");

            migrationBuilder.DropTable(
                name: "UserReports");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "UserData");
        }
    }
}
