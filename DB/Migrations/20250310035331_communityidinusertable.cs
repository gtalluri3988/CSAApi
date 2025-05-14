using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class communityidinusertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommunityID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CommunityID",
                table: "Users",
                column: "CommunityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Community_CommunityID",
                table: "Users",
                column: "CommunityID",
                principalTable: "Community",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Community_CommunityID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CommunityID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CommunityID",
                table: "Users");
        }
    }
}
