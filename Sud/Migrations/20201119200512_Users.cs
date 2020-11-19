using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sud.Migrations
{
    public partial class Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02b1d392-57da-4a29-8703-7ea742a9e809");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60f6dc4d-6009-41fa-8536-d5ce6e45499b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7de2af4d-a9f7-476e-a253-c2e3f807a079");

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35574081-6e33-48d1-b933-115cb6cb336f", "02bb1b19-3fb0-4894-b150-0a8e66067034", "Admin", "ADMIN" },
                    { "c8c9904e-036c-48e4-bacb-50c0cdfd1869", "8a3d88a0-8615-48e4-8413-f29d78cefa25", "Employee", "EMPLOYEE" },
                    { "076e796b-b34d-454a-8f79-59866a3c1b0e", "c4ba2a62-5d01-4641-8906-da1c7b124674", "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderPlaced",
                value: new DateTime(2020, 11, 16, 14, 5, 11, 407, DateTimeKind.Local).AddTicks(3931));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderPlaced",
                value: new DateTime(2020, 11, 16, 14, 5, 11, 409, DateTimeKind.Local).AddTicks(8116));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 11, 19, 14, 5, 11, 410, DateTimeKind.Local).AddTicks(861));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 11, 19, 14, 5, 11, 410, DateTimeKind.Local).AddTicks(1805));

            migrationBuilder.CreateIndex(
                name: "IX_Customer_IdentityUserId",
                table: "Customer",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_IdentityUserId",
                table: "Employee",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "076e796b-b34d-454a-8f79-59866a3c1b0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35574081-6e33-48d1-b933-115cb6cb336f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8c9904e-036c-48e4-bacb-50c0cdfd1869");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7de2af4d-a9f7-476e-a253-c2e3f807a079", "c437a224-cfb5-42e9-b358-b60d37fb2d82", "Admin", "ADMIN" },
                    { "02b1d392-57da-4a29-8703-7ea742a9e809", "1c8e046c-7013-4d1d-8d02-51392eee3111", "Employee", "EMPLOYEE" },
                    { "60f6dc4d-6009-41fa-8536-d5ce6e45499b", "c595f12c-7fc2-435d-a1c3-cc09abae05ac", "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderPlaced",
                value: new DateTime(2020, 11, 15, 19, 37, 40, 672, DateTimeKind.Local).AddTicks(2572));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderPlaced",
                value: new DateTime(2020, 11, 15, 19, 37, 40, 675, DateTimeKind.Local).AddTicks(251));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 11, 18, 19, 37, 40, 675, DateTimeKind.Local).AddTicks(3313));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 11, 18, 19, 37, 40, 675, DateTimeKind.Local).AddTicks(4296));
        }
    }
}
