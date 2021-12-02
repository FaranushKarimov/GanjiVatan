using Microsoft.EntityFrameworkCore.Migrations;

namespace persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Banners",
                newName: "DescriptionTJ");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEN",
                table: "Banners",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionEN",
                table: "Banners");

            migrationBuilder.RenameColumn(
                name: "DescriptionTJ",
                table: "Banners",
                newName: "Description");
        }
    }
}
