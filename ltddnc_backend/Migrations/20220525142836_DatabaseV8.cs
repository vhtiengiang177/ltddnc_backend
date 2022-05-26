using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ltddnc_backend.Migrations
{
    public partial class DatabaseV8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Stock = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<double>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    IdCategory = table.Column<int>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    IdRole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdAccount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdAccount);
                    table.ForeignKey(
                        name: "FK_Users_Accounts_IdAccount",
                        column: x => x.IdAccount,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false),
                    IdProduct = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => new { x.IdUser, x.IdProduct });
                    table.ForeignKey(
                        name: "FK_Carts_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdAccount",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false),
                    IdProduct = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => new { x.IdUser, x.IdProduct });
                    table.ForeignKey(
                        name: "FK_Favorites_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdAccount",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalQuantity = table.Column<int>(nullable: false),
                    TotalProductPrice = table.Column<double>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IdUser = table.Column<int>(nullable: false),
                    UserIdAccount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserIdAccount",
                        column: x => x.UserIdAccount,
                        principalTable: "Users",
                        principalColumn: "IdAccount",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    IdProduct = table.Column<int>(nullable: false),
                    IdUser = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => new { x.Id, x.IdProduct, x.IdUser });
                    table.ForeignKey(
                        name: "FK_Reviews_Products_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdAccount",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    IdOrder = table.Column<int>(nullable: false),
                    IdProduct = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.IdOrder, x.IdProduct });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Image", "Name", "State" },
                values: new object[,]
                {
                    { 1, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger.png?alt=media&token=ca9698cb-e20f-4b4a-8403-9e5605a506b7", "Burger", 1 },
                    { 2, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/chicken.png?alt=media&token=0428fbff-b7e6-4a03-8fb5-6e9c7168fec4", "Gà Rán", 1 },
                    { 3, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/spaghetti.png?alt=media&token=fdeba4a1-a640-4f61-9623-9c2cf50e641d", "Mì Ý", 1 },
                    { 4, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/soft-drink.png?alt=media&token=6e742231-8482-4fec-815a-14a360abbc69", "Thức Uống", 1 },
                    { 5, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/icecream.png?alt=media&token=39a3faad-b029-4e50-aed2-680e203a8b94", "Kem", 1 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "State" },
                values: new object[,]
                {
                    { 1, "Admin", 1 },
                    { 2, "Staff", 1 }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Email", "IdRole", "Password", "State" },
                values: new object[,]
                {
                    { 1, "Admin@gmail.com", 1, "4bb0a94f21769c3b9d68cd8256a87104", 1 },
                    { 2, "Admin2@gmail.com", 1, "4bb0a94f21769c3b9d68cd8256a87104", 1 },
                    { 3, "Cust@gmail.com", 1, "4bb0a94f21769c3b9d68cd8256a87104", 1 },
                    { 4, "Cust2@gmail.com", 1, "4bb0a94f21769c3b9d68cd8256a87104", 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IdCategory", "Image", "Name", "State", "Stock", "UnitPrice" },
                values: new object[,]
                {
                    { 3, "Burger Mozzarella", 1, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-mozzarella.jpg?alt=media&token=3347cfdb-aea4-4008-8ec2-ddaad4f58000", "Burger Mozzarella", 1, 100, 50000.0 },
                    { 4, "Burger Double Double", 1, null, "Burger Double Double", 1, 100, 60000.0 },
                    { 9, "Burger Bulgogi", 1, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-bulgogi.jpg?alt=media&token=e387c83a-c0c8-454a-91c3-f374a32e9411", "Burger Bulgogi", 1, 100, 45000.0 },
                    { 10, "Burger Gà Thượng Hạng", 1, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-ga.jpg?alt=media&token=377b21ad-58af-42b6-82c6-5951930f1a10", "Burger Gà Thượng Hạng", 1, 100, 60000.0 },
                    { 11, "Burger nhân tôm", 1, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/burger-tom-cua.jpg?alt=media&token=abffb82e-2d47-420b-9d64-fa77325ec7db", "Burger Tôm", 1, 100, 60000.0 },
                    { 1, "Gà sốt với đậu", 2, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/ga-sot-dau.jpg?alt=media&token=168bac33-bfc6-445b-86cb-4b8b34410808", "Gà sốt đậu", 1, 100, 38000.0 },
                    { 2, "Gà sốt H&S", 2, null, "Gà sốt H&S", 1, 100, 38000.0 },
                    { 5, "Mì Ý", 3, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/mi-y.jpg?alt=media&token=f31dd329-e97c-4a27-8c6a-24462a1ff050", "Mì Ý", 1, 100, 35000.0 },
                    { 6, "Mì Ý Thịt Bò", 3, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/mi-y-thit-bo.jpg?alt=media&token=c4bcc54f-2810-4079-a499-8f2622585454", "Mì Ý Thịt Bò", 1, 100, 40000.0 },
                    { 7, "Nước ngọt có ga 7Up", 4, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/7up.jpg?alt=media&token=b84b0fed-f68b-486c-b67d-5b989f54609f", "7Up", 1, 100, 15000.0 },
                    { 8, "Nước Cam", 4, "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/nuoc-cam.jpg?alt=media&token=e195a521-278b-450f-8027-69164bfeae1b", "Nước Cam", 1, 100, 18000.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "IdAccount", "Address", "Image", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "282  Nguyễn Duy Trinh, phường Bình Trưng Tây, Quận 2, TP. HCM", null, "Giang", "0328801234" },
                    { 2, "Số 1 Võ Văn Ngân, TP Thủ Đức, TP. HCM", null, "Thao", "0328807278" },
                    { 3, "20 Đặng Văn Bi, phường Trường Thọ, TP Thủ Đức", null, "Bao", "0328807986" },
                    { 4, "23/2 Đường số 8, TP Thủ Đức", null, "Yen", "0328807938" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "IdUser", "IdProduct", "Quantity" },
                values: new object[] { 3, 1, 20 });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "IdProduct", "IdUser", "Comment", "Date", "Image", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, 1, 3, "Good", new DateTime(2021, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/icecream.png?alt=media&token=39a3faad-b029-4e50-aed2-680e203a8b94", "Bao", 5 },
                    { 2, 1, 3, "Bad", new DateTime(2021, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/icecream.png?alt=media&token=39a3faad-b029-4e50-aed2-680e203a8b94", "Bao", 1 },
                    { 3, 2, 3, "Very Good", new DateTime(2021, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://firebasestorage.googleapis.com/v0/b/ltddnc-flutter.appspot.com/o/icecream.png?alt=media&token=39a3faad-b029-4e50-aed2-680e203a8b94", "Bao", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Email",
                table: "Accounts",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IdRole",
                table: "Accounts",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserIdAccount",
                table: "Orders",
                column: "UserIdAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdCategory",
                table: "Products",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_IdProduct",
                table: "Reviews",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_IdUser",
                table: "Reviews",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
