using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class RelationDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ContactInformations_UserId",
                table: "ContactInformations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInformations_Users_UserId",
                table: "ContactInformations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInformations_Users_UserId",
                table: "ContactInformations");

            migrationBuilder.DropIndex(
                name: "IX_ContactInformations_UserId",
                table: "ContactInformations");
        }
    }
}
