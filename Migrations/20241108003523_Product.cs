using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionFlare.Migrations
{
    public partial class Product : Migration
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "09daa3ab-774f-4715-88e5-3bae4fd8a619", "fa9f9493-621c-49d1-99bd-3feef62f8207", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e0833a0e-465c-44eb-aeee-aec9a8cc1037", "0f53dc22-182f-46be-9a42-9294f5d3de9d", "Visitor", "VISITOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09daa3ab-774f-4715-88e5-3bae4fd8a619");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0833a0e-465c-44eb-aeee-aec9a8cc1037");

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
