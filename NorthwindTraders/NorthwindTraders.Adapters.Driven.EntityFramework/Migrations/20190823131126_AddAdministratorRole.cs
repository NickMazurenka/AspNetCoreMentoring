using Microsoft.EntityFrameworkCore.Migrations;

namespace NorthwindTraders.Adapters.Driven.EntityFramework.Migrations
{
    public partial class AddAdministratorRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c4fb3a86-d18e-4cf7-b0ce-671bbb834a1c", "3798a991-2aee-4799-bebc-56f2934039de", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4fb3a86-d18e-4cf7-b0ce-671bbb834a1c");
        }
    }
}
