using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ltddnc_backend.Migrations
{
    public partial class DatabaseV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumns: new[] { "IdUser", "IdProduct" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger.png?alt=media&token=d5d6078f-0031-47cb-83ca-cf84c01087f6");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/chicken.png?alt=media&token=834b99a6-154f-473f-8211-f0ac62729c9b");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/pasta.png?alt=media&token=e16f504a-6f46-4a83-bae3-670670a16220");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/soft-drink.png?alt=media&token=c9193527-5b37-4085-aaa3-21cd8e9bc933");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/icecream.png?alt=media&token=3f35c767-b6d7-4dff-ac2f-826227345841");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AvgRating", "CreatedDate", "Description", "IdCategory", "Image", "Name", "State", "Stock", "UnitPrice" },
                values: new object[,]
                {
                    { 13, 0.0, new DateTime(2022, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gà buffalo", 2, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/ga-buffalo.jpg?alt=media&token=355a579e-9f76-4af2-bb8c-11cdf715751e", "Gà sốt buffalo", 1, 100, 68000.0 },
                    { 14, 0.0, new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burger cá", 1, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-ca.png?alt=media&token=4246454a-83d3-4cb6-acac-e663a8c2af1d", "Burger cá", 1, 100, 48000.0 },
                    { 15, 0.0, new DateTime(2022, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burger bò terayaki", 1, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-bo-teriyaki.png?alt=media&token=1b014618-e31a-4d0d-97e2-617d3f242315", "Burger bò teriyaki", 1, 100, 50000.0 },
                    { 19, 0.0, new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burger bò nướng khoai tây lát", 1, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/10-burger-khoai-tay-lat_1.jpg?alt=media&token=20bbb62d-f4a5-4b03-ab3e-ebee8c87c052", "Burger bò nướng khoai tây", 1, 100, 65000.0 },
                    { 16, 0.0, new DateTime(2021, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burger phô mai", 1, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-phomai.png?alt=media&token=47f66d33-d901-4a06-a243-c3ac564d92f7", "Burger phô mai", 1, 100, 50000.0 },
                    { 17, 0.0, new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burger bò nướng whopper", 1, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/16-burgerwhopper_2.jpg?alt=media&token=d65d4da1-dbce-4627-b18d-cb716de0a3e5", "Burger bò nướng Whopper", 1, 100, 115000.0 },
                    { 24, 0.0, new DateTime(2021, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coca cola", 4, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/coca.jpg?alt=media&token=f4b46061-5236-4bd7-9e9f-bdcda2385fbf", "Coca cola", 1, 100, 22000.0 },
                    { 23, 0.0, new DateTime(2021, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nước suối", 4, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/nuoc-loc.jpg?alt=media&token=7251e6b9-db6f-4a80-a2e5-7bf5cac982d0", "Nước suối", 1, 100, 20000.0 },
                    { 22, 0.0, new DateTime(2021, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kem cuộn thái lan", 5, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/kem-cuon-thai-lan.jpg?alt=media&token=a5404ad2-d105-489c-8028-a4baa582e50d", "Kem cuộn thái lan", 1, 100, 35000.0 },
                    { 21, 0.0, new DateTime(2021, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kem dâu", 5, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/kemdau.jpg?alt=media&token=b57f6b9b-d395-458b-8614-decb1c2f4a6e", "Kem dâu", 1, 100, 35000.0 },
                    { 20, 0.0, new DateTime(2021, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kem vani", 5, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/kemvani.jpg?alt=media&token=517fe0ed-4d7c-4bc0-99a6-cb51b36cf63d", "Kem vani", 1, 100, 28000.0 },
                    { 18, 0.0, new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burger 2 miếng bò phủ phô mai", 1, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/2-mieng-bo-burger-phomai.jpg?alt=media&token=a0e4ce1f-96c0-417a-9749-4ae0a9b60659", "Burger 2 miếng bò", 1, 100, 85000.0 },
                    { 12, 0.0, new DateTime(2022, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gà chiên giòn phủ lớp phô mai béo ngậy", 2, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/ga-phomai.png?alt=media&token=724597ab-d4f5-4583-b35a-a8538cd5d8b5", "Gà sốt phô mai", 1, 100, 60000.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "IdUser", "IdProduct", "Quantity" },
                values: new object[] { 3, 1, 20 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger.png?alt=media&token=ca9698cb-e20f-4b4a-8403-9e5605a506b7");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/chicken.png?alt=media&token=0428fbff-b7e6-4a03-8fb5-6e9c7168fec4");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/spaghetti.png?alt=media&token=fdeba4a1-a640-4f61-9623-9c2cf50e641d");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/soft-drink.png?alt=media&token=6e742231-8482-4fec-815a-14a360abbc69");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/icecream.png?alt=media&token=39a3faad-b029-4e50-aed2-680e203a8b94");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
