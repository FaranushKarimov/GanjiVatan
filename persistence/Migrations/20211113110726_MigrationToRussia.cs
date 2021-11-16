using Microsoft.EntityFrameworkCore.Migrations;

namespace persistence.Migrations
{
    public partial class MigrationToRussia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Banners",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Banners");
        }
    }
}
