using Microsoft.EntityFrameworkCore.Migrations;

namespace DataServer.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Users_addedByid",
                table: "Places");

            migrationBuilder.AlterColumn<long>(
                name: "addedByid",
                table: "Places",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.CreateTable(
                name: "PlaceUser",
                columns: table => new
                {
                    savedByid = table.Column<long>(type: "INTEGER", nullable: false),
                    savedPlacesid = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceUser", x => new { x.savedByid, x.savedPlacesid });
                    table.ForeignKey(
                        name: "FK_PlaceUser_Places_savedPlacesid",
                        column: x => x.savedPlacesid,
                        principalTable: "Places",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaceUser_Users_savedByid",
                        column: x => x.savedByid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaceUser_savedPlacesid",
                table: "PlaceUser",
                column: "savedPlacesid");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Users_addedByid",
                table: "Places",
                column: "addedByid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Users_addedByid",
                table: "Places");

            migrationBuilder.DropTable(
                name: "PlaceUser");

            migrationBuilder.AlterColumn<long>(
                name: "addedByid",
                table: "Places",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Users_addedByid",
                table: "Places",
                column: "addedByid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
