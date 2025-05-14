using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class eventdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommunityId = table.Column<int>(type: "int", nullable: true),
                    ResidentId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventDetails_Community_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Community",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EventDetails_Resident_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Resident",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventDetails_CommunityId",
                table: "EventDetails",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_EventDetails_ResidentId",
                table: "EventDetails",
                column: "ResidentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventDetails");
        }
    }
}
