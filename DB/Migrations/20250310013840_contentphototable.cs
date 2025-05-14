using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class contentphototable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentPicture_ContentManagement_ContentManagementId",
                table: "ContentPicture");

            migrationBuilder.AlterColumn<int>(
                name: "ContentManagementId",
                table: "ContentPicture",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageGuid",
                table: "ContentPicture",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ContentPicture",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Preview",
                table: "ContentPicture",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentPicture_ContentManagement_ContentManagementId",
                table: "ContentPicture",
                column: "ContentManagementId",
                principalTable: "ContentManagement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentPicture_ContentManagement_ContentManagementId",
                table: "ContentPicture");

            migrationBuilder.DropColumn(
                name: "ImageGuid",
                table: "ContentPicture");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ContentPicture");

            migrationBuilder.DropColumn(
                name: "Preview",
                table: "ContentPicture");

            migrationBuilder.AlterColumn<int>(
                name: "ContentManagementId",
                table: "ContentPicture",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentPicture_ContentManagement_ContentManagementId",
                table: "ContentPicture",
                column: "ContentManagementId",
                principalTable: "ContentManagement",
                principalColumn: "Id");
        }
    }
}
