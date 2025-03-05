using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class updatetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleDetails_VehicleType_typeId",
                table: "VehicleDetails");

            migrationBuilder.DropIndex(
                name: "IX_VehicleDetails_typeId",
                table: "VehicleDetails");

            migrationBuilder.DropColumn(
                name: "typeId",
                table: "VehicleDetails");

            migrationBuilder.AddColumn<int>(
                name: "VehicleTypeId",
                table: "VehicleDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDetails_VehicleTypeId",
                table: "VehicleDetails",
                column: "VehicleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleDetails_VehicleType_VehicleTypeId",
                table: "VehicleDetails",
                column: "VehicleTypeId",
                principalTable: "VehicleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleDetails_VehicleType_VehicleTypeId",
                table: "VehicleDetails");

            migrationBuilder.DropIndex(
                name: "IX_VehicleDetails_VehicleTypeId",
                table: "VehicleDetails");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "VehicleDetails");

            migrationBuilder.AddColumn<int>(
                name: "typeId",
                table: "VehicleDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDetails_typeId",
                table: "VehicleDetails",
                column: "typeId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleDetails_VehicleType_typeId",
                table: "VehicleDetails",
                column: "typeId",
                principalTable: "VehicleType",
                principalColumn: "Id");
        }
    }
}
