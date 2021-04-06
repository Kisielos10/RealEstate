using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.API.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RealEstateAddress_ApartmentNumber",
                table: "RealEstates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RealEstateAddress_BuildingNumber",
                table: "RealEstates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealEstateAddress_PostalCode",
                table: "RealEstates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealEstateAddress_StreetName",
                table: "RealEstates",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RealEstateAddress_ApartmentNumber",
                table: "RealEstates");

            migrationBuilder.DropColumn(
                name: "RealEstateAddress_BuildingNumber",
                table: "RealEstates");

            migrationBuilder.DropColumn(
                name: "RealEstateAddress_PostalCode",
                table: "RealEstates");

            migrationBuilder.DropColumn(
                name: "RealEstateAddress_StreetName",
                table: "RealEstates");
        }
    }
}
