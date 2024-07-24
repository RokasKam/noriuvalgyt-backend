using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoriuValgyti.Infrastructure.Migrations
{
    public partial class aaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRecipe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlaceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModificationDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRecipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRecipe_Recipes_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRecipe_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRecipe_PlaceId",
                table: "UserRecipe",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRecipe_UserId",
                table: "UserRecipe",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRecipe");
        }
    }
}
