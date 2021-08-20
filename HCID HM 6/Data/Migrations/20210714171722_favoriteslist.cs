using Microsoft.EntityFrameworkCore.Migrations;

namespace HCID_HM.Data.Migrations
{
    public partial class favoriteslist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Topics",
                table: "Topics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoritesLists",
                table: "FavoritesLists");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FavoritesLists");

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Topics",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Topics",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FavoritesListId",
                table: "FavoritesLists",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topics",
                table: "Topics",
                column: "TopicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoritesLists",
                table: "FavoritesLists",
                column: "FavoritesListId");

            migrationBuilder.CreateTable(
                name: "TopicInFavoritesList",
                columns: table => new
                {
                    TopicId = table.Column<int>(nullable: false),
                    FavoritesListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicInFavoritesList", x => new { x.TopicId, x.FavoritesListId });
                    table.ForeignKey(
                        name: "FK_TopicInFavoritesList_FavoritesLists_FavoritesListId",
                        column: x => x.FavoritesListId,
                        principalTable: "FavoritesLists",
                        principalColumn: "FavoritesListId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicInFavoritesList_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TopicInFavoritesList_FavoritesListId",
                table: "TopicInFavoritesList",
                column: "FavoritesListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TopicInFavoritesList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topics",
                table: "Topics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoritesLists",
                table: "FavoritesLists");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "FavoritesListId",
                table: "FavoritesLists");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Topics",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FavoritesLists",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topics",
                table: "Topics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoritesLists",
                table: "FavoritesLists",
                column: "Id");
        }
    }
}
