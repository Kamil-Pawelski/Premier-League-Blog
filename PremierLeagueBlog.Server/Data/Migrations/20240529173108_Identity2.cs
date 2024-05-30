using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PremierLeagueBlog.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Identity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 5, 28, 19, 31, 8, 359, DateTimeKind.Local).AddTicks(3355));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 5, 27, 19, 31, 8, 359, DateTimeKind.Local).AddTicks(3378));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 5, 26, 19, 31, 8, 359, DateTimeKind.Local).AddTicks(3381));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 5, 25, 19, 31, 8, 359, DateTimeKind.Local).AddTicks(3384));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 5, 24, 19, 31, 8, 359, DateTimeKind.Local).AddTicks(3386));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2024, 5, 23, 19, 31, 8, 359, DateTimeKind.Local).AddTicks(3388));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2024, 5, 22, 19, 31, 8, 359, DateTimeKind.Local).AddTicks(3390));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 5, 28, 19, 13, 21, 686, DateTimeKind.Local).AddTicks(7234));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 5, 27, 19, 13, 21, 686, DateTimeKind.Local).AddTicks(7253));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 5, 26, 19, 13, 21, 686, DateTimeKind.Local).AddTicks(7256));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 5, 25, 19, 13, 21, 686, DateTimeKind.Local).AddTicks(7258));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 5, 24, 19, 13, 21, 686, DateTimeKind.Local).AddTicks(7260));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2024, 5, 23, 19, 13, 21, 686, DateTimeKind.Local).AddTicks(7262));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2024, 5, 22, 19, 13, 21, 686, DateTimeKind.Local).AddTicks(7264));
        }
    }
}
