using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Vita_APIs.Migrations
{
    /// <inheritdoc />
    public partial class AlotofModifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Practitioners");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Practitioners");

            migrationBuilder.AddColumn<string>(
                name: "Rank",
                table: "Practitioners",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Practitioners");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Practitioners",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Practitioners",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
