using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerStats.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchDate = table.Column<DateTime>(nullable: false),
                    TeamId = table.Column<int>(nullable: false),
                    HomeTeam = table.Column<bool>(nullable: false),
                    HomeGoals = table.Column<int>(nullable: false),
                    AwayGoals = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    BackNumber = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchMoments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    Moment = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchMoments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchMoments_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchMoments_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayerMatchResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    PlayTime = table.Column<int>(nullable: false),
                    SubTime = table.Column<int>(nullable: false),
                    Goals = table.Column<int>(nullable: true),
                    YellowCards = table.Column<int>(nullable: true),
                    RedCards = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMatchResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerMatchResults_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerMatchResults_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "TeamName" },
                values: new object[] { 1, "DWO" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "TeamName" },
                values: new object[] { 2, "Sick" });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "AwayGoals", "HomeGoals", "HomeTeam", "MatchDate", "TeamId" },
                values: new object[] { 1, 0, 1, true, new DateTime(2019, 12, 4, 16, 35, 9, 513, DateTimeKind.Local).AddTicks(7943), 1 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BackNumber", "FirstName", "LastName", "TeamId" },
                values: new object[,]
                {
                    { 1, 7, "Nick", "Sluiters", 1 },
                    { 2, 1, "Jurgen", "Paapen", 1 },
                    { 3, 4, "Joost", "Oomen", 1 }
                });

            migrationBuilder.InsertData(
                table: "MatchMoments",
                columns: new[] { "Id", "MatchId", "Moment", "PlayerId", "TimeStamp" },
                values: new object[,]
                {
                    { 1, 1, 2, 1, 30 },
                    { 2, 1, 1, 2, 40 },
                    { 3, 1, 0, 3, 60 }
                });

            migrationBuilder.InsertData(
                table: "PlayerMatchResults",
                columns: new[] { "Id", "Goals", "MatchId", "PlayTime", "PlayerId", "RedCards", "SubTime", "YellowCards" },
                values: new object[,]
                {
                    { 1, 1, 1, 0, 1, 0, 0, 0 },
                    { 2, 0, 1, 0, 2, 0, 0, 1 },
                    { 3, 0, 1, 0, 3, 1, 0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TeamId",
                table: "Matches",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchMoments_MatchId",
                table: "MatchMoments",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchMoments_PlayerId",
                table: "MatchMoments",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatchResults_MatchId",
                table: "PlayerMatchResults",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatchResults_PlayerId",
                table: "PlayerMatchResults",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchMoments");

            migrationBuilder.DropTable(
                name: "PlayerMatchResults");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
