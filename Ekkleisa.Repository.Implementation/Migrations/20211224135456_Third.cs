using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ekkleisa.Repository.Implementation.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Occasion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occasion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Atypical",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atypical", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atypical_Occasion_Id",
                        column: x => x.Id,
                        principalTable: "Occasion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Baptism",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BaptizerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baptism", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baptism_Member_BaptizerId",
                        column: x => x.BaptizerId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Baptism_Occasion_Id",
                        column: x => x.Id,
                        principalTable: "Occasion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cell",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Convertions = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cell", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cell_Occasion_Id",
                        column: x => x.Id,
                        principalTable: "Occasion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false),
                    KeyVerse = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CultType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Internal = table.Column<bool>(type: "bit", nullable: false),
                    Convertions = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cult_Occasion_Id",
                        column: x => x.Id,
                        principalTable: "Occasion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reunion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ReunionType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    SpeakerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reunion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reunion_Member_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reunion_Occasion_Id",
                        column: x => x.Id,
                        principalTable: "Occasion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SundaySchool",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Verse = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NumberOfBibles = table.Column<int>(type: "int", nullable: false),
                    Visitants = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SundaySchool", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SundaySchool_Member_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SundaySchool_Occasion_Id",
                        column: x => x.Id,
                        principalTable: "Occasion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OccasionMember",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    OccasionId = table.Column<int>(type: "int", nullable: false),
                    BaptismId = table.Column<int>(type: "int", nullable: true),
                    ReunionId = table.Column<int>(type: "int", nullable: true),
                    SundaySchoolId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccasionMember", x => new { x.OccasionId, x.MemberId });
                    table.ForeignKey(
                        name: "FK_OccasionMember_Baptism_BaptismId",
                        column: x => x.BaptismId,
                        principalTable: "Baptism",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OccasionMember_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OccasionMember_Occasion_OccasionId",
                        column: x => x.OccasionId,
                        principalTable: "Occasion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OccasionMember_Reunion_ReunionId",
                        column: x => x.ReunionId,
                        principalTable: "Reunion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OccasionMember_SundaySchool_SundaySchoolId",
                        column: x => x.SundaySchoolId,
                        principalTable: "SundaySchool",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Baptism_BaptizerId",
                table: "Baptism",
                column: "BaptizerId");

            migrationBuilder.CreateIndex(
                name: "IX_OccasionMember_BaptismId",
                table: "OccasionMember",
                column: "BaptismId");

            migrationBuilder.CreateIndex(
                name: "IX_OccasionMember_MemberId",
                table: "OccasionMember",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_OccasionMember_ReunionId",
                table: "OccasionMember",
                column: "ReunionId");

            migrationBuilder.CreateIndex(
                name: "IX_OccasionMember_SundaySchoolId",
                table: "OccasionMember",
                column: "SundaySchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Reunion_SpeakerId",
                table: "Reunion",
                column: "SpeakerId");

            migrationBuilder.CreateIndex(
                name: "IX_SundaySchool_TeacherId",
                table: "SundaySchool",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atypical");

            migrationBuilder.DropTable(
                name: "Cell");

            migrationBuilder.DropTable(
                name: "Cult");

            migrationBuilder.DropTable(
                name: "OccasionMember");

            migrationBuilder.DropTable(
                name: "Baptism");

            migrationBuilder.DropTable(
                name: "Reunion");

            migrationBuilder.DropTable(
                name: "SundaySchool");

            migrationBuilder.DropTable(
                name: "Occasion");
        }
    }
}
