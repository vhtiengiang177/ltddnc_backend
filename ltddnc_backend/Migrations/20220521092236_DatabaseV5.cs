using Microsoft.EntityFrameworkCore.Migrations;

namespace ltddnc_backend.Migrations
{
    public partial class DatabaseV5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumns: new[] { "IdUser", "IdProduct" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Favorites",
                keyColumns: new[] { "IdUser", "IdProduct" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Favorites",
                keyColumns: new[] { "IdUser", "IdProduct" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Favorites",
                keyColumns: new[] { "IdUser", "IdProduct" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "Favorites",
                keyColumns: new[] { "IdUser", "IdProduct" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "Favorites",
                keyColumns: new[] { "IdUser", "IdProduct" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DropColumn(
                name: "FeeDelivery",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Orders",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdAccount",
                keyValue: 1,
                column: "Phone",
                value: "0328801234");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdAccount",
                keyValue: 2,
                column: "Phone",
                value: "0328807278");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdAccount",
                keyValue: 3,
                column: "Phone",
                value: "0328807986");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdAccount",
                keyValue: 4,
                column: "Phone",
                value: "0328807938");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Orders");

            migrationBuilder.AddColumn<double>(
                name: "FeeDelivery",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalAmount",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "IdUser", "IdProduct", "Quantity" },
                values: new object[] { 3, 1, 20 });

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdAccount",
                keyValue: 1,
                column: "Phone",
                value: "0328807778");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdAccount",
                keyValue: 2,
                column: "Phone",
                value: "0328807778");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdAccount",
                keyValue: 3,
                column: "Phone",
                value: "0328807778");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdAccount",
                keyValue: 4,
                column: "Phone",
                value: "0328807778");
        }
    }
}
