using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RichieAI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cab",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Availability = table.Column<bool>(nullable: false),
                    TRN = table.Column<string>(nullable: true),
                    RequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cab", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CabManager",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabManager", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passenger",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    RequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passenger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    comment = table.Column<string>(nullable: true),
                    rating = table.Column<int>(nullable: false),
                    RequestId = table.Column<int>(nullable: false),
                    ExperienceNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experience_CabManager_ExperienceNavigationId",
                        column: x => x.ExperienceNavigationId,
                        principalTable: "CabManager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnavailableReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    CabId = table.Column<int>(nullable: false),
                    UnavailableReportNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnavailableReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnavailableReport_Cab_CabId",
                        column: x => x.CabId,
                        principalTable: "Cab",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnavailableReport_CabManager_UnavailableReportNavigationId",
                        column: x => x.UnavailableReportNavigationId,
                        principalTable: "CabManager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    From = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: true),
                    Confirmation = table.Column<bool>(nullable: false),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    PassengerId = table.Column<int>(nullable: false),
                    CabId = table.Column<int>(nullable: false),
                    ExperienceId = table.Column<int>(nullable: false),
                    RequestNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Request_Cab_CabId",
                        column: x => x.CabId,
                        principalTable: "Cab",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_Experience_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experience",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_Passenger_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passenger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_CabManager_RequestNavigationId",
                        column: x => x.RequestNavigationId,
                        principalTable: "CabManager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Experience_ExperienceNavigationId",
                table: "Experience",
                column: "ExperienceNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_CabId",
                table: "Request",
                column: "CabId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_ExperienceId",
                table: "Request",
                column: "ExperienceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_PassengerId",
                table: "Request",
                column: "PassengerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_RequestNavigationId",
                table: "Request",
                column: "RequestNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_UnavailableReport_CabId",
                table: "UnavailableReport",
                column: "CabId");

            migrationBuilder.CreateIndex(
                name: "IX_UnavailableReport_UnavailableReportNavigationId",
                table: "UnavailableReport",
                column: "UnavailableReportNavigationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "UnavailableReport");

            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropTable(
                name: "Passenger");

            migrationBuilder.DropTable(
                name: "Cab");

            migrationBuilder.DropTable(
                name: "CabManager");
        }
    }
}
