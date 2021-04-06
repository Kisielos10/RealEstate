using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.API.Migrations
{
    public partial class Initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "RealEstateAddresses",
                columns: table => new
                {
                    RealEstateId = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingNumber = table.Column<int>(type: "int", nullable: false),
                    ApartmentNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateAddresses", x => x.RealEstateId);
                    table.ForeignKey(
                        name: "FK_RealEstateAddresses_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "RealEstates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealEstateAddresses");

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
    }
}
