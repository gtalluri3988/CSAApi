using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class residentcolumns1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VisitorAccessDetails_CommunityId",
                table: "VisitorAccessDetails",
                column: "CommunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitorAccessDetails_Community_CommunityId",
                table: "VisitorAccessDetails",
                column: "CommunityId",
                principalTable: "Community",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitorAccessDetails_Community_CommunityId",
                table: "VisitorAccessDetails");

            migrationBuilder.DropIndex(
                name: "IX_VisitorAccessDetails_CommunityId",
                table: "VisitorAccessDetails");
        }
    }
}
