using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mission10_Shaw.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollaborativeRecommendations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SourceContentId = table.Column<long>(type: "INTEGER", nullable: false),
                    RecommendedContentId = table.Column<long>(type: "INTEGER", nullable: false),
                    Rank = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaborativeRecommendations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContentRecommendations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SourceContentId = table.Column<long>(type: "INTEGER", nullable: false),
                    RecommendedContentId = table.Column<long>(type: "INTEGER", nullable: false),
                    Rank = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentRecommendations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SharedArticles",
                columns: table => new
                {
                    ContentId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "nvarchar (255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedArticles", x => x.ContentId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollaborativeRecommendations");

            migrationBuilder.DropTable(
                name: "ContentRecommendations");

            migrationBuilder.DropTable(
                name: "SharedArticles");
        }
    }
}
