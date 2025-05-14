using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class residenhistoryupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlockNo",
                table: "ResidentAccessHistory");

            migrationBuilder.DropColumn(
                name: "HouseNo",
                table: "ResidentAccessHistory");

            migrationBuilder.DropColumn(
                name: "LevelNo",
                table: "ResidentAccessHistory");

            migrationBuilder.DropColumn(
                name: "RoadNo",
                table: "ResidentAccessHistory");

            migrationBuilder.AddColumn<int>(
                name: "ResidentId",
                table: "ResidentAccessHistory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResidentAccessHistory_ResidentId",
                table: "ResidentAccessHistory",
                column: "ResidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentAccessHistory_Resident_ResidentId",
                table: "ResidentAccessHistory",
                column: "ResidentId",
                principalTable: "Resident",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidentAccessHistory_Resident_ResidentId",
                table: "ResidentAccessHistory");

            migrationBuilder.DropIndex(
                name: "IX_ResidentAccessHistory_ResidentId",
                table: "ResidentAccessHistory");

            migrationBuilder.DropColumn(
                name: "ResidentId",
                table: "ResidentAccessHistory");

            migrationBuilder.AddColumn<string>(
                name: "BlockNo",
                table: "ResidentAccessHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HouseNo",
                table: "ResidentAccessHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LevelNo",
                table: "ResidentAccessHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RoadNo",
                table: "ResidentAccessHistory",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
