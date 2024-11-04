using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionFlare.Migrations
{
    public partial class AddedproductQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2af9a427-4b4f-40b0-898a-8f2303838820");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6dde5ff-d4a6-4195-996a-5391fdc56e82");

            migrationBuilder.AddColumn<int>(
                name: "StockQuantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ed44a25-0ee0-4fdf-806b-36e4212cd91c", "2b495ec2-0af2-4822-adf1-fa1610e45748", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "897a1cce-0754-46a3-813b-ceb0200b9cf9", "440c7444-3729-4080-9629-13a0831692b4", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ed44a25-0ee0-4fdf-806b-36e4212cd91c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "897a1cce-0754-46a3-813b-ceb0200b9cf9");

            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2af9a427-4b4f-40b0-898a-8f2303838820", "e7af106a-ccff-46ad-9aab-0fe16f9594bf", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c6dde5ff-d4a6-4195-996a-5391fdc56e82", "c451f5f2-5df0-4d8e-bfd0-01f2adea328d", "Administrator", "ADMINISTRATOR" });
        }
    }
}
