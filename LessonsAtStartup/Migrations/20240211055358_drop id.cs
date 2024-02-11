using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LessonsAtStartup.Migrations
{
    public partial class dropid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "PostTags");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PostTags",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
