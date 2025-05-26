using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Vita_APIs.Migrations
{
    /// <inheritdoc />
    public partial class SharedNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "practitionerRole",
                table: "Practitioners_Role");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "practitionerRole",
                table: "Practitioners_Role",
                type: "int",
                nullable: true);
        }
    }
}
