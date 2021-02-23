using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sud.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "297cfd2d-af85-46ac-b35f-2803d875589f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99c091eb-8287-49f3-b3bd-5ce3eb95fe65");

            migrationBuilder.AlterColumn<string>(
                name: "PickUpDay",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DropOffDay",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "746ed44f-f223-46f2-b6ed-46c24803f019");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d146f3aa-43a9-4fa0-9458-a87bf95dbc89");

            migrationBuilder.AlterColumn<string>(
                name: "PickUpDay",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DropOffDay",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "99c091eb-8287-49f3-b3bd-5ce3eb95fe65", "8555bdca-ae72-4ebf-ab91-6ef1aa3c7953", "Employee", "EMPLOYEE" },
                    { "297cfd2d-af85-46ac-b35f-2803d875589f", "1fd73e6e-2c96-496e-ba2c-103c7dfb6f23", "Customer", "CUSTOMER" }
                });

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
    }
}
