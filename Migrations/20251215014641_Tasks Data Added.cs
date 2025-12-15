using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class TasksDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "ID", "CreatedAt", "Description", "IsCompleted", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 15, 1, 46, 39, 848, DateTimeKind.Utc).AddTicks(1906), "Description for Task 1", false, "Task 1" },
                    { 2, new DateTime(2025, 12, 15, 1, 46, 39, 848, DateTimeKind.Utc).AddTicks(2299), "Description for Task 2", false, "Task 2" },
                    { 3, new DateTime(2025, 12, 15, 1, 46, 39, 848, DateTimeKind.Utc).AddTicks(2301), "Description for Task 3", false, "Task 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
