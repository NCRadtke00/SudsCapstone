using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sud.Migrations
{
    public partial class dropoff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bcba3bf0-f1b7-4728-a40c-2117b8b21f0a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d69d46fa-6a5e-448b-8136-a999fce30f06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e32bdd6a-d811-42f5-90ef-2bdfd3870887");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c9c3e4ee-37f8-40d7-b1a6-e88cc2139a11", "799d896d-9405-453c-83f9-98dd3ae15643", "Admin", "ADMIN" },
                    { "8d33a528-a704-4a54-815c-080d66d9a07a", "22cefff8-201a-429d-9c00-c3c02cf474df", "Employee", "EMPLOYEE" },
                    { "1c7322e6-12db-4b51-8304-5c93f4c1d540", "d38fb8da-0a12-4b8e-8a21-12a60fbe21de", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "DropOffDays",
                columns: new[] { "Id", "Date" },
                values: new object[,]
                {
                    { 1, "Monday" },
                    { 2, "Tuesday" },
                    { 3, "Wednesday" },
                    { 4, "Thursday" },
                    { 5, "Friday" },
                    { 6, "Saturday" },
                    { 7, "Sunday" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderPlaced",
                value: new DateTime(2020, 11, 18, 14, 37, 11, 275, DateTimeKind.Local).AddTicks(7703));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderPlaced",
                value: new DateTime(2020, 11, 18, 14, 37, 11, 283, DateTimeKind.Local).AddTicks(2725));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 11, 21, 14, 37, 11, 284, DateTimeKind.Local).AddTicks(263));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 11, 21, 14, 37, 11, 284, DateTimeKind.Local).AddTicks(2793));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c7322e6-12db-4b51-8304-5c93f4c1d540");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d33a528-a704-4a54-815c-080d66d9a07a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9c3e4ee-37f8-40d7-b1a6-e88cc2139a11");

            migrationBuilder.DeleteData(
                table: "DropOffDays",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DropOffDays",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DropOffDays",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DropOffDays",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DropOffDays",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DropOffDays",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DropOffDays",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e32bdd6a-d811-42f5-90ef-2bdfd3870887", "ecedba8b-e453-4b48-b35c-865d2746d65b", "Admin", "ADMIN" },
                    { "bcba3bf0-f1b7-4728-a40c-2117b8b21f0a", "64e6fcfc-2ca8-48fc-b206-a8dcdfe6d66f", "Employee", "EMPLOYEE" },
                    { "d69d46fa-6a5e-448b-8136-a999fce30f06", "54b3e2bd-6b3a-4c7f-8de4-d7b801d300ee", "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderPlaced",
                value: new DateTime(2020, 11, 17, 15, 54, 5, 305, DateTimeKind.Local).AddTicks(4176));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderPlaced",
                value: new DateTime(2020, 11, 17, 15, 54, 5, 310, DateTimeKind.Local).AddTicks(67));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 11, 20, 15, 54, 5, 310, DateTimeKind.Local).AddTicks(6752));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 11, 20, 15, 54, 5, 310, DateTimeKind.Local).AddTicks(8543));
        }
    }
}
