using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DigitalHealth.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialTelemetry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Telemetry");

            migrationBuilder.CreateTable(
                name: "Clinics",
                schema: "Telemetry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorInfos",
                schema: "Telemetry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShortBio = table.Column<string>(type: "text", nullable: true),
                    Education = table.Column<string>(type: "text", nullable: true),
                    Qualifications = table.Column<string>(type: "text", nullable: true),
                    Awards = table.Column<string>(type: "text", nullable: true),
                    Publications = table.Column<string>(type: "text", nullable: true),
                    PhotoUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                schema: "Telemetry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkSchedules",
                schema: "Telemetry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Friday_EndDate = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    Friday_StartDate = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    Monday_EndDate = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    Monday_StartDate = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    Saturday_EndDate = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    Saturday_StartDate = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    Sunday_EndDate = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    Sunday_StartDate = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    Thursday_EndDate = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    Thursday_StartDate = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    Tuesday_EndDate = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    Tuesday_StartDate = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    Wednesday_EndDate = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    Wednesday_StartDate = table.Column<TimeOnly>(type: "time without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSchedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                schema: "Telemetry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    MedicalRecordId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalSchema: "Telemetry",
                        principalTable: "MedicalRecords",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                schema: "Telemetry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Specialty = table.Column<string>(type: "text", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    ClinicId = table.Column<Guid>(type: "uuid", nullable: false),
                    DoctorInfoId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalSchema: "Telemetry",
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_DoctorInfos_DoctorInfoId",
                        column: x => x.DoctorInfoId,
                        principalSchema: "Telemetry",
                        principalTable: "DoctorInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_WorkSchedules_Id",
                        column: x => x.Id,
                        principalSchema: "Telemetry",
                        principalTable: "WorkSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                schema: "Telemetry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventPeriod_EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EventPeriod_StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "Telemetry",
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "Telemetry",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalendarBlocks",
                schema: "Telemetry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uuid", nullable: false),
                    period_StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    period_EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BlockReason = table.Column<string>(type: "text", nullable: false),
                    IsBusy = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarBlocks_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "Telemetry",
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Telemetry",
                table: "Clinics",
                columns: new[] { "Id", "Address", "City" },
                values: new object[,]
                {
                    { new Guid("14444444-4444-4444-4444-444444444444"), "123 Main Street", "New York" },
                    { new Guid("24444444-4444-4444-4444-444444444444"), "456 Oak Avenue", "Los Angeles" },
                    { new Guid("34444444-4444-4444-4444-444444444444"), "789 Pine Street", "Chicago" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "321 Elm Street", "Houston" },
                    { new Guid("54444444-4444-4444-4444-444444444444"), "654 Beach Boulevard", "Miami" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                schema: "Telemetry",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                schema: "Telemetry",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarBlocks_DoctorId",
                schema: "Telemetry",
                table: "CalendarBlocks",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ClinicId",
                schema: "Telemetry",
                table: "Doctors",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorInfoId",
                schema: "Telemetry",
                table: "Doctors",
                column: "DoctorInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MedicalRecordId",
                schema: "Telemetry",
                table: "Patients",
                column: "MedicalRecordId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments",
                schema: "Telemetry");

            migrationBuilder.DropTable(
                name: "CalendarBlocks",
                schema: "Telemetry");

            migrationBuilder.DropTable(
                name: "Patients",
                schema: "Telemetry");

            migrationBuilder.DropTable(
                name: "Doctors",
                schema: "Telemetry");

            migrationBuilder.DropTable(
                name: "MedicalRecords",
                schema: "Telemetry");

            migrationBuilder.DropTable(
                name: "Clinics",
                schema: "Telemetry");

            migrationBuilder.DropTable(
                name: "DoctorInfos",
                schema: "Telemetry");

            migrationBuilder.DropTable(
                name: "WorkSchedules",
                schema: "Telemetry");
        }
    }
}
