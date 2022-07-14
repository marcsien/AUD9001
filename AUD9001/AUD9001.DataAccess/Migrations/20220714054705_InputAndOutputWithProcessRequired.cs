using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUD9001.DataAccess.Migrations
{
    public partial class InputAndOutputWithProcessRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inputs_Processes_ProcessId",
                table: "Inputs");

            migrationBuilder.DropForeignKey(
                name: "FK_Outputs_Processes_ProcessId",
                table: "Outputs");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessId",
                table: "Outputs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProcessId",
                table: "Inputs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inputs_Processes_ProcessId",
                table: "Inputs",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Outputs_Processes_ProcessId",
                table: "Outputs",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inputs_Processes_ProcessId",
                table: "Inputs");

            migrationBuilder.DropForeignKey(
                name: "FK_Outputs_Processes_ProcessId",
                table: "Outputs");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessId",
                table: "Outputs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessId",
                table: "Inputs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Inputs_Processes_ProcessId",
                table: "Inputs",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Outputs_Processes_ProcessId",
                table: "Outputs",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "Id");
        }
    }
}
