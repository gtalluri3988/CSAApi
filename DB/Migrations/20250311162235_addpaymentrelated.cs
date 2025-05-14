using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class addpaymentrelated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentRef",
                table: "ResidencePaymentDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentStatusId",
                table: "ResidencePaymentDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PaymentStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResidencePaymentDetails_PaymentStatusId",
                table: "ResidencePaymentDetails",
                column: "PaymentStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResidencePaymentDetails_PaymentStatus_PaymentStatusId",
                table: "ResidencePaymentDetails",
                column: "PaymentStatusId",
                principalTable: "PaymentStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidencePaymentDetails_PaymentStatus_PaymentStatusId",
                table: "ResidencePaymentDetails");

            migrationBuilder.DropTable(
                name: "PaymentStatus");

            migrationBuilder.DropIndex(
                name: "IX_ResidencePaymentDetails_PaymentStatusId",
                table: "ResidencePaymentDetails");

            migrationBuilder.DropColumn(
                name: "PaymentRef",
                table: "ResidencePaymentDetails");

            migrationBuilder.DropColumn(
                name: "PaymentStatusId",
                table: "ResidencePaymentDetails");
        }
    }
}
