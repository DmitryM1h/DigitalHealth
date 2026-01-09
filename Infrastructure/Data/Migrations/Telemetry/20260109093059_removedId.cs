using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalHealth.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removedId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_MedicalRecords_MedicalRecordId",
                schema: "Telemetry",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_MedicalRecordId",
                schema: "Telemetry",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MedicalRecordId",
                schema: "Telemetry",
                table: "Patients");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_MedicalRecords_Id",
                schema: "Telemetry",
                table: "Patients",
                column: "Id",
                principalSchema: "Telemetry",
                principalTable: "MedicalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_MedicalRecords_Id",
                schema: "Telemetry",
                table: "Patients");

            migrationBuilder.AddColumn<Guid>(
                name: "MedicalRecordId",
                schema: "Telemetry",
                table: "Patients",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MedicalRecordId",
                schema: "Telemetry",
                table: "Patients",
                column: "MedicalRecordId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_MedicalRecords_MedicalRecordId",
                schema: "Telemetry",
                table: "Patients",
                column: "MedicalRecordId",
                principalSchema: "Telemetry",
                principalTable: "MedicalRecords",
                principalColumn: "Id");
        }
    }
}
