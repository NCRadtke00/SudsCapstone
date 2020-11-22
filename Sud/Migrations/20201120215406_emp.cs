using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sud.Migrations
{
    public partial class emp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<int>(
                name: "ZipCode",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ConfirmDropoff",
                table: "Customer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ConfirmPickUp",
                table: "Customer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DropOffDayId",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PickUpDayId",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DropOffDays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropOffDays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PickUpDays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickUpDays", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "PickUpDays",
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

            migrationBuilder.CreateIndex(
                name: "IX_Customer_DropOffDayId",
                table: "Customer",
                column: "DropOffDayId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PickUpDayId",
                table: "Customer",
                column: "PickUpDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_DropOffDays_DropOffDayId",
                table: "Customer",
                column: "DropOffDayId",
                principalTable: "DropOffDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_PickUpDays_PickUpDayId",
                table: "Customer",
                column: "PickUpDayId",
                principalTable: "PickUpDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_DropOffDays_DropOffDayId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_PickUpDays_PickUpDayId",
                table: "Customer");

            migrationBuilder.DropTable(
                name: "DropOffDays");

            migrationBuilder.DropTable(
                name: "PickUpDays");

            migrationBuilder.DropIndex(
                name: "IX_Customer_DropOffDayId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_PickUpDayId",
                table: "Customer");

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

            migrationBuilder.DropColumn(
                name: "City",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ConfirmDropoff",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ConfirmPickUp",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "DropOffDayId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PickUpDayId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

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
        }
    }
}
