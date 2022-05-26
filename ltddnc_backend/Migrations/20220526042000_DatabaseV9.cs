using Microsoft.EntityFrameworkCore.Migrations;

namespace ltddnc_backend.Migrations
{
    public partial class DatabaseV9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "Id", "IdProduct", "IdUser" },
                keyValues: new object[] { 1, 1, 3 },
                column: "Rating",
                value: 5.0);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "Id", "IdProduct", "IdUser" },
                keyValues: new object[] { 2, 1, 3 },
                column: "Rating",
                value: 1.0);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "Id", "IdProduct", "IdUser" },
                keyValues: new object[] { 3, 2, 3 },
                column: "Rating",
                value: 5.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Reviews",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "Id", "IdProduct", "IdUser" },
                keyValues: new object[] { 1, 1, 3 },
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "Id", "IdProduct", "IdUser" },
                keyValues: new object[] { 2, 1, 3 },
                column: "Rating",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "Id", "IdProduct", "IdUser" },
                keyValues: new object[] { 3, 2, 3 },
                column: "Rating",
                value: 5);
        }
    }
}
