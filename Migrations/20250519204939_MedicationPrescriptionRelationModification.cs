using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Vita_APIs.Migrations
{
    /// <inheritdoc />
    public partial class MedicationPrescriptionRelationModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Medications_MedicationId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_MedicationId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "MedicationId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "Medication_name",
                table: "Prescriptions");

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionId",
                table: "Medications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Medications_PrescriptionId",
                table: "Medications",
                column: "PrescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medications_Prescriptions_PrescriptionId",
                table: "Medications",
                column: "PrescriptionId",
                principalTable: "Prescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Prescriptions_PrescriptionId",
                table: "Medications");

            migrationBuilder.DropIndex(
                name: "IX_Medications_PrescriptionId",
                table: "Medications");

            migrationBuilder.DropColumn(
                name: "PrescriptionId",
                table: "Medications");

            migrationBuilder.AddColumn<int>(
                name: "MedicationId",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Medication_name",
                table: "Prescriptions",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_MedicationId",
                table: "Prescriptions",
                column: "MedicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Medications_MedicationId",
                table: "Prescriptions",
                column: "MedicationId",
                principalTable: "Medications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
