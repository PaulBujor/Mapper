using Microsoft.EntityFrameworkCore.Migrations;

namespace DataServer.Migrations
{
    public partial class RemovedBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Place_Users_addedByid",
                table: "Place");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaceReports_Place_reportedItemid",
                table: "PlaceReports");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaceUser_Place_savedPlacesid",
                table: "PlaceUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Place_Placeid",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Users_addedByid",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewReports_Review_reportedItemid",
                table: "ReviewReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Place",
                table: "Place");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "Place",
                newName: "Places");

            migrationBuilder.RenameIndex(
                name: "IX_Review_Placeid",
                table: "Reviews",
                newName: "IX_Reviews_Placeid");

            migrationBuilder.RenameIndex(
                name: "IX_Review_addedByid",
                table: "Reviews",
                newName: "IX_Reviews_addedByid");

            migrationBuilder.RenameIndex(
                name: "IX_Place_addedByid",
                table: "Places",
                newName: "IX_Places_addedByid");

            migrationBuilder.AddColumn<bool>(
                name: "removed",
                table: "Reviews",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "removed",
                table: "Places",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Places",
                table: "Places",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceReports_Places_reportedItemid",
                table: "PlaceReports",
                column: "reportedItemid",
                principalTable: "Places",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Users_addedByid",
                table: "Places",
                column: "addedByid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceUser_Places_savedPlacesid",
                table: "PlaceUser",
                column: "savedPlacesid",
                principalTable: "Places",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewReports_Reviews_reportedItemid",
                table: "ReviewReports",
                column: "reportedItemid",
                principalTable: "Reviews",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Places_Placeid",
                table: "Reviews",
                column: "Placeid",
                principalTable: "Places",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_addedByid",
                table: "Reviews",
                column: "addedByid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaceReports_Places_reportedItemid",
                table: "PlaceReports");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_Users_addedByid",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaceUser_Places_savedPlacesid",
                table: "PlaceUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewReports_Reviews_reportedItemid",
                table: "ReviewReports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Places_Placeid",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_addedByid",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Places",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "removed",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "removed",
                table: "Places");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameTable(
                name: "Places",
                newName: "Place");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_Placeid",
                table: "Review",
                newName: "IX_Review_Placeid");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_addedByid",
                table: "Review",
                newName: "IX_Review_addedByid");

            migrationBuilder.RenameIndex(
                name: "IX_Places_addedByid",
                table: "Place",
                newName: "IX_Place_addedByid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Place",
                table: "Place",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Place_Users_addedByid",
                table: "Place",
                column: "addedByid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceReports_Place_reportedItemid",
                table: "PlaceReports",
                column: "reportedItemid",
                principalTable: "Place",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceUser_Place_savedPlacesid",
                table: "PlaceUser",
                column: "savedPlacesid",
                principalTable: "Place",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Place_Placeid",
                table: "Review",
                column: "Placeid",
                principalTable: "Place",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Users_addedByid",
                table: "Review",
                column: "addedByid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewReports_Review_reportedItemid",
                table: "ReviewReports",
                column: "reportedItemid",
                principalTable: "Review",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
