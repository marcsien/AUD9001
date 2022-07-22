using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUD9001.DataAccess.Migrations
{
    public partial class ManagementReviewCompanyRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManagementReviews_Companies_CompanyId",
                table: "ManagementReviews");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "ManagementReviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ManagementReviews_Companies_CompanyId",
                table: "ManagementReviews",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManagementReviews_Companies_CompanyId",
                table: "ManagementReviews");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "ManagementReviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ManagementReviews_Companies_CompanyId",
                table: "ManagementReviews",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
