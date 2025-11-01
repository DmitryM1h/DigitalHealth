using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Id", "Capacity", "ClinicId", "DoctorInfoId", "Specialty", "WorkScheduleId" },
                values: new object[,]
                {
                    { new Guid("0c20650f-2292-49be-a8ca-472840796d01"), 16, new Guid("34444444-4444-4444-4444-444444444444"), null, "Ophthalmology", null },
                    { new Guid("23b44eb4-fd3d-412e-9173-16c9637b54de"), 6, new Guid("34444444-4444-4444-4444-444444444444"), null, "Neurology", null },
                    { new Guid("3fae1883-20e2-4104-8b24-50c7a33a887c"), 14, new Guid("44444444-4444-4444-4444-444444444444"), null, "Orthopedics", null },
                    { new Guid("4b435321-57aa-4824-b84d-b9c0b6d48026"), 27, new Guid("44444444-4444-4444-4444-444444444444"), null, "Ophthalmology", null },
                    { new Guid("530fde18-4608-46c5-86f9-0b3b6a796477"), 17, new Guid("34444444-4444-4444-4444-444444444444"), null, "Orthopedics", null },
                    { new Guid("5e455427-77cb-4487-ab64-65c41fd7b323"), 8, new Guid("34444444-4444-4444-4444-444444444444"), null, "Pediatrics", null },
                    { new Guid("70e6d464-0e41-456c-afe7-f641b5515571"), 9, new Guid("34444444-4444-4444-4444-444444444444"), null, "Orthopedics", null },
                    { new Guid("7bd13973-1f8b-47f4-854e-5cf7fe3b9e35"), 30, new Guid("34444444-4444-4444-4444-444444444444"), null, "Cardiology", null },
                    { new Guid("8a6e1429-d9bc-4187-b800-109beab8b73e"), 9, new Guid("24444444-4444-4444-4444-444444444444"), null, "Surgery", null },
                    { new Guid("8b99fbe5-3c4e-4f62-8d80-75ef7ae24e3c"), 38, new Guid("24444444-4444-4444-4444-444444444444"), null, "Radiology", null },
                    { new Guid("96888a6c-33e7-4d3f-8358-0e920aa0a9ff"), 20, new Guid("44444444-4444-4444-4444-444444444444"), null, "Oncology", null },
                    { new Guid("97d04abc-f378-4f3a-be32-cbc6c263e651"), 37, new Guid("34444444-4444-4444-4444-444444444444"), null, "Pediatrics", null },
                    { new Guid("980e468b-16cd-40e4-af35-8a6eb3187814"), 27, new Guid("24444444-4444-4444-4444-444444444444"), null, "Psychiatry", null },
                    { new Guid("b32bcc97-6449-4b79-a47c-d8de2f5873e5"), 6, new Guid("34444444-4444-4444-4444-444444444444"), null, "Ophthalmology", null },
                    { new Guid("c34404bb-0b48-46a7-8548-524cc7832dc8"), 7, new Guid("44444444-4444-4444-4444-444444444444"), null, "Psychiatry", null },
                    { new Guid("cd31ed37-c71d-422a-935e-3382a949153d"), 38, new Guid("24444444-4444-4444-4444-444444444444"), null, "Surgery", null },
                    { new Guid("cd5e3176-456d-459a-b794-83147d10e4d8"), 5, new Guid("24444444-4444-4444-4444-444444444444"), null, "Pediatrics", null },
                    { new Guid("dacf14e9-77da-4790-a8ac-939a050cd05d"), 16, new Guid("44444444-4444-4444-4444-444444444444"), null, "Cardiology", null },
                    { new Guid("f5a65ca9-4f63-4f7e-8fdb-a3adcb8deaee"), 21, new Guid("44444444-4444-4444-4444-444444444444"), null, "Ophthalmology", null },
                    { new Guid("faca1a7f-7ef7-42ac-bb64-d04675705cc3"), 39, new Guid("24444444-4444-4444-4444-444444444444"), null, "Psychiatry", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Clinics",
                keyColumn: "Id",
                keyValue: new Guid("14444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Clinics",
                keyColumn: "Id",
                keyValue: new Guid("54444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("0c20650f-2292-49be-a8ca-472840796d01"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("23b44eb4-fd3d-412e-9173-16c9637b54de"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("3fae1883-20e2-4104-8b24-50c7a33a887c"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("4b435321-57aa-4824-b84d-b9c0b6d48026"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("530fde18-4608-46c5-86f9-0b3b6a796477"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("5e455427-77cb-4487-ab64-65c41fd7b323"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("70e6d464-0e41-456c-afe7-f641b5515571"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("7bd13973-1f8b-47f4-854e-5cf7fe3b9e35"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("8a6e1429-d9bc-4187-b800-109beab8b73e"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("8b99fbe5-3c4e-4f62-8d80-75ef7ae24e3c"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("96888a6c-33e7-4d3f-8358-0e920aa0a9ff"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("97d04abc-f378-4f3a-be32-cbc6c263e651"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("980e468b-16cd-40e4-af35-8a6eb3187814"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("b32bcc97-6449-4b79-a47c-d8de2f5873e5"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("c34404bb-0b48-46a7-8548-524cc7832dc8"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("cd31ed37-c71d-422a-935e-3382a949153d"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("cd5e3176-456d-459a-b794-83147d10e4d8"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("dacf14e9-77da-4790-a8ac-939a050cd05d"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("f5a65ca9-4f63-4f7e-8fdb-a3adcb8deaee"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("faca1a7f-7ef7-42ac-bb64-d04675705cc3"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Clinics",
                keyColumn: "Id",
                keyValue: new Guid("24444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Clinics",
                keyColumn: "Id",
                keyValue: new Guid("34444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Clinics",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));
        }
    }
}
