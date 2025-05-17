using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class residentcolumns3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
        name: "Level",
        table: "Resident",
        type: "nvarchar(max)",
        nullable: true,
        oldClrType: typeof(int),
        oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
        name: "Level",
        table: "Resident",
        type: "int",
        nullable: false,
        defaultValue: 0,
        oldClrType: typeof(string),
        oldType: "nvarchar(max)",
        oldNullable: true);
        }
    }
}
