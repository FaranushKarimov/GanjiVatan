using Microsoft.EntityFrameworkCore.Migrations;

namespace persistence.Migrations
{
    public partial class FixBug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryRU",
                table: "Categories",
                newName: "CategoryTJ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryTJ",
                table: "Categories",
                newName: "CategoryRU");
        }
    }
}
