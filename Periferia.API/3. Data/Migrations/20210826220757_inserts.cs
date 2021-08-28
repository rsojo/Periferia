using Microsoft.EntityFrameworkCore.Migrations;

namespace Periferia.API.Migrations
{
    public partial class inserts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "DocNumber", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1L, "1", "María", "Perez", null },
                    { 2L, "2", "José", "Perez", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "UnitValue" },
                values: new object[,]
                {
                    { 1L, "El Dorado", 1000000f },
                    { 2L, "Miami International Airport", 1000000f }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
