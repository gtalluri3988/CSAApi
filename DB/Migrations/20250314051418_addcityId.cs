using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class addcityId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Community",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Community_CityId",
                table: "Community",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Community_City_CityId",
                table: "Community",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Community_City_CityId",
                table: "Community");

            migrationBuilder.DropIndex(
                name: "IX_Community_CityId",
                table: "Community");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Community");
        }
    }
}
