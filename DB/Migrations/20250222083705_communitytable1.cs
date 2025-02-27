using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class communitytable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommunityType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Community",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    CommunityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommunityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfUnits = table.Column<int>(type: "int", nullable: false),
                    PICName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfParkingLot = table.Column<int>(type: "int", nullable: false),
                    CommunityTypeId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Community", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Community_CommunityType_CommunityTypeId",
                        column: x => x.CommunityTypeId,
                        principalTable: "CommunityType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Community_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Community_CommunityTypeId",
                table: "Community",
                column: "CommunityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Community_StateId",
                table: "Community",
                column: "StateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Community");

            migrationBuilder.DropTable(
                name: "CommunityType");

            migrationBuilder.DropTable(
                name: "State");
        }
    }
}
