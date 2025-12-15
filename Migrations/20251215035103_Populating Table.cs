using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulatingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 15, 3, 51, 2, 226, DateTimeKind.Utc).AddTicks(52));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 15, 3, 51, 2, 226, DateTimeKind.Utc).AddTicks(1710));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 15, 3, 51, 2, 226, DateTimeKind.Utc).AddTicks(1714));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 15, 3, 40, 38, 644, DateTimeKind.Utc).AddTicks(9002));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 15, 3, 40, 38, 645, DateTimeKind.Utc).AddTicks(654));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 15, 3, 40, 38, 645, DateTimeKind.Utc).AddTicks(657));
        }
    }
}
