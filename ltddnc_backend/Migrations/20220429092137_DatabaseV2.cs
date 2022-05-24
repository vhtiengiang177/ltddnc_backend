using Microsoft.EntityFrameworkCore.Migrations;

namespace ltddnc_backend.Migrations
{
    public partial class DatabaseV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Categories",
                nullable: true);

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
                column: "Image",
                value: "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/ga-sot-dau.jpg?alt=media&token=168bac33-bfc6-445b-86cb-4b8b34410808");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-mozzarella.jpg?alt=media&token=3347cfdb-aea4-4008-8ec2-ddaad4f58000");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/mi-y.jpg?alt=media&token=f31dd329-e97c-4a27-8c6a-24462a1ff050");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/mi-y-thit-bo.jpg?alt=media&token=c4bcc54f-2810-4079-a499-8f2622585454");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Nước ngọt có ga 7Up", "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/7up.jpg?alt=media&token=b84b0fed-f68b-486c-b67d-5b989f54609f", "7Up" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Image",
                value: "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/nuoc-cam.jpg?alt=media&token=e195a521-278b-450f-8027-69164bfeae1b");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Image",
                value: "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-bulgogi.jpg?alt=media&token=e387c83a-c0c8-454a-91c3-f374a32e9411");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "Image",
                value: "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-ga.jpg?alt=media&token=377b21ad-58af-42b6-82c6-5951930f1a10");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IdCategory", "Image", "Name", "State", "Stock", "UnitPrice" },
                values: new object[] { 11, "Burger nhân tôm", 2, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-tom-cua.jpg?alt=media&token=abffb82e-2d47-420b-9d64-fa77325ec7db", "Burger Tôm", 1, 100, 60000.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "7Up Dưa Lưới Đào", null, "7Up Dưa Lưới Đào" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "Image",
                value: null);
        }
    }
}
