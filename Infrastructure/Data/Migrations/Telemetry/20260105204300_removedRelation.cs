using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removedRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorPatient",
                schema: "Telemetry");

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorId",
                schema: "Telemetry",
                table: "Patients",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorId1",
                schema: "Telemetry",
                table: "CalendarBlocks",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DoctorId",
                schema: "Telemetry",
                table: "Patients",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarBlocks_DoctorId1",
                schema: "Telemetry",
                table: "CalendarBlocks",
                column: "DoctorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarBlocks_Doctors_DoctorId1",
                schema: "Telemetry",
                table: "CalendarBlocks",
                column: "DoctorId1",
                principalSchema: "Telemetry",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Doctors_DoctorId",
                schema: "Telemetry",
                table: "Patients",
                column: "DoctorId",
                principalSchema: "Telemetry",
                principalTable: "Doctors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalendarBlocks_Doctors_DoctorId1",
                schema: "Telemetry",
                table: "CalendarBlocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Doctors_DoctorId",
                schema: "Telemetry",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_DoctorId",
                schema: "Telemetry",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_CalendarBlocks_DoctorId1",
                schema: "Telemetry",
                table: "CalendarBlocks");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                schema: "Telemetry",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                schema: "Telemetry",
                table: "CalendarBlocks");

            migrationBuilder.CreateTable(
                name: "DoctorPatient",
                schema: "Telemetry",
                columns: table => new
                {
                    DoctorsId = table.Column<Guid>(type: "uuid", nullable: false),
                    PatientsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorPatient", x => new { x.DoctorsId, x.PatientsId });
                    table.ForeignKey(
                        name: "FK_DoctorPatient_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalSchema: "Telemetry",
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorPatient_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalSchema: "Telemetry",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPatient_PatientsId",
                schema: "Telemetry",
                table: "DoctorPatient",
                column: "PatientsId");
        }
    }
}
