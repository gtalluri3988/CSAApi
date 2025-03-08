using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class addimageguidinfilephotos1345 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facility_Community_CommunityId",
                table: "Facility");

            migrationBuilder.AlterColumn<int>(
                name: "CommunityId",
                table: "Facility",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Facility_Community_CommunityId",
                table: "Facility",
                column: "CommunityId",
                principalTable: "Community",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facility_Community_CommunityId",
                table: "Facility");

            migrationBuilder.AlterColumn<int>(
                name: "CommunityId",
                table: "Facility",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Facility_Community_CommunityId",
                table: "Facility",
                column: "CommunityId",
                principalTable: "Community",
                principalColumn: "Id");
        }
    }
}
