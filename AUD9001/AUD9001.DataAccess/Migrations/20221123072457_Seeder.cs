using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUD9001.DataAccess.Migrations
{
    public partial class Seeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "Description", "Name", "Owner" },
                values: new object[] { 1, "Graniczna 1", "Testowa Firma", "FirmaTestowa", "Marcin Sienicki" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Login", "Name", "Password", "Position", "ProcessId", "RoleId", "Salt", "Surname" },
                values: new object[] { 1, "tst@tst.pl", "marcsien", "Marcin", "1234", "Developer", null, null, null, "Sienicki" });

            migrationBuilder.InsertData(
                table: "Processes",
                columns: new[] { "Id", "CompanyId", "Description", "Name" },
                values: new object[] { 1, 1, "Proces produkcyjny", "Produkcja" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Processes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
