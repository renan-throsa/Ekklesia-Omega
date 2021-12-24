using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ekkleisa.Repository.Implementation.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    PreacherId = table.Column<int>(type: "int", nullable: false),
                    CoordinatorId = table.Column<int>(type: "int", nullable: false),
                    NumberOfReunions = table.Column<int>(type: "int", nullable: false),
                    NumberOfConvertions = table.Column<int>(type: "int", nullable: false),
                    PreviousMonth = table.Column<float>(type: "real", nullable: false),
                    Income = table.Column<float>(type: "real", nullable: false),
                    Expense = table.Column<float>(type: "real", nullable: false),
                    Tenth = table.Column<float>(type: "real", nullable: false),
                    Balance = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Report_Member_CoordinatorId",
                        column: x => x.CoordinatorId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Report_Member_PreacherId",
                        column: x => x.PreacherId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BiblicalReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NumberOfBibles = table.Column<int>(type: "int", nullable: false),
                    NumberOfReunionWithTeachers = table.Column<int>(type: "int", nullable: false),
                    NumberOfVisitants = table.Column<int>(type: "int", nullable: false),
                    NumberOfPeoplePresent = table.Column<int>(type: "int", nullable: false),
                    NumberOfPeopleInPedagogicalBody = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiblicalReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BiblicalReport_Report_Id",
                        column: x => x.Id,
                        principalTable: "Report",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CellReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NumberCoordenationMeatings = table.Column<int>(type: "int", nullable: false),
                    NumberOfVisits = table.Column<int>(type: "int", nullable: false),
                    NumberOfEvangelisms = table.Column<int>(type: "int", nullable: false),
                    NumberOfBoardMembers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CellReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CellReport_Report_Id",
                        column: x => x.Id,
                        principalTable: "Report",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NumberOfExternalCults = table.Column<int>(type: "int", nullable: false),
                    NumberOfCells = table.Column<int>(type: "int", nullable: false),
                    NumberOfBaptizeds = table.Column<int>(type: "int", nullable: false),
                    NumberOfMeetingsWithTheCoordination = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupReport_Report_Id",
                        column: x => x.Id,
                        principalTable: "Report",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Report_CoordinatorId",
                table: "Report",
                column: "CoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_PreacherId",
                table: "Report",
                column: "PreacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BiblicalReport");

            migrationBuilder.DropTable(
                name: "CellReport");

            migrationBuilder.DropTable(
                name: "GroupReport");

            migrationBuilder.DropTable(
                name: "Report");
        }
    }
}
