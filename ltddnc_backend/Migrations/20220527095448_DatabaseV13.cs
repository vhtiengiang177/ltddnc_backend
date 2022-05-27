using Microsoft.EntityFrameworkCore.Migrations;

namespace ltddnc_backend.Migrations
{
    public partial class DatabaseV13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReviewState",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewState",
                table: "Orders");
        }
    }
}
