using Microsoft.EntityFrameworkCore.Migrations;

namespace ltddnc_backend.Migrations
{
    public partial class DatabaseV1 : Migration
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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalQuantity = table.Column<int>(nullable: false),
                    TotalProductPrice = table.Column<double>(nullable: false),
                    TotalAmount = table.Column<double>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    FeeDelivery = table.Column<double>(nullable: false),
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
                columns: new[] { "Id", "Name", "State" },
                values: new object[,]
                {
                    { 1, "Burger", 1 },
                    { 2, "Gà Rán", 1 },
                    { 3, "Mì Ý", 1 },
                    { 4, "Thức Uống", 1 },
                    { 5, "Kem", 0 }
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
                    { 1, "Gà sốt với đậu", 1, null, "Gà sốt đậu", 1, 100, 38000.0 },
                    { 2, "Gà sốt H&S", 1, null, "Gà sốt H&S", 1, 100, 38000.0 },
                    { 3, "Burger Mozzarella", 2, null, "Burger Mozzarella", 1, 100, 50000.0 },
                    { 4, "Burger Double Double", 2, null, "Burger Double Double", 1, 100, 60000.0 },
                    { 9, "Burger Bulgogi", 2, null, "Burger Bulgogi", 1, 100, 45000.0 },
                    { 10, "Burger Gà Thượng Hạng", 2, null, "Burger Gà Thượng Hạng", 1, 100, 60000.0 },
                    { 5, "Mì Ý", 3, null, "Mì Ý", 1, 100, 35000.0 },
                    { 6, "Mì Ý Thịt Bò", 3, null, "Mì Ý Thịt Bò", 1, 100, 40000.0 },
                    { 7, "7Up Dưa Lưới Đào", 4, null, "7Up Dưa Lưới Đào", 1, 100, 15000.0 },
                    { 8, "Nước Cam", 4, null, "Nước Cam", 1, 100, 18000.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "IdAccount", "Address", "Image", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "282  Nguyễn Duy Trinh, phường Bình Trưng Tây, Quận 2, TP. HCM", null, "Giang", "0328807778" },
                    { 2, "Số 1 Võ Văn Ngân, TP Thủ Đức, TP. HCM", null, "Thao", "0328807778" },
                    { 3, "20 Đặng Văn Bi, phường Trường Thọ, TP Thủ Đức", null, "Bao", "0328807778" },
                    { 4, "23/2 Đường số 8, TP Thủ Đức", null, "Yen", "0328807778" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "IdUser", "IdProduct", "Quantity" },
                values: new object[] { 3, 1, 20 });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "OrderDetails");

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
