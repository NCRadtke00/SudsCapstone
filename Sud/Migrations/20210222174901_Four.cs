using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sud.Migrations
{
    public partial class Four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "746ed44f-f223-46f2-b6ed-46c24803f019");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d146f3aa-43a9-4fa0-9458-a87bf95dbc89");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8d565a0e-fccb-42f5-88d5-8461a91bd3a2", "ca1e6cf4-328e-41ac-a32e-7a46d509ee22", "Employee", "EMPLOYEE" },
                    { "1d8c09a5-c79c-4313-9d99-033e193bf305", "d24ca2ce-edaf-48f3-8edf-8844a5a03fb7", "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 2, 22, 11, 49, 1, 170, DateTimeKind.Local).AddTicks(410));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 2, 22, 11, 49, 1, 172, DateTimeKind.Local).AddTicks(5822));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d8c09a5-c79c-4313-9d99-033e193bf305");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d565a0e-fccb-42f5-88d5-8461a91bd3a2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "746ed44f-f223-46f2-b6ed-46c24803f019", "df3b4875-c1ff-4dc1-888f-56be7e17e5bf", "Employee", "EMPLOYEE" },
                    { "d146f3aa-43a9-4fa0-9458-a87bf95dbc89", "7ac4311e-faa8-4c01-b828-76df55be11f9", "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 2, 22, 11, 38, 35, 969, DateTimeKind.Local).AddTicks(7834));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 2, 22, 11, 38, 35, 972, DateTimeKind.Local).AddTicks(4655));
        }
    }
}
