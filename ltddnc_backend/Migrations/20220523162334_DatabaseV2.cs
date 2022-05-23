using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ltddnc_backend.Migrations
{
    public partial class DatabaseV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    IdProduct = table.Column<int>(nullable: false),
                    IdUser = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    UserIdAccount = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => new { x.IdProduct, x.IdUser, x.Date });
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserIdAccount",
                        column: x => x.UserIdAccount,
                        principalTable: "Users",
                        principalColumn: "IdAccount",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "IdProduct", "IdUser", "Date", "Comment", "Image", "Name", "ProductId", "Rating", "UserIdAccount" },
                values: new object[] { 1, 3, new DateTime(2022, 5, 23, 23, 23, 33, 519, DateTimeKind.Local).AddTicks(1114), "Good", null, "Bao", null, 5, null });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "IdProduct", "IdUser", "Date", "Comment", "Image", "Name", "ProductId", "Rating", "UserIdAccount" },
                values: new object[] { 1, 3, new DateTime(2022, 5, 23, 23, 23, 33, 520, DateTimeKind.Local).AddTicks(2309), "Bad", null, "Bao", null, 1, null });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "IdProduct", "IdUser", "Date", "Comment", "Image", "Name", "ProductId", "Rating", "UserIdAccount" },
                values: new object[] { 1, 3, new DateTime(2022, 5, 23, 23, 23, 33, 520, DateTimeKind.Local).AddTicks(2379), "Very Good", null, "Bao", null, 5, null });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserIdAccount",
                table: "Reviews",
                column: "UserIdAccount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");
        }
    }
}
