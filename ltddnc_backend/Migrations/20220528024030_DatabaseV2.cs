using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ltddnc_backend.Migrations
{
    public partial class DatabaseV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Products");
        }
    }
}
