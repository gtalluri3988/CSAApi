using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class addimageguidinfilephotos1222 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FacilityPhoto_FacilityId",
                table: "FacilityPhoto",
                column: "FacilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_FacilityPhoto_Facility_FacilityId",
                table: "FacilityPhoto",
                column: "FacilityId",
                principalTable: "Facility",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacilityPhoto_Facility_FacilityId",
                table: "FacilityPhoto");

            migrationBuilder.DropIndex(
                name: "IX_FacilityPhoto_FacilityId",
                table: "FacilityPhoto");
        }
    }
}
