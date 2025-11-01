using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
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
                    Monday_StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Monday_EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Tuesday_StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Tuesday_EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Thursday_StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Thursday_EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Wednesday_StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Wednesday_EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Friday_StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Friday_EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Saturday_StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Saturday_EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Sunday_StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Sunday_EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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
                    MedicalRecordId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalSchema: "Telemetry",
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                schema: "Telemetry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Specialty = table.Column<string>(type: "text", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    WorkScheduleId = table.Column<Guid>(type: "uuid", nullable: true),
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Doctors_WorkSchedules_WorkScheduleId",
                        column: x => x.WorkScheduleId,
                        principalSchema: "Telemetry",
                        principalTable: "WorkSchedules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                schema: "Telemetry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EventPeriod_StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EventPeriod_EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uuid", nullable: false),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false)
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
                name: "DoctorPatient",
                schema: "Telemetry",
                columns: table => new
                {
                    PatientsId = table.Column<Guid>(type: "uuid", nullable: false),
                    doctorsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorPatient", x => new { x.PatientsId, x.doctorsId });
                    table.ForeignKey(
                        name: "FK_DoctorPatient_Doctors_doctorsId",
                        column: x => x.doctorsId,
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
                name: "IX_DoctorPatient_doctorsId",
                schema: "Telemetry",
                table: "DoctorPatient",
                column: "doctorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ClinicId",
                schema: "Telemetry",
                table: "Doctors",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorInfoId",
                schema: "Telemetry",
                table: "Doctors",
                column: "DoctorInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_WorkScheduleId",
                schema: "Telemetry",
                table: "Doctors",
                column: "WorkScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MedicalRecordId",
                schema: "Telemetry",
                table: "Patients",
                column: "MedicalRecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments",
                schema: "Telemetry");

            migrationBuilder.DropTable(
                name: "DoctorPatient",
                schema: "Telemetry");

            migrationBuilder.DropTable(
                name: "Doctors",
                schema: "Telemetry");

            migrationBuilder.DropTable(
                name: "Patients",
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

            migrationBuilder.DropTable(
                name: "MedicalRecords",
                schema: "Telemetry");
        }
    }
}
