using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class onemore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("14ee900c-6acf-4d0b-aba7-d98d653298e2"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("2c9de460-1ee7-47ab-a2b3-111c7ca98eb9"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("3de53f89-d105-4e92-88fc-b74796d87d69"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("42910855-db56-4dc3-b51e-008a1b6ae996"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("49297f67-a9c0-4930-be77-2eab416f9801"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("59d9131a-fe41-4d59-8088-eff820669fa8"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("6c213066-a237-42a5-950d-40a3b1df63c4"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("6cd46b07-66bf-40c2-bc16-9e304850e0f0"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("6db0b6ea-a19a-4afa-a6d7-d0e3254eb4d3"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("8ae061d2-900f-40c2-aa39-6f5aa551b8f6"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("926f1199-f03f-4c37-80e0-107c85cd6dc6"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("93916634-e8c1-4213-9723-e467219c7526"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("962d1ac1-cd78-43d0-8488-e2524b5e95b3"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("96ee3955-d26d-47c1-8928-7d6665471476"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("b34aea93-1eab-40d3-9720-3557dce1bb00"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("b41d12cb-12d9-4945-9dd4-cc01e4787c86"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("ba9a4f2b-b565-40fa-aa6c-0dce757fe792"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("c41c740f-b8a3-40ee-802d-fc43825b79ac"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("ece7fc37-e147-4db8-a2e5-f1efc91b5865"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("f808d8aa-29aa-40f6-9daa-ee72a2a99f33"));

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                schema: "Telemetry",
                table: "Doctors",
                columns: new[] { "Id", "Capacity", "ClinicId", "DoctorInfoId", "Specialty" },
                values: new object[,]
                {
                    { new Guid("14ee900c-6acf-4d0b-aba7-d98d653298e2"), 28, new Guid("44444444-4444-4444-4444-444444444444"), null, "Orthopedics" },
                    { new Guid("2c9de460-1ee7-47ab-a2b3-111c7ca98eb9"), 6, new Guid("44444444-4444-4444-4444-444444444444"), null, "Pediatrics" },
                    { new Guid("3de53f89-d105-4e92-88fc-b74796d87d69"), 32, new Guid("44444444-4444-4444-4444-444444444444"), null, "Dermatology" },
                    { new Guid("42910855-db56-4dc3-b51e-008a1b6ae996"), 36, new Guid("34444444-4444-4444-4444-444444444444"), null, "Oncology" },
                    { new Guid("49297f67-a9c0-4930-be77-2eab416f9801"), 31, new Guid("44444444-4444-4444-4444-444444444444"), null, "Radiology" },
                    { new Guid("59d9131a-fe41-4d59-8088-eff820669fa8"), 26, new Guid("24444444-4444-4444-4444-444444444444"), null, "Pediatrics" },
                    { new Guid("6c213066-a237-42a5-950d-40a3b1df63c4"), 21, new Guid("24444444-4444-4444-4444-444444444444"), null, "Ophthalmology" },
                    { new Guid("6cd46b07-66bf-40c2-bc16-9e304850e0f0"), 9, new Guid("44444444-4444-4444-4444-444444444444"), null, "Pediatrics" },
                    { new Guid("6db0b6ea-a19a-4afa-a6d7-d0e3254eb4d3"), 6, new Guid("24444444-4444-4444-4444-444444444444"), null, "Ophthalmology" },
                    { new Guid("8ae061d2-900f-40c2-aa39-6f5aa551b8f6"), 10, new Guid("44444444-4444-4444-4444-444444444444"), null, "Pediatrics" },
                    { new Guid("926f1199-f03f-4c37-80e0-107c85cd6dc6"), 35, new Guid("24444444-4444-4444-4444-444444444444"), null, "Oncology" },
                    { new Guid("93916634-e8c1-4213-9723-e467219c7526"), 23, new Guid("24444444-4444-4444-4444-444444444444"), null, "Orthopedics" },
                    { new Guid("962d1ac1-cd78-43d0-8488-e2524b5e95b3"), 8, new Guid("44444444-4444-4444-4444-444444444444"), null, "Radiology" },
                    { new Guid("96ee3955-d26d-47c1-8928-7d6665471476"), 8, new Guid("44444444-4444-4444-4444-444444444444"), null, "Dermatology" },
                    { new Guid("b34aea93-1eab-40d3-9720-3557dce1bb00"), 6, new Guid("44444444-4444-4444-4444-444444444444"), null, "Oncology" },
                    { new Guid("b41d12cb-12d9-4945-9dd4-cc01e4787c86"), 39, new Guid("24444444-4444-4444-4444-444444444444"), null, "Ophthalmology" },
                    { new Guid("ba9a4f2b-b565-40fa-aa6c-0dce757fe792"), 33, new Guid("34444444-4444-4444-4444-444444444444"), null, "Radiology" },
                    { new Guid("c41c740f-b8a3-40ee-802d-fc43825b79ac"), 12, new Guid("44444444-4444-4444-4444-444444444444"), null, "Radiology" },
                    { new Guid("ece7fc37-e147-4db8-a2e5-f1efc91b5865"), 22, new Guid("24444444-4444-4444-4444-444444444444"), null, "Surgery" },
                    { new Guid("f808d8aa-29aa-40f6-9daa-ee72a2a99f33"), 17, new Guid("44444444-4444-4444-4444-444444444444"), null, "Oncology" }
                });
        }
    }
}
