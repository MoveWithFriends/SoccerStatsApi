using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerStats.Data.Migrations
{
    public partial class goooo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                column: "MatchDate",
                value: new DateTime(2019, 12, 13, 11, 59, 0, 900, DateTimeKind.Local).AddTicks(4922));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                column: "MatchDate",
                value: new DateTime(2019, 12, 13, 11, 55, 40, 628, DateTimeKind.Local).AddTicks(4639));
        }
    }
}
