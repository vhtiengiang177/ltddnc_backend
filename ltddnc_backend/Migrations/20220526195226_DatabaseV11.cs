using Microsoft.EntityFrameworkCore.Migrations;

namespace ltddnc_backend.Migrations
{
    public partial class DatabaseV11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdOrder",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Reviews",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "Id", "IdProduct", "IdUser" },
                keyValues: new object[] { 1, 1, 3 },
                column: "IdOrder",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "Id", "IdProduct", "IdUser" },
                keyValues: new object[] { 2, 1, 3 },
                column: "IdOrder",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "Id", "IdProduct", "IdUser" },
                keyValues: new object[] { 3, 2, 3 },
                column: "IdOrder",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_OrderId",
                table: "Reviews",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Orders_OrderId",
                table: "Reviews",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Orders_OrderId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_OrderId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "IdOrder",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Reviews");
        }
    }
}
