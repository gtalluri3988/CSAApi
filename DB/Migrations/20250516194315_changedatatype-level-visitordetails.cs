using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class changedatatypelevelvisitordetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitorAccessDetails_Community_CommunityId",
                table: "VisitorAccessDetails");

            migrationBuilder.DropIndex(
                name: "IX_VisitorAccessDetails_CommunityId",
                table: "VisitorAccessDetails");

            migrationBuilder.AlterColumn<string>(
                name: "LevelNo",
                table: "VisitorAccessDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LevelNo",
                table: "VisitorAccessDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
