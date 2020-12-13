using Microsoft.EntityFrameworkCore.Migrations;

namespace DataServer.Migrations
{
    public partial class UsersinPlace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Users_Userid",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_Userid",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Places");

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

            migrationBuilder.CreateIndex(
                name: "IX_PlaceUser_usersid",
                table: "PlaceUser",
                column: "usersid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaceUser");

            migrationBuilder.AddColumn<long>(
                name: "Userid",
                table: "Places",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Places_Userid",
                table: "Places",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Users_Userid",
                table: "Places",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
