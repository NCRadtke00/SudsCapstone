using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sud.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16b170f6-23d8-4a14-8197-4e8a47c508d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e89aee6a-f68a-4699-8f23-072db79aef06");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "99c091eb-8287-49f3-b3bd-5ce3eb95fe65", "8555bdca-ae72-4ebf-ab91-6ef1aa3c7953", "Employee", "EMPLOYEE" },
                    { "297cfd2d-af85-46ac-b35f-2803d875589f", "1fd73e6e-2c96-496e-ba2c-103c7dfb6f23", "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: " Additional Charge for Down");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "EVENING DRESS");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 2, 18, 1, 10, 4, 94, DateTimeKind.Local).AddTicks(5103));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 2, 18, 1, 10, 4, 97, DateTimeKind.Local).AddTicks(5857));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "297cfd2d-af85-46ac-b35f-2803d875589f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99c091eb-8287-49f3-b3bd-5ce3eb95fe65");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e89aee6a-f68a-4699-8f23-072db79aef06", "219d0222-aee9-477b-a990-94d36bec0dbd", "Employee", "EMPLOYEE" },
                    { "16b170f6-23d8-4a14-8197-4e8a47c508d4", "854ad243-3cf4-4675-8960-1a8f36cbc72e", "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: " Additional Charge for Down, Silk, and other rare fabrics materials");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "DRESS-FANCY/EVENING");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 2, 15, 14, 10, 11, 676, DateTimeKind.Local).AddTicks(8338));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 2, 15, 14, 10, 11, 680, DateTimeKind.Local).AddTicks(3869));
        }
    }
}
