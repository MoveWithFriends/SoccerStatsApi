using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerStats.Data.Migrations
{
    public partial class initialnewdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                column: "MatchDate",
                value: new DateTime(2019, 12, 13, 14, 31, 27, 179, DateTimeKind.Local).AddTicks(3101));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                column: "MatchDate",
                value: new DateTime(2019, 12, 13, 13, 38, 17, 922, DateTimeKind.Local).AddTicks(1895));
        }
    }
}
