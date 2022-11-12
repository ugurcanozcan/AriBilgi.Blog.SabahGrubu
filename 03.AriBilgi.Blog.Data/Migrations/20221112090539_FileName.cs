using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _03.AriBilgi.Blog.Data.Migrations
{
    public partial class FileName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Articles");
        }
    }
}
