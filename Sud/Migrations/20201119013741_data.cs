using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sud.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9182ae50-1018-4e01-8b56-7d2f468fdf90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fda57f4-7232-4de2-b153-ae13dadd0f49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7541da2-8a72-44e3-b75e-e8e479d29cd0");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Orders",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7de2af4d-a9f7-476e-a253-c2e3f807a079", "c437a224-cfb5-42e9-b358-b60d37fb2d82", "Admin", "ADMIN" },
                    { "02b1d392-57da-4a29-8703-7ea742a9e809", "1c8e046c-7013-4d1d-8d02-51392eee3111", "Employee", "EMPLOYEE" },
                    { "60f6dc4d-6009-41fa-8536-d5ce6e45499b", "c595f12c-7fc2-435d-a1c3-cc09abae05ac", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "AddressLine1", "AddressLine2", "City", "Country", "Email", "FirstName", "LastName", "OrderPlaced", "OrderTotal", "PhoneNumber", "State", "UserId", "ZipCode" },
                values: new object[,]
                {
                    { 1, "909 E Locust St", null, "Milwaukee", "United State", "NevS@gmail.com", "Nevin", "Sei", new DateTime(2020, 11, 15, 19, 37, 40, 672, DateTimeKind.Local).AddTicks(2572), 95.00m, "4142292255", "Wisconsin", null, "53212" },
                    { 2, "1872 N Commerce St", null, "Milwaukee", "United State", "NJac@gmail.com", "Nick", "Jac", new DateTime(2020, 11, 15, 19, 37, 40, 675, DateTimeKind.Local).AddTicks(251), 20.00m, "4142293030", "Wisconsin", null, "53212" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Laundry done for you!", "Laundry" },
                    { 2, "Dry cleaning at your convience!", "DryCleaning" },
                    { 3, "Miscellaneous fee's.", "Fee's" }
                });

            migrationBuilder.InsertData(
                table: "Clothes",
                columns: new[] { "Id", "ImageUrl", "IsPopularItem", "Name", "Price", "ServicesId" },
                values: new object[,]
                {
                    { 1, " https://www.dhresource.com/0x0/f2/albu/g8/M00/9D/98/rBVaV16NgMmAfTd8AAMVeqw4gzY314.jpg/set-of-4-drawstring-mesh-laundry-bag-wash.jpg ", false, " 50lb bag", 7.00m, 1 },
                    { 2, " https://www.dhresource.com/0x0/f2/albu/g8/M00/9D/98/rBVaV16NgMmAfTd8AAMVeqw4gzY314.jpg/set-of-4-drawstring-mesh-laundry-bag-wash.jpg", true, " 40lb bag", 6.00m, 1 },
                    { 3, " https://www.dhresource.com/0x0/f2/albu/g8/M00/9D/98/rBVaV16NgMmAfTd8AAMVeqw4gzY314.jpg/set-of-4-drawstring-mesh-laundry-bag-wash.jpg", false, " 30lb bag", 5.00m, 1 },
                    { 4, " https://www.dhresource.com/0x0/f2/albu/g8/M00/9D/98/rBVaV16NgMmAfTd8AAMVeqw4gzY314.jpg/set-of-4-drawstring-mesh-laundry-bag-wash.jpg", false, " 20lb bag", 4.00m, 1 },
                    { 10, " https://images-na.ssl-images-amazon.com/images/I/814MCsg4BrL._AC_UL1500_.jpg ", false, " 2PC SUIT", 10.50m, 2 },
                    { 11, " https://ae01.alicdn.com/kf/H38607873036b479183e42158db72def2A/Cultiseed-Female-Dress-Set-2020-Women-New-Sexy-Strapless-Puff-Sleeve-2pc-Dress-Set-Suits-Ladies.jpg", false, " 2PC DRESS", 11.50m, 2 },
                    { 12, "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQQsevtEvUk7_dBBHP9x8Vwg25ILuQhBVnJUg&usqp=CAU", true, "3PC SUIT", 12.50m, 2 },
                    { 13, " https://media.missguided.com/i/missguided/TW423587_01 ", false, "BLOUSE (WOMAN’S)", 3.60m, 2 },
                    { 14, " https://www.dhresource.com/0x0/f2/albu/g8/M00/9D/98/rBVaV16NgMmAfTd8AAMVeqw4gzY314.jpg/set-of-4-drawstring-mesh-laundry-bag-wash.jpg", true, "DRESS", 7.70m, 2 },
                    { 15, "https://i.etsystatic.com/13385002/r/il/af0dbd/1197944229/il_570xN.1197944229_8bpp.jpg", false, "DRESS-FANCY/EVENING", 9.60m, 2 },
                    { 5, " https://4jlaundromat.com/wp-content/uploads/2016/10/shutterstock_250385533.jpg", true, " Fold laundry", 2.00m, 3 },
                    { 6, " https://www.rexrx.com/_next/static/images/free-delivery-0a4599ba95770c3c93c524d1626e7d76.png", false, " Delivery fee", 4.00m, 3 },
                    { 7, " https://images.squarespace-cdn.com/content/v1/5e599564293347515fe2eabc/1583701071232-CFTFT5DHM16PJ08P6M6D/ke17ZwdGBToddI8pDm48kEoJmA0Abk1RrrM77uDVNFhZw-zPPgdn4jUwVcJE1ZvWQUxwkmyExglNqGp0IvTJZamWLI2zvYWH8K3-s_4yszcp2ryTI0HqTOaaUohrI8PIecCtomI4OQXCfULyDTUGqI_q-TQiniCLvIy8yIJMAmQKMshLAGzx4R3EDFOm1kBS/rushservice.jpg", false, "Same day Rush Service", 20.00m, 3 },
                    { 8, " https://images.squarespace-cdn.com/content/v1/5e599564293347515fe2eabc/1583701071232-CFTFT5DHM16PJ08P6M6D/ke17ZwdGBToddI8pDm48kEoJmA0Abk1RrrM77uDVNFhZw-zPPgdn4jUwVcJE1ZvWQUxwkmyExglNqGp0IvTJZamWLI2zvYWH8K3-s_4yszcp2ryTI0HqTOaaUohrI8PIecCtomI4OQXCfULyDTUGqI_q-TQiniCLvIy8yIJMAmQKMshLAGzx4R3EDFOm1kBS/rushservice.jpg ", true, "Next day Rush Service", 10.00m, 3 },
                    { 9, " https://images.allergybuyersclub.com/img/CD-CO-WLAS-500.jpg ", false, " Additional Charge for Down, Silk, and other rare fabrics materials", 5.00m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "ClothesId", "Date", "Description", "Grade", "IdentityUserId", "Title" },
                values: new object[] { 1, 2, new DateTime(2020, 11, 18, 19, 37, 40, 675, DateTimeKind.Local).AddTicks(3313), "Eveything smelled like a fresh medow, and was folded perfectly.", 4, null, "WOW" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "ClothesId", "Date", "Description", "Grade", "IdentityUserId", "Title" },
                values: new object[] { 2, 3, new DateTime(2020, 11, 18, 19, 37, 40, 675, DateTimeKind.Local).AddTicks(4296), "The guy picked everthing up, and dropped it off 6 hours later.", 5, null, "Legen-dry" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

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

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9182ae50-1018-4e01-8b56-7d2f468fdf90", "6ca48411-5835-4b25-afe6-a98c8431183b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e7541da2-8a72-44e3-b75e-e8e479d29cd0", "56ee5791-2e3c-4697-8bca-f577a7c411a0", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9fda57f4-7232-4de2-b153-ae13dadd0f49", "0b453a2e-e1ed-4ae3-b689-272ab3d0156a", "Customer", "CUSTOMER" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
