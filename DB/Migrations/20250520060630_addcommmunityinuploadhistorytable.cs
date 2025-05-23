using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class addcommmunityinuploadhistorytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommunityId",
                table: "ResidentUploadHistory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResidentUploadHistory_CommunityId",
                table: "ResidentUploadHistory",
                column: "CommunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentUploadHistory_Community_CommunityId",
                table: "ResidentUploadHistory",
                column: "CommunityId",
                principalTable: "Community",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidentUploadHistory_Community_CommunityId",
                table: "ResidentUploadHistory");

            migrationBuilder.DropIndex(
                name: "IX_ResidentUploadHistory_CommunityId",
                table: "ResidentUploadHistory");

            migrationBuilder.DropColumn(
                name: "CommunityId",
                table: "ResidentUploadHistory");
        }
    }
}
