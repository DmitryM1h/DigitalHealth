using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalHealth.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addMedicalDeviceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_MedicalRecords_Id",
                schema: "Telemetry",
                table: "Patients");

            migrationBuilder.AddColumn<Guid>(
                name: "MedicalCardId",
                schema: "Telemetry",
                table: "Patients",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "Telemetry",
                table: "MedicalRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Diagnosis",
                schema: "Telemetry",
                table: "MedicalRecords",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorId",
                schema: "Telemetry",
                table: "MedicalRecords",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MedicalCardId",
                schema: "Telemetry",
                table: "MedicalRecords",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Prescriptions",
                schema: "Telemetry",
                table: "MedicalRecords",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subjective",
                schema: "Telemetry",
                table: "MedicalRecords",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MedicalCard",
                schema: "Telemetry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BloodType = table.Column<string>(type: "text", nullable: true),
                    Allergies = table.Column<string>(type: "text", nullable: true),
                    ChronicConditions = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalCard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalDevice",
                schema: "Telemetry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelName = table.Column<string>(type: "text", nullable: false),
                    JsonContract = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalDevice", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MedicalCardId",
                schema: "Telemetry",
                table: "Patients",
                column: "MedicalCardId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_MedicalCardId",
                schema: "Telemetry",
                table: "MedicalRecords",
                column: "MedicalCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_MedicalCard_MedicalCardId",
                schema: "Telemetry",
                table: "MedicalRecords",
                column: "MedicalCardId",
                principalSchema: "Telemetry",
                principalTable: "MedicalCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_MedicalCard_MedicalCardId",
                schema: "Telemetry",
                table: "Patients",
                column: "MedicalCardId",
                principalSchema: "Telemetry",
                principalTable: "MedicalCard",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_MedicalCard_MedicalCardId",
                schema: "Telemetry",
                table: "MedicalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_MedicalCard_MedicalCardId",
                schema: "Telemetry",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "MedicalCard",
                schema: "Telemetry");

            migrationBuilder.DropTable(
                name: "MedicalDevice",
                schema: "Telemetry");

            migrationBuilder.DropIndex(
                name: "IX_Patients_MedicalCardId",
                schema: "Telemetry",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecords_MedicalCardId",
                schema: "Telemetry",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "MedicalCardId",
                schema: "Telemetry",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "Telemetry",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "Diagnosis",
                schema: "Telemetry",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                schema: "Telemetry",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "MedicalCardId",
                schema: "Telemetry",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "Prescriptions",
                schema: "Telemetry",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "Subjective",
                schema: "Telemetry",
                table: "MedicalRecords");

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
    }
}
