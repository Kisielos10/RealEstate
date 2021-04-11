using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.API.Migrations
{
    public partial class Initial10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstateNote_RealEstates_RealEstateId",
                table: "RealEstateNote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RealEstateNote",
                table: "RealEstateNote");

            migrationBuilder.RenameTable(
                name: "RealEstateNote",
                newName: "RealEstateNotes");

            migrationBuilder.RenameIndex(
                name: "IX_RealEstateNote_RealEstateId",
                table: "RealEstateNotes",
                newName: "IX_RealEstateNotes_RealEstateId");

            migrationBuilder.AlterColumn<string>(
                name: "BuildingType",
                table: "RealEstates",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RealEstateNotes",
                table: "RealEstateNotes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstateNotes_RealEstates_RealEstateId",
                table: "RealEstateNotes",
                column: "RealEstateId",
                principalTable: "RealEstates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstateNotes_RealEstates_RealEstateId",
                table: "RealEstateNotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RealEstateNotes",
                table: "RealEstateNotes");

            migrationBuilder.RenameTable(
                name: "RealEstateNotes",
                newName: "RealEstateNote");

            migrationBuilder.RenameIndex(
                name: "IX_RealEstateNotes_RealEstateId",
                table: "RealEstateNote",
                newName: "IX_RealEstateNote_RealEstateId");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingType",
                table: "RealEstates",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RealEstateNote",
                table: "RealEstateNote",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstateNote_RealEstates_RealEstateId",
                table: "RealEstateNote",
                column: "RealEstateId",
                principalTable: "RealEstates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
