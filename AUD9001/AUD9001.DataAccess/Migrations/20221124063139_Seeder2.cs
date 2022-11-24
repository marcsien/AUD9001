using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUD9001.DataAccess.Migrations
{
    public partial class Seeder2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Inputs",
                columns: new[] { "Id", "AdditionDate", "DeleteDate", "Description", "Name", "ProcessId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 24, 7, 31, 38, 718, DateTimeKind.Local).AddTicks(6199), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DummyInputDescription1", "DummyInput1", 1 },
                    { 2, new DateTime(2022, 11, 24, 7, 31, 38, 718, DateTimeKind.Local).AddTicks(6235), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DummyInputDescription2", "DummyInput2", 1 },
                    { 3, new DateTime(2022, 11, 24, 7, 31, 38, 718, DateTimeKind.Local).AddTicks(6238), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DummyInputDescription3", "DummyInput3", 1 }
                });

            migrationBuilder.InsertData(
                table: "ManagementReviews",
                columns: new[] { "Id", "CompanyId", "Date", "Number" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 11, 24, 7, 31, 38, 718, DateTimeKind.Local).AddTicks(6312), 1 },
                    { 2, 1, new DateTime(2022, 11, 24, 7, 31, 38, 718, DateTimeKind.Local).AddTicks(6318), 2 },
                    { 3, 1, new DateTime(2022, 11, 24, 7, 31, 38, 718, DateTimeKind.Local).AddTicks(6320), 3 }
                });

            migrationBuilder.InsertData(
                table: "Outputs",
                columns: new[] { "Id", "AdditionDate", "DeleteDate", "Description", "Name", "ProcessId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 24, 7, 31, 38, 718, DateTimeKind.Local).AddTicks(6276), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DummyOutputDescription1", "DummyOutput1", 1 },
                    { 2, new DateTime(2022, 11, 24, 7, 31, 38, 718, DateTimeKind.Local).AddTicks(6279), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DummyOutputDescription1", "DummyOutput1", 1 },
                    { 3, new DateTime(2022, 11, 24, 7, 31, 38, 718, DateTimeKind.Local).AddTicks(6282), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DummyOutputDescription1", "DummyOutput1", 1 }
                });

            migrationBuilder.InsertData(
                table: "Processes",
                columns: new[] { "Id", "CompanyId", "Description", "Name" },
                values: new object[] { 2, 1, "Proces kontrolujący jakość", "Kontrola Jakości" });

            migrationBuilder.InsertData(
                table: "Inputs",
                columns: new[] { "Id", "AdditionDate", "DeleteDate", "Description", "Name", "ProcessId" },
                values: new object[,]
                {
                    { 4, new DateTime(2022, 11, 24, 7, 31, 38, 718, DateTimeKind.Local).AddTicks(6240), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DummyInputDescription4", "DummyInput4", 2 },
                    { 5, new DateTime(2022, 11, 24, 7, 31, 38, 718, DateTimeKind.Local).AddTicks(6243), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DummyInputDescription5", "DummyInput5", 2 },
                    { 6, new DateTime(2022, 11, 24, 7, 31, 38, 718, DateTimeKind.Local).AddTicks(6245), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DummyInputDescription6", "DummyInput6", 2 }
                });

            migrationBuilder.InsertData(
                table: "Outputs",
                columns: new[] { "Id", "AdditionDate", "DeleteDate", "Description", "Name", "ProcessId" },
                values: new object[,]
                {
                    { 4, new DateTime(2022, 11, 24, 7, 31, 38, 718, DateTimeKind.Local).AddTicks(6284), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DummyOutputDescription1", "DummyOutput1", 2 },
                    { 5, new DateTime(2022, 11, 24, 7, 31, 38, 718, DateTimeKind.Local).AddTicks(6286), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DummyOutputDescription1", "DummyOutput1", 2 },
                    { 6, new DateTime(2022, 11, 24, 7, 31, 38, 718, DateTimeKind.Local).AddTicks(6289), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DummyOutputDescription1", "DummyOutput1", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inputs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Inputs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Inputs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Inputs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Inputs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Inputs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ManagementReviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ManagementReviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ManagementReviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Processes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
