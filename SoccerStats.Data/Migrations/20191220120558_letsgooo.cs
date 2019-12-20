using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerStats.Data.Migrations
{
    public partial class letsgooo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                column: "MatchDate",
                value: new DateTime(2019, 12, 13, 13, 5, 57, 847, DateTimeKind.Local).AddTicks(834));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                column: "MatchDate",
                value: new DateTime(2019, 12, 13, 12, 9, 38, 470, DateTimeKind.Local).AddTicks(2865));
        }
    }
}
