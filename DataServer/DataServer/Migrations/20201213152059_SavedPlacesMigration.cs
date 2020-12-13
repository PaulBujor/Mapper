using Microsoft.EntityFrameworkCore.Migrations;

namespace DataServer.Migrations
{
    public partial class SavedPlacesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
