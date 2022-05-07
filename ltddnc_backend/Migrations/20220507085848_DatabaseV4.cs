using Microsoft.EntityFrameworkCore.Migrations;

namespace ltddnc_backend.Migrations
{
    public partial class DatabaseV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Favorites",
                columns: new[] { "IdUser", "IdProduct" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 3, 3 },
                    { 4, 1 },
                    { 4, 5 },
                    { 4, 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");
        }
    }
}
