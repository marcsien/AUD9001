using Microsoft.EntityFrameworkCore.Migrations;

namespace AUD9001.DataAccess.Migrations
{
    public partial class makecompanynotrequired2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processes_Companies_CompanyId",
                table: "Processes");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Processes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_Companies_CompanyId",
                table: "Processes",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processes_Companies_CompanyId",
                table: "Processes");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Processes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_Companies_CompanyId",
                table: "Processes",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
