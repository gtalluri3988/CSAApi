using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class complaintphotos1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComplaintPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplaintId = table.Column<int>(type: "int", nullable: true),
                    ImageGuid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplaintDetailId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplaintPhotos_ComplaintDetail_ComplaintDetailId",
                        column: x => x.ComplaintDetailId,
                        principalTable: "ComplaintDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintPhotos_ComplaintDetailId",
                table: "ComplaintPhotos",
                column: "ComplaintDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplaintPhotos");
        }
    }
}
