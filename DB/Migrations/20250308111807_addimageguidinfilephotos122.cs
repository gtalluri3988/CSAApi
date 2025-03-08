using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class addimageguidinfilephotos122 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacilityPhoto_Facility_FacilityId",
                table: "FacilityPhoto");

            migrationBuilder.DropIndex(
                name: "IX_FacilityPhoto_FacilityId",
                table: "FacilityPhoto");

            migrationBuilder.AlterColumn<int>(
                name: "FacilityId",
                table: "FacilityPhoto",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "File",
                table: "FacilityPhoto",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "File",
                table: "FacilityPhoto");

            migrationBuilder.AlterColumn<int>(
                name: "FacilityId",
                table: "FacilityPhoto",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityPhoto_FacilityId",
                table: "FacilityPhoto",
                column: "FacilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_FacilityPhoto_Facility_FacilityId",
                table: "FacilityPhoto",
                column: "FacilityId",
                principalTable: "Facility",
                principalColumn: "Id");
        }
    }
}
