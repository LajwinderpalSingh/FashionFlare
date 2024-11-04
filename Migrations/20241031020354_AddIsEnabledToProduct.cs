using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionFlare.Migrations
{
    public partial class AddIsEnabledToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ed44a25-0ee0-4fdf-806b-36e4212cd91c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "897a1cce-0754-46a3-813b-ceb0200b9cf9");

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2b9858fd-a537-41d2-ad56-0e9ca054cab2", "f23de152-1b65-4753-9bcf-bb6bde6d5536", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c85c4e11-2dde-4887-8be0-71be9c316dba", "c1f488c0-2a54-47c3-848e-7272cea8f839", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b9858fd-a537-41d2-ad56-0e9ca054cab2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c85c4e11-2dde-4887-8be0-71be9c316dba");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ed44a25-0ee0-4fdf-806b-36e4212cd91c", "2b495ec2-0af2-4822-adf1-fa1610e45748", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "897a1cce-0754-46a3-813b-ceb0200b9cf9", "440c7444-3729-4080-9629-13a0831692b4", "Administrator", "ADMINISTRATOR" });
        }
    }
}
