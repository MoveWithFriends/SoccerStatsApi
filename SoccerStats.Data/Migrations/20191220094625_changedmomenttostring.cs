using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerStats.Data.Migrations
{
    public partial class changedmomenttostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Moment",
                table: "MatchMoments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "MatchMoments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Moment",
                value: "Goal");

            migrationBuilder.UpdateData(
                table: "MatchMoments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Moment",
                value: "YellowCard");

            migrationBuilder.UpdateData(
                table: "MatchMoments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Moment",
                value: "RedCard");

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                column: "MatchDate",
                value: new DateTime(2019, 12, 13, 10, 46, 24, 891, DateTimeKind.Local).AddTicks(7882));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Moment",
                table: "MatchMoments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "MatchMoments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Moment",
                value: 2);

            migrationBuilder.UpdateData(
                table: "MatchMoments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Moment",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MatchMoments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Moment",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                column: "MatchDate",
                value: new DateTime(2019, 12, 13, 9, 25, 26, 903, DateTimeKind.Local).AddTicks(5994));
        }
    }
}
