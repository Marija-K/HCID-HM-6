using Microsoft.EntityFrameworkCore.Migrations;

namespace HCID_HM.Data.Migrations
{
    public partial class userfacorite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TopicInFavoritesList_FavoritesLists_FavoritesListId",
                table: "TopicInFavoritesList");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicInFavoritesList_Topics_TopicId",
                table: "TopicInFavoritesList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TopicInFavoritesList",
                table: "TopicInFavoritesList");

            migrationBuilder.RenameTable(
                name: "TopicInFavoritesList",
                newName: "TopicInFavoritesLists");

            migrationBuilder.RenameIndex(
                name: "IX_TopicInFavoritesList_FavoritesListId",
                table: "TopicInFavoritesLists",
                newName: "IX_TopicInFavoritesLists_FavoritesListId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "FavoritesLists",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FavoritesListId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TopicInFavoritesLists",
                table: "TopicInFavoritesLists",
                columns: new[] { "TopicId", "FavoritesListId" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FavoritesListId",
                table: "AspNetUsers",
                column: "FavoritesListId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_FavoritesLists_FavoritesListId",
                table: "AspNetUsers",
                column: "FavoritesListId",
                principalTable: "FavoritesLists",
                principalColumn: "FavoritesListId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicInFavoritesLists_FavoritesLists_FavoritesListId",
                table: "TopicInFavoritesLists",
                column: "FavoritesListId",
                principalTable: "FavoritesLists",
                principalColumn: "FavoritesListId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicInFavoritesLists_Topics_TopicId",
                table: "TopicInFavoritesLists",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_FavoritesLists_FavoritesListId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicInFavoritesLists_FavoritesLists_FavoritesListId",
                table: "TopicInFavoritesLists");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicInFavoritesLists_Topics_TopicId",
                table: "TopicInFavoritesLists");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FavoritesListId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TopicInFavoritesLists",
                table: "TopicInFavoritesLists");

            migrationBuilder.DropColumn(
                name: "FavoritesListId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "TopicInFavoritesLists",
                newName: "TopicInFavoritesList");

            migrationBuilder.RenameIndex(
                name: "IX_TopicInFavoritesLists_FavoritesListId",
                table: "TopicInFavoritesList",
                newName: "IX_TopicInFavoritesList_FavoritesListId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "FavoritesLists",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TopicInFavoritesList",
                table: "TopicInFavoritesList",
                columns: new[] { "TopicId", "FavoritesListId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TopicInFavoritesList_FavoritesLists_FavoritesListId",
                table: "TopicInFavoritesList",
                column: "FavoritesListId",
                principalTable: "FavoritesLists",
                principalColumn: "FavoritesListId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicInFavoritesList_Topics_TopicId",
                table: "TopicInFavoritesList",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
