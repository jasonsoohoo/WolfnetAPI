using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WolfnetAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Number = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionTeam",
                columns: table => new
                {
                    CompetitionsId = table.Column<int>(type: "integer", nullable: false),
                    TeamsNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionTeam", x => new { x.CompetitionsId, x.TeamsNumber });
                    table.ForeignKey(
                        name: "FK_CompetitionTeam_Competition_CompetitionsId",
                        column: x => x.CompetitionsId,
                        principalTable: "Competition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionTeam_Team_TeamsNumber",
                        column: x => x.TeamsNumber,
                        principalTable: "Team",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    RedOneNumber = table.Column<string>(type: "text", nullable: true),
                    RedTwoNumber = table.Column<string>(type: "text", nullable: true),
                    RedThreeNumber = table.Column<string>(type: "text", nullable: true),
                    BlueOneNumber = table.Column<string>(type: "text", nullable: true),
                    BlueTwoNumber = table.Column<string>(type: "text", nullable: true),
                    BlueThreeNumber = table.Column<string>(type: "text", nullable: true),
                    CompetitionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Competition_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competition",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_Team_BlueOneNumber",
                        column: x => x.BlueOneNumber,
                        principalTable: "Team",
                        principalColumn: "Number");
                    table.ForeignKey(
                        name: "FK_Matches_Team_BlueThreeNumber",
                        column: x => x.BlueThreeNumber,
                        principalTable: "Team",
                        principalColumn: "Number");
                    table.ForeignKey(
                        name: "FK_Matches_Team_BlueTwoNumber",
                        column: x => x.BlueTwoNumber,
                        principalTable: "Team",
                        principalColumn: "Number");
                    table.ForeignKey(
                        name: "FK_Matches_Team_RedOneNumber",
                        column: x => x.RedOneNumber,
                        principalTable: "Team",
                        principalColumn: "Number");
                    table.ForeignKey(
                        name: "FK_Matches_Team_RedThreeNumber",
                        column: x => x.RedThreeNumber,
                        principalTable: "Team",
                        principalColumn: "Number");
                    table.ForeignKey(
                        name: "FK_Matches_Team_RedTwoNumber",
                        column: x => x.RedTwoNumber,
                        principalTable: "Team",
                        principalColumn: "Number");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionTeam_TeamsNumber",
                table: "CompetitionTeam",
                column: "TeamsNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_BlueOneNumber",
                table: "Matches",
                column: "BlueOneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_BlueThreeNumber",
                table: "Matches",
                column: "BlueThreeNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_BlueTwoNumber",
                table: "Matches",
                column: "BlueTwoNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_CompetitionId",
                table: "Matches",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_RedOneNumber",
                table: "Matches",
                column: "RedOneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_RedThreeNumber",
                table: "Matches",
                column: "RedThreeNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_RedTwoNumber",
                table: "Matches",
                column: "RedTwoNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionTeam");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Competition");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
