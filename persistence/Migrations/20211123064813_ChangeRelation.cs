using Microsoft.EntityFrameworkCore.Migrations;

namespace persistence.Migrations
{
    public partial class ChangeRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Descriptions_CategoryId",
                table: "Descriptions");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Descriptions",
                newName: "TextTJ");

            migrationBuilder.AddColumn<string>(
                name: "TextEN",
                table: "Descriptions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_CategoryId",
                table: "Descriptions",
                column: "CategoryId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Descriptions_CategoryId",
                table: "Descriptions");

            migrationBuilder.DropColumn(
                name: "TextEN",
                table: "Descriptions");

            migrationBuilder.RenameColumn(
                name: "TextTJ",
                table: "Descriptions",
                newName: "Text");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_CategoryId",
                table: "Descriptions",
                column: "CategoryId");
        }
    }
}
