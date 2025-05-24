using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Vita_APIs.Migrations
{
    /// <inheritdoc />
    public partial class RoomnumberModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Practitioners_PractitionerId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_PractitionerId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "PractitionerId",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "Floor",
                table: "Rooms",
                newName: "RoomNumber");

            migrationBuilder.AlterColumn<int>(
                name: "NurseId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_DoctorId",
                table: "Rooms",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Practitioners_DoctorId",
                table: "Rooms",
                column: "DoctorId",
                principalTable: "Practitioners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Practitioners_DoctorId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_DoctorId",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "RoomNumber",
                table: "Rooms",
                newName: "Floor");

            migrationBuilder.AlterColumn<int>(
                name: "NurseId",
                table: "Rooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Rooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PractitionerId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_PractitionerId",
                table: "Rooms",
                column: "PractitionerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Practitioners_PractitionerId",
                table: "Rooms",
                column: "PractitionerId",
                principalTable: "Practitioners",
                principalColumn: "Id");
        }
    }
}
