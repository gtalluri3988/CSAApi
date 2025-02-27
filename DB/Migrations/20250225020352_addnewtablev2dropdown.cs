using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class addnewtablev2dropdown : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "VehicleType",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "PaymentType",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CommunityTypeName",
                table: "CommunityType",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "VehicleType",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PaymentType",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CommunityType",
                newName: "CommunityTypeName");
        }
    }
}
