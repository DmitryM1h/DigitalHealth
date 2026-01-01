using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateее : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatient_Doctors_doctorsId",
                schema: "Telemetry",
                table: "DoctorPatient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorPatient",
                schema: "Telemetry",
                table: "DoctorPatient");

            migrationBuilder.DropIndex(
                name: "IX_DoctorPatient_doctorsId",
                schema: "Telemetry",
                table: "DoctorPatient");

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("141694e8-0303-4bbf-a8d5-97a8122d69ad"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("160577c6-94f9-4f39-8ab1-18211e448484"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("242d0a32-87ef-4f13-81b4-bee8c1a6ed32"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("249d42c7-e8c1-45a5-86c5-54e9a3fdbadc"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("2ca9e97a-9579-4e60-b16c-646fde1bcdca"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("31efc166-6952-4bdf-8b41-9e671d8e0172"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("3857df71-cc3b-45d1-9531-29e178451f02"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("3c08352b-35cd-4ec0-9f1f-589b574ef97a"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("5ad8ad11-bcd4-4fb7-8d1c-1ea7d3b93341"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("71b77986-aa73-442a-a25f-a7c523b9465c"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("9382e511-8508-453b-b561-10be2b9f580f"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("c986b63d-ac03-4ac8-9382-3c20a88728b6"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("cc6b4cf4-a13b-49fa-83f6-651cc4f8b1c4"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("cf8ae6cc-ba76-4384-abb7-a94b52f155e7"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("d4b7811c-a7ce-4e4b-8734-df0dd7ca3a0e"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("d6d1083b-5584-413f-90ec-39fa45cdc0c0"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("dd40d06c-a281-49ca-bc4d-88041a737ca0"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("eee5db30-095e-4d08-9b2f-79e359c591c4"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("f095151b-0ad7-4750-a289-0f209021bfe0"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("fe29003c-efee-4504-aa95-682d63e4051b"));

            migrationBuilder.RenameColumn(
                name: "doctorsId",
                schema: "Telemetry",
                table: "DoctorPatient",
                newName: "DoctorsId");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "Telemetry",
                table: "Patients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "Telemetry",
                table: "Doctors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorPatient",
                schema: "Telemetry",
                table: "DoctorPatient",
                columns: new[] { "DoctorsId", "PatientsId" });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPatient_PatientsId",
                schema: "Telemetry",
                table: "DoctorPatient",
                column: "PatientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPatient_Doctors_DoctorsId",
                schema: "Telemetry",
                table: "DoctorPatient",
                column: "DoctorsId",
                principalSchema: "Telemetry",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatient_Doctors_DoctorsId",
                schema: "Telemetry",
                table: "DoctorPatient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorPatient",
                schema: "Telemetry",
                table: "DoctorPatient");

            migrationBuilder.DropIndex(
                name: "IX_DoctorPatient_PatientsId",
                schema: "Telemetry",
                table: "DoctorPatient");

            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "Telemetry",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "Telemetry",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "DoctorsId",
                schema: "Telemetry",
                table: "DoctorPatient",
                newName: "doctorsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorPatient",
                schema: "Telemetry",
                table: "DoctorPatient",
                columns: new[] { "PatientsId", "doctorsId" });

            migrationBuilder.InsertData(
                schema: "Telemetry",
                table: "Doctors",
                columns: new[] { "Id", "Capacity", "ClinicId", "DoctorInfoId", "Specialty" },
                values: new object[,]
                {
                    { new Guid("141694e8-0303-4bbf-a8d5-97a8122d69ad"), 19, new Guid("24444444-4444-4444-4444-444444444444"), null, "Cardiology" },
                    { new Guid("160577c6-94f9-4f39-8ab1-18211e448484"), 30, new Guid("24444444-4444-4444-4444-444444444444"), null, "Surgery" },
                    { new Guid("242d0a32-87ef-4f13-81b4-bee8c1a6ed32"), 23, new Guid("24444444-4444-4444-4444-444444444444"), null, "Radiology" },
                    { new Guid("249d42c7-e8c1-45a5-86c5-54e9a3fdbadc"), 5, new Guid("34444444-4444-4444-4444-444444444444"), null, "Cardiology" },
                    { new Guid("2ca9e97a-9579-4e60-b16c-646fde1bcdca"), 19, new Guid("24444444-4444-4444-4444-444444444444"), null, "Pediatrics" },
                    { new Guid("31efc166-6952-4bdf-8b41-9e671d8e0172"), 29, new Guid("34444444-4444-4444-4444-444444444444"), null, "Orthopedics" },
                    { new Guid("3857df71-cc3b-45d1-9531-29e178451f02"), 6, new Guid("24444444-4444-4444-4444-444444444444"), null, "Cardiology" },
                    { new Guid("3c08352b-35cd-4ec0-9f1f-589b574ef97a"), 7, new Guid("44444444-4444-4444-4444-444444444444"), null, "Psychiatry" },
                    { new Guid("5ad8ad11-bcd4-4fb7-8d1c-1ea7d3b93341"), 11, new Guid("44444444-4444-4444-4444-444444444444"), null, "Radiology" },
                    { new Guid("71b77986-aa73-442a-a25f-a7c523b9465c"), 7, new Guid("44444444-4444-4444-4444-444444444444"), null, "Oncology" },
                    { new Guid("9382e511-8508-453b-b561-10be2b9f580f"), 13, new Guid("44444444-4444-4444-4444-444444444444"), null, "Dermatology" },
                    { new Guid("c986b63d-ac03-4ac8-9382-3c20a88728b6"), 33, new Guid("44444444-4444-4444-4444-444444444444"), null, "Dermatology" },
                    { new Guid("cc6b4cf4-a13b-49fa-83f6-651cc4f8b1c4"), 17, new Guid("44444444-4444-4444-4444-444444444444"), null, "Psychiatry" },
                    { new Guid("cf8ae6cc-ba76-4384-abb7-a94b52f155e7"), 27, new Guid("34444444-4444-4444-4444-444444444444"), null, "Oncology" },
                    { new Guid("d4b7811c-a7ce-4e4b-8734-df0dd7ca3a0e"), 33, new Guid("44444444-4444-4444-4444-444444444444"), null, "Cardiology" },
                    { new Guid("d6d1083b-5584-413f-90ec-39fa45cdc0c0"), 39, new Guid("34444444-4444-4444-4444-444444444444"), null, "Dermatology" },
                    { new Guid("dd40d06c-a281-49ca-bc4d-88041a737ca0"), 37, new Guid("24444444-4444-4444-4444-444444444444"), null, "Ophthalmology" },
                    { new Guid("eee5db30-095e-4d08-9b2f-79e359c591c4"), 31, new Guid("24444444-4444-4444-4444-444444444444"), null, "Neurology" },
                    { new Guid("f095151b-0ad7-4750-a289-0f209021bfe0"), 28, new Guid("44444444-4444-4444-4444-444444444444"), null, "Neurology" },
                    { new Guid("fe29003c-efee-4504-aa95-682d63e4051b"), 17, new Guid("24444444-4444-4444-4444-444444444444"), null, "Radiology" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPatient_doctorsId",
                schema: "Telemetry",
                table: "DoctorPatient",
                column: "doctorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPatient_Doctors_doctorsId",
                schema: "Telemetry",
                table: "DoctorPatient",
                column: "doctorsId",
                principalSchema: "Telemetry",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
