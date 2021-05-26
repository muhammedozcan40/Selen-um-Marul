using Microsoft.EntityFrameworkCore.Migrations;

namespace migros.Migrations
{
    public partial class eda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShopPHPID",
                table: "Unit",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShopPHPName",
                table: "Unit",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShopPHPState",
                table: "Unit",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ShopPHPID",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShopPHPState",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ShopPHPID",
                table: "ProductAddresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShopPHPState",
                table: "ProductAddresses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ShopPHPID",
                table: "Markets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShopPHPState",
                table: "Markets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ShopPHPID",
                table: "KategoriAddresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShopPHPState",
                table: "KategoriAddresses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ShopPHPID",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShopPHPState",
                table: "Files",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ShopPHPID",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShopPHPState",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ShopPHPID",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShopPHPState",
                table: "Brands",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopPHPID",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "ShopPHPName",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "ShopPHPState",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "ShopPHPID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShopPHPState",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShopPHPID",
                table: "ProductAddresses");

            migrationBuilder.DropColumn(
                name: "ShopPHPState",
                table: "ProductAddresses");

            migrationBuilder.DropColumn(
                name: "ShopPHPID",
                table: "Markets");

            migrationBuilder.DropColumn(
                name: "ShopPHPState",
                table: "Markets");

            migrationBuilder.DropColumn(
                name: "ShopPHPID",
                table: "KategoriAddresses");

            migrationBuilder.DropColumn(
                name: "ShopPHPState",
                table: "KategoriAddresses");

            migrationBuilder.DropColumn(
                name: "ShopPHPID",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "ShopPHPState",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "ShopPHPID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ShopPHPState",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ShopPHPID",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "ShopPHPState",
                table: "Brands");
        }
    }
}
