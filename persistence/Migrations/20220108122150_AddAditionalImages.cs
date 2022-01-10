using Microsoft.EntityFrameworkCore.Migrations;

namespace persistence.Migrations
{
    public partial class AddAditionalImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThematicAreaPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TitleTJ = table.Column<string>(type: "TEXT", nullable: true),
                    TitleEN = table.Column<string>(type: "TEXT", nullable: true),
                    DescriptionTJ = table.Column<string>(type: "TEXT", nullable: true),
                    DescriptionEN = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThematicAreaPosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsMain = table.Column<bool>(type: "INTEGER", nullable: false),
                    Path = table.Column<string>(type: "TEXT", nullable: true),
                    ThematicAreaPostId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_ThematicAreaPosts_ThematicAreaPostId",
                        column: x => x.ThematicAreaPostId,
                        principalTable: "ThematicAreaPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_ThematicAreaPostId",
                table: "Files",
                column: "ThematicAreaPostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "ThematicAreaPosts");
        }
    }
}
