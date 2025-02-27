using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class addnewtablev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComplaintStatus",
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
                    table.PrimaryKey("PK_ComplaintStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContentManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<bool>(type: "bit", nullable: false),
                    CommunityId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentManagement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentManagement_Community_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Community",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FacilityType",
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
                    table.PrimaryKey("PK_FacilityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResidentAccessHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExitTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HouseNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LevelNo = table.Column<int>(type: "int", nullable: false),
                    BlockNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoadNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemporaryAccess = table.Column<bool>(type: "bit", nullable: false),
                    CommunityId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentAccessHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentAccessHistory_Community_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Community",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitorAccessDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitPurpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExitTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VehicleNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LevelNo = table.Column<int>(type: "int", nullable: false),
                    BlockNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoadNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorAccessDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VisitorAccessType",
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
                    table.PrimaryKey("PK_VisitorAccessType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplainRefNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplaintDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SecurityRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplaintStatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplaintDetail_ComplaintStatus_ComplaintStatusId",
                        column: x => x.ComplaintStatusId,
                        principalTable: "ComplaintStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentPicture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentManagementId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentPicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentPicture_ContentManagement_ContentManagementId",
                        column: x => x.ContentManagementId,
                        principalTable: "ContentManagement",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacilityLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacilityDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommunityId = table.Column<int>(type: "int", nullable: true),
                    FacilityTypeId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facility_Community_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Community",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Facility_FacilityType_FacilityTypeId",
                        column: x => x.FacilityTypeId,
                        principalTable: "FacilityType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FacilityPhoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacilityId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacilityPhoto_Facility_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facility",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintDetail_ComplaintStatusId",
                table: "ComplaintDetail",
                column: "ComplaintStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentManagement_CommunityId",
                table: "ContentManagement",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentPicture_ContentManagementId",
                table: "ContentPicture",
                column: "ContentManagementId");

            migrationBuilder.CreateIndex(
                name: "IX_Facility_CommunityId",
                table: "Facility",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_Facility_FacilityTypeId",
                table: "Facility",
                column: "FacilityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityPhoto_FacilityId",
                table: "FacilityPhoto",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentAccessHistory_CommunityId",
                table: "ResidentAccessHistory",
                column: "CommunityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplaintDetail");

            migrationBuilder.DropTable(
                name: "ContentPicture");

            migrationBuilder.DropTable(
                name: "FacilityPhoto");

            migrationBuilder.DropTable(
                name: "ResidentAccessHistory");

            migrationBuilder.DropTable(
                name: "VisitorAccessDetails");

            migrationBuilder.DropTable(
                name: "VisitorAccessType");

            migrationBuilder.DropTable(
                name: "ComplaintStatus");

            migrationBuilder.DropTable(
                name: "ContentManagement");

            migrationBuilder.DropTable(
                name: "Facility");

            migrationBuilder.DropTable(
                name: "FacilityType");
        }
    }
}
