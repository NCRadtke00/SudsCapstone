using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sud.Migrations
{
    public partial class Statusbar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c400ddc-fd2e-48dc-8d09-5b0d472136d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e96261c-e87f-4d92-a0e8-61e132b25812");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fd24bb6-c5ee-4cdd-99d2-01a2cd719783");

            migrationBuilder.AddColumn<bool>(
                name: "ConfirmCleaning",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "StatusBar",
                table: "Orders",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bc6b9ba6-fdd5-4c08-a128-0a301d830a7f", "862d47cd-415e-4236-a5de-3fcff287d4c0", "Admin", "ADMIN" },
                    { "474edf54-a408-42ef-816f-47c2a78daead", "bd3c804f-849e-4069-bcae-6e5fa6ce9b16", "Employee", "EMPLOYEE" },
                    { "2464e133-e88b-4883-8fb3-c5acddf08e7d", "c83a9fa6-863b-4211-8913-c74bfe1c76be", "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 12, 23, 17, 51, 21, 759, DateTimeKind.Local).AddTicks(7341));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 12, 23, 17, 51, 21, 763, DateTimeKind.Local).AddTicks(1100));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2464e133-e88b-4883-8fb3-c5acddf08e7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "474edf54-a408-42ef-816f-47c2a78daead");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc6b9ba6-fdd5-4c08-a128-0a301d830a7f");

            migrationBuilder.DropColumn(
                name: "ConfirmCleaning",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StatusBar",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c400ddc-fd2e-48dc-8d09-5b0d472136d9", "bde4bb61-7868-4a93-8db8-10bd179a7d6c", "Admin", "ADMIN" },
                    { "6e96261c-e87f-4d92-a0e8-61e132b25812", "cd81fa09-0b55-4595-b573-a7089dc9d03a", "Employee", "EMPLOYEE" },
                    { "9fd24bb6-c5ee-4cdd-99d2-01a2cd719783", "3299da0f-1802-4d2d-885a-9b4a7e91b8bc", "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 12, 18, 17, 37, 3, 673, DateTimeKind.Local).AddTicks(3636));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 12, 18, 17, 37, 3, 676, DateTimeKind.Local).AddTicks(2950));
        }
    }
}
