using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                name: "Doctors",
                schema: "Telemetry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_WorkSchedules_Doctors_Id",
                        column: x => x.Id,
                        principalSchema: "Telemetry",
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                schema: "Telemetry",
                table: "Doctors",
                columns: new[] { "Id", "Capacity", "ClinicId", "DoctorInfoId", "Specialty" },
                values: new object[,]
                {
                    { new Guid("010ec82e-cbb0-4287-8ae7-b2b3d15ec3bd"), 12, new Guid("24444444-4444-4444-4444-444444444444"), null, "Cardiology" },
                    { new Guid("0538e8aa-a1cc-44ea-a733-298c2a3178df"), 25, new Guid("34444444-4444-4444-4444-444444444444"), null, "Ophthalmology" },
                    { new Guid("1a223f5f-dfee-4471-992b-7edf285e2efa"), 24, new Guid("34444444-4444-4444-4444-444444444444"), null, "Ophthalmology" },
                    { new Guid("21d99907-299a-4199-b683-8c27e7919d07"), 21, new Guid("24444444-4444-4444-4444-444444444444"), null, "Ophthalmology" },
                    { new Guid("279c8e2c-3b46-4034-8b97-e9d1b93d05bc"), 17, new Guid("34444444-4444-4444-4444-444444444444"), null, "Cardiology" },
                    { new Guid("30f99b5a-c21a-4d58-9d9a-fb458f63b68e"), 21, new Guid("44444444-4444-4444-4444-444444444444"), null, "Psychiatry" },
                    { new Guid("428c03d6-1ded-4d62-a279-5d28591b5634"), 31, new Guid("24444444-4444-4444-4444-444444444444"), null, "Orthopedics" },
                    { new Guid("4ef99f3c-6f37-4b6d-b704-620cf6b460c4"), 29, new Guid("44444444-4444-4444-4444-444444444444"), null, "Dermatology" },
                    { new Guid("509c7f59-e199-4325-bd4a-2990d3118deb"), 36, new Guid("24444444-4444-4444-4444-444444444444"), null, "Ophthalmology" },
                    { new Guid("591e08d0-7117-4154-819e-297d1b597462"), 32, new Guid("44444444-4444-4444-4444-444444444444"), null, "Dermatology" },
                    { new Guid("a038faff-7234-4101-baa4-186025dc1972"), 39, new Guid("44444444-4444-4444-4444-444444444444"), null, "Oncology" },
                    { new Guid("aeddd81c-688a-4481-816c-a6983475ba45"), 29, new Guid("24444444-4444-4444-4444-444444444444"), null, "Cardiology" },
                    { new Guid("b3304078-16d7-416f-806f-5b6e7197e56e"), 26, new Guid("24444444-4444-4444-4444-444444444444"), null, "Neurology" },
                    { new Guid("b6cc452d-5711-47fd-aee5-a5483df8d31f"), 9, new Guid("34444444-4444-4444-4444-444444444444"), null, "Neurology" },
                    { new Guid("bcd069af-9a79-4f17-8240-7e8414c23616"), 33, new Guid("34444444-4444-4444-4444-444444444444"), null, "Dermatology" },
                    { new Guid("c064aed7-b71a-4af2-a092-05f2a7d1f717"), 17, new Guid("34444444-4444-4444-4444-444444444444"), null, "Psychiatry" },
                    { new Guid("c1286101-66b8-4717-a97e-232584623f62"), 35, new Guid("34444444-4444-4444-4444-444444444444"), null, "Ophthalmology" },
                    { new Guid("ce367d1b-affe-4b98-a1a9-9fe93629dfe7"), 9, new Guid("34444444-4444-4444-4444-444444444444"), null, "Cardiology" },
                    { new Guid("d808433a-ee98-4bed-9c8c-e2bfb628aed1"), 12, new Guid("44444444-4444-4444-4444-444444444444"), null, "Dermatology" },
                    { new Guid("e1b0282d-fb1d-4add-83fa-182663c2f02f"), 35, new Guid("24444444-4444-4444-4444-444444444444"), null, "Surgery" }
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
                name: "DoctorPatient",
                schema: "Telemetry");

            migrationBuilder.DropTable(
                name: "WorkSchedules",
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
        }
    }
}
