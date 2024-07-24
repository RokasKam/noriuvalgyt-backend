using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoriuValgyti.Infrastructure.Migrations
{
    public partial class bbbb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipe_Recipes_PlaceId",
                table: "UserRecipe");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipe_Users_UserId",
                table: "UserRecipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRecipe",
                table: "UserRecipe");

            migrationBuilder.RenameTable(
                name: "UserRecipe",
                newName: "UserRecipes");

            migrationBuilder.RenameColumn(
                name: "PlaceId",
                table: "UserRecipes",
                newName: "RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRecipe_UserId",
                table: "UserRecipes",
                newName: "IX_UserRecipes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRecipe_PlaceId",
                table: "UserRecipes",
                newName: "IX_UserRecipes_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRecipes",
                table: "UserRecipes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipes_Recipes_RecipeId",
                table: "UserRecipes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipes_Users_UserId",
                table: "UserRecipes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipes_Recipes_RecipeId",
                table: "UserRecipes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipes_Users_UserId",
                table: "UserRecipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRecipes",
                table: "UserRecipes");

            migrationBuilder.RenameTable(
                name: "UserRecipes",
                newName: "UserRecipe");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "UserRecipe",
                newName: "PlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRecipes_UserId",
                table: "UserRecipe",
                newName: "IX_UserRecipe_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRecipes_RecipeId",
                table: "UserRecipe",
                newName: "IX_UserRecipe_PlaceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRecipe",
                table: "UserRecipe",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipe_Recipes_PlaceId",
                table: "UserRecipe",
                column: "PlaceId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipe_Users_UserId",
                table: "UserRecipe",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
