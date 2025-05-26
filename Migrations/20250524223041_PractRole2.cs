using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Vita_APIs.Migrations
{
    /// <inheritdoc />
    public partial class PractRole2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "practitionerRolePractitionerId",
                table: "Practitioners_Role",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Practitioners_Role_practitionerRolePractitionerId",
                table: "Practitioners_Role",
                column: "practitionerRolePractitionerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Practitioners_Role_Practitioners_Role_practitionerRolePracti~",
                table: "Practitioners_Role",
                column: "practitionerRolePractitionerId",
                principalTable: "Practitioners_Role",
                principalColumn: "PractitionerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Practitioners_Role_Practitioners_Role_practitionerRolePracti~",
                table: "Practitioners_Role");

            migrationBuilder.DropIndex(
                name: "IX_Practitioners_Role_practitionerRolePractitionerId",
                table: "Practitioners_Role");

            migrationBuilder.DropColumn(
                name: "practitionerRolePractitionerId",
                table: "Practitioners_Role");
        }
    }
}
