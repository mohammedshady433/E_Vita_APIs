using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Vita_APIs.Migrations
{
    /// <inheritdoc />
    public partial class removeRadiologyandPrescriptionRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Radiologies_RadiologyTestId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_RadiologyTestId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "RadiologyTestId",
                table: "Prescriptions");

            migrationBuilder.AddColumn<string>(
                name: "RadiologyTest",
                table: "Prescriptions",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RadiologyTest",
                table: "Prescriptions");

            migrationBuilder.AddColumn<int>(
                name: "RadiologyTestId",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_RadiologyTestId",
                table: "Prescriptions",
                column: "RadiologyTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Radiologies_RadiologyTestId",
                table: "Prescriptions",
                column: "RadiologyTestId",
                principalTable: "Radiologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
