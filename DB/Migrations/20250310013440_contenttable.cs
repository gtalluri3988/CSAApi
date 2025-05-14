using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class contenttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentManagement_Community_CommunityId",
                table: "ContentManagement");

            migrationBuilder.DropForeignKey(
                name: "FK_Facility_FacilityType_FacilityTypeId",
                table: "Facility");

            migrationBuilder.AlterColumn<int>(
                name: "FacilityTypeId",
                table: "Facility",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CommunityId",
                table: "ContentManagement",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentManagement_Community_CommunityId",
                table: "ContentManagement",
                column: "CommunityId",
                principalTable: "Community",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facility_FacilityType_FacilityTypeId",
                table: "Facility",
                column: "FacilityTypeId",
                principalTable: "FacilityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentManagement_Community_CommunityId",
                table: "ContentManagement");

            migrationBuilder.DropForeignKey(
                name: "FK_Facility_FacilityType_FacilityTypeId",
                table: "Facility");

            migrationBuilder.AlterColumn<int>(
                name: "FacilityTypeId",
                table: "Facility",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CommunityId",
                table: "ContentManagement",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentManagement_Community_CommunityId",
                table: "ContentManagement",
                column: "CommunityId",
                principalTable: "Community",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Facility_FacilityType_FacilityTypeId",
                table: "Facility",
                column: "FacilityTypeId",
                principalTable: "FacilityType",
                principalColumn: "Id");
        }
    }
}
