using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class communityidinusertablechangecolumnnane : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Community_CommunityID",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "CommunityID",
                table: "Users",
                newName: "CommunityId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CommunityID",
                table: "Users",
                newName: "IX_Users_CommunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Community_CommunityId",
                table: "Users",
                column: "CommunityId",
                principalTable: "Community",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Community_CommunityId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "CommunityId",
                table: "Users",
                newName: "CommunityID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CommunityId",
                table: "Users",
                newName: "IX_Users_CommunityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Community_CommunityID",
                table: "Users",
                column: "CommunityID",
                principalTable: "Community",
                principalColumn: "Id");
        }
    }
}
