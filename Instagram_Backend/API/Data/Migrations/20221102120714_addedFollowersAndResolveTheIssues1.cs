using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class addedFollowersAndResolveTheIssues1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followers_AppUsers_followerId",
                table: "Followers");

            migrationBuilder.DropIndex(
                name: "IX_Followers_followerId",
                table: "Followers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Followers_followerId",
                table: "Followers",
                column: "followerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_AppUsers_followerId",
                table: "Followers",
                column: "followerId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
