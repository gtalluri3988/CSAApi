using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class addvistorcharges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VisitorParkingCharge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoOfVistorParkingLot = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ChargeTypeId = table.Column<int>(type: "int", nullable: true),
                    CommunityId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorParkingCharge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitorParkingCharge_ChargesType_ChargeTypeId",
                        column: x => x.ChargeTypeId,
                        principalTable: "ChargesType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VisitorParkingCharge_Community_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Community",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VisitorParkingCharge_ChargeTypeId",
                table: "VisitorParkingCharge",
                column: "ChargeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorParkingCharge_CommunityId",
                table: "VisitorParkingCharge",
                column: "CommunityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitorParkingCharge");
        }
    }
}
