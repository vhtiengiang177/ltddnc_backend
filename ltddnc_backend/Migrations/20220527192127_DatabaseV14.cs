using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ltddnc_backend.Migrations
{
    public partial class DatabaseV14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumns: new[] { "Id", "IdProduct", "IdUser" },
                keyValues: new object[] { 1, 1, 3 });

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumns: new[] { "Id", "IdProduct", "IdUser" },
                keyValues: new object[] { 2, 1, 3 });

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumns: new[] { "Id", "IdProduct", "IdUser" },
                keyValues: new object[] { 3, 2, 3 });

            migrationBuilder.AddColumn<string>(
                name: "ImageProduct",
                table: "Reviews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameProduct",
                table: "Reviews",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageProduct",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "NameProduct",
                table: "Reviews");

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "IdProduct", "IdUser", "Comment", "Date", "IdOrder", "Image", "Name", "OrderId", "Rating" },
                values: new object[] { 1, 1, 3, "Good", new DateTime(2021, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/icecream.png?alt=media&token=39a3faad-b029-4e50-aed2-680e203a8b94", "Bao", null, 5.0 });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "IdProduct", "IdUser", "Comment", "Date", "IdOrder", "Image", "Name", "OrderId", "Rating" },
                values: new object[] { 2, 1, 3, "Bad", new DateTime(2021, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/icecream.png?alt=media&token=39a3faad-b029-4e50-aed2-680e203a8b94", "Bao", null, 1.0 });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "IdProduct", "IdUser", "Comment", "Date", "IdOrder", "Image", "Name", "OrderId", "Rating" },
                values: new object[] { 3, 2, 3, "Very Good", new DateTime(2021, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/icecream.png?alt=media&token=39a3faad-b029-4e50-aed2-680e203a8b94", "Bao", null, 5.0 });
        }
    }
}
