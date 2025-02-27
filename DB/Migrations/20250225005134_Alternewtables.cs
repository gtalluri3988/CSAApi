using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class Alternewtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidencePaymentDetails_PaymentTypes_PaymentTypesId",
                table: "ResidencePaymentDetails");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropIndex(
                name: "IX_ResidencePaymentDetails_PaymentTypesId",
                table: "ResidencePaymentDetails");

            migrationBuilder.DropColumn(
                name: "PaymentTypesId",
                table: "ResidencePaymentDetails");

            migrationBuilder.CreateTable(
                name: "PaymentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResidencePaymentDetails_PaymentTypeId",
                table: "ResidencePaymentDetails",
                column: "PaymentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResidencePaymentDetails_PaymentType_PaymentTypeId",
                table: "ResidencePaymentDetails",
                column: "PaymentTypeId",
                principalTable: "PaymentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidencePaymentDetails_PaymentType_PaymentTypeId",
                table: "ResidencePaymentDetails");

            migrationBuilder.DropTable(
                name: "PaymentType");

            migrationBuilder.DropIndex(
                name: "IX_ResidencePaymentDetails_PaymentTypeId",
                table: "ResidencePaymentDetails");

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypesId",
                table: "ResidencePaymentDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResidencePaymentDetails_PaymentTypesId",
                table: "ResidencePaymentDetails",
                column: "PaymentTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResidencePaymentDetails_PaymentTypes_PaymentTypesId",
                table: "ResidencePaymentDetails",
                column: "PaymentTypesId",
                principalTable: "PaymentTypes",
                principalColumn: "Id");
        }
    }
}
