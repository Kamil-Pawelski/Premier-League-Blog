using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PremierLeagueBlog.Server.Migrations
{
    /// <inheritdoc />
    public partial class SampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Date", "Description", "Image", "Summary", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 26, 14, 24, 11, 417, DateTimeKind.Local).AddTicks(9870), "Detailed description of the article 1...", "sample1.png", "Sample summary of the article 1...", "Sample Article Title 1" },
                    { 2, new DateTime(2024, 5, 25, 14, 24, 11, 417, DateTimeKind.Local).AddTicks(9896), "Detailed description of the article 2...", "sample1.png", "Sample summary of the article 2...", "Sample Article Title 2" },
                    { 3, new DateTime(2024, 5, 24, 14, 24, 11, 417, DateTimeKind.Local).AddTicks(9899), "Detailed description of the article 3...", "sample1.png", "Sample summary of the article 3...", "Sample Article Title 3" },
                    { 4, new DateTime(2024, 5, 23, 14, 24, 11, 417, DateTimeKind.Local).AddTicks(9901), "Detailed description of the article 4...", "sample1.png", "Sample summary of the article 4...", "Sample Article Title 4" },
                    { 5, new DateTime(2024, 5, 22, 14, 24, 11, 417, DateTimeKind.Local).AddTicks(9903), "Detailed description of the article 5...", "sample1.png", "Sample summary of the article 5...", "Sample Article Title 5" },
                    { 6, new DateTime(2024, 5, 21, 14, 24, 11, 417, DateTimeKind.Local).AddTicks(9905), "Detailed description of the article 6...", "sample1.png", "Sample summary of the article 6...", "Sample Article Title 6" },
                    { 7, new DateTime(2024, 5, 20, 14, 24, 11, 417, DateTimeKind.Local).AddTicks(9908), "Detailed description of the article 7...", "sample1.png", "Sample summary of the article 7...", "Sample Article Title 7" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
