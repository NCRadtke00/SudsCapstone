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
                keyValue: "4bfc3cf6-51bb-475b-9a13-1ea31d25b918");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72b52d0e-2501-41c9-9876-a1c7ad8ed72a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "891c90bd-eae6-4ae9-ac26-935c9a4dec1b");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId1",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ce0d3de1-e87e-4d67-aff7-15b6e0d02311", "3a8e41f5-0235-433c-b4f2-b40a607fc39a", "Admin", "ADMIN" },
                    { "40cf51b9-9571-4769-af81-b415085c6111", "5cb25ca9-ec50-4899-abdb-220f2ac438b5", "Employee", "EMPLOYEE" },
                    { "10f1e89a-d2f9-4e5b-b5ca-50cd1e415ea8", "7ea6aa06-5909-4eac-af87-2957d5fa0a6f", "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 12, 16, 13, 9, 0, 934, DateTimeKind.Local).AddTicks(9575));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 12, 16, 13, 9, 0, 940, DateTimeKind.Local).AddTicks(5062));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ImageId1",
                table: "Orders",
                column: "ImageId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Images_ImageId1",
                table: "Orders",
                column: "ImageId1",
                principalTable: "Images",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Images_ImageId1",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ImageId1",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10f1e89a-d2f9-4e5b-b5ca-50cd1e415ea8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40cf51b9-9571-4769-af81-b415085c6111");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce0d3de1-e87e-4d67-aff7-15b6e0d02311");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ImageId1",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "72b52d0e-2501-41c9-9876-a1c7ad8ed72a", "2c1c350d-77f2-4a21-b8e6-36e39cbae3c8", "Admin", "ADMIN" },
                    { "4bfc3cf6-51bb-475b-9a13-1ea31d25b918", "c448324c-4805-49fe-b814-de0c2c7fd38e", "Employee", "EMPLOYEE" },
                    { "891c90bd-eae6-4ae9-ac26-935c9a4dec1b", "c8fd6ad6-9547-4ce9-8b1b-0b84b27a6d9d", "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 12, 15, 16, 26, 17, 721, DateTimeKind.Local).AddTicks(7771));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 12, 15, 16, 26, 17, 726, DateTimeKind.Local).AddTicks(802));
        }
    }
}
