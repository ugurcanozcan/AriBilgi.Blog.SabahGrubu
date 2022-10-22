using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _03.AriBilgi.Blog.Data.Migrations
{
    public partial class Description2Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description2",
                table: "Categories",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description2",
                table: "Categories");
        }
    }
}
