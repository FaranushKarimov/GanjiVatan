using Microsoft.EntityFrameworkCore.Migrations;

namespace persistence.Migrations
{
    public partial class AddColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Posts",
                newName: "TitleTJ");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Posts",
                newName: "TitleEN");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEN",
                table: "Posts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionTJ",
                table: "Posts",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionEN",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "DescriptionTJ",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "TitleTJ",
                table: "Posts",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "TitleEN",
                table: "Posts",
                newName: "Description");
        }
    }
}
