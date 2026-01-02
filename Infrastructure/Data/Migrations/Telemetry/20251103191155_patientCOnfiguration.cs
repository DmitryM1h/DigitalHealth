using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class patientCOnfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_MedicalRecords_MedicalRecordId",
                schema: "Telemetry",
                table: "Patients");

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("0fd4ac44-475a-40a6-be28-2428dc34dad2"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("121fa33d-5346-4be0-96c3-17f9a2a8dba4"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("176424da-7b51-42b7-83d8-a5bc27b50115"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("273f2b49-1139-49b9-961b-f9c7e1a1c42e"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("29de7f3a-a9c8-4c82-a70b-f096dcfc10f3"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("36350ca8-7a67-4cbe-bf09-ecd7ae6a4fe1"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("3be5f0b8-ca6a-4273-80a5-3524051a336f"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("55cd9f5a-3d91-4e6a-879a-a1a82e3ed957"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("659b8ae3-84d1-4c2c-93eb-bfd2779953e3"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("6b0d8f83-ae22-4210-89f4-b2a7749423fb"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("6def89c2-3fb8-4672-ad36-9c9d48db5f4b"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("7c30f1f2-98d5-4208-92ff-3cbb436b78ec"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("7de3617e-6a01-46ba-a16e-e474d3cf9cc8"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("89448b26-e257-48a9-a7c5-a38b489a2675"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("94f06519-ddea-4a8f-830f-5236f164e8a1"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("a27723f7-67e6-4ac1-abcb-dc2ef98e4803"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("b85b4049-c010-41d6-b3d3-f81994b72246"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("d76151b9-8f33-4bf9-a996-028431b8867a"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("f859601d-63a9-4521-9164-cabcefcfcd73"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("f8f35928-3eec-4a5e-b0b7-abef7bdde488"));

            migrationBuilder.AlterColumn<Guid>(
                name: "MedicalRecordId",
                schema: "Telemetry",
                table: "Patients",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_MedicalRecords_MedicalRecordId",
                schema: "Telemetry",
                table: "Patients",
                column: "MedicalRecordId",
                principalSchema: "Telemetry",
                principalTable: "MedicalRecords",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_MedicalRecords_MedicalRecordId",
                schema: "Telemetry",
                table: "Patients");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "MedicalRecordId",
                schema: "Telemetry",
                table: "Patients",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "Telemetry",
                table: "Doctors",
                columns: new[] { "Id", "Capacity", "ClinicId", "DoctorInfoId", "Specialty" },
                values: new object[,]
                {
                    { new Guid("0fd4ac44-475a-40a6-be28-2428dc34dad2"), 39, new Guid("44444444-4444-4444-4444-444444444444"), null, "Neurology" },
                    { new Guid("121fa33d-5346-4be0-96c3-17f9a2a8dba4"), 26, new Guid("44444444-4444-4444-4444-444444444444"), null, "Cardiology" },
                    { new Guid("176424da-7b51-42b7-83d8-a5bc27b50115"), 24, new Guid("24444444-4444-4444-4444-444444444444"), null, "Neurology" },
                    { new Guid("273f2b49-1139-49b9-961b-f9c7e1a1c42e"), 13, new Guid("34444444-4444-4444-4444-444444444444"), null, "Psychiatry" },
                    { new Guid("29de7f3a-a9c8-4c82-a70b-f096dcfc10f3"), 22, new Guid("44444444-4444-4444-4444-444444444444"), null, "Surgery" },
                    { new Guid("36350ca8-7a67-4cbe-bf09-ecd7ae6a4fe1"), 18, new Guid("34444444-4444-4444-4444-444444444444"), null, "Neurology" },
                    { new Guid("3be5f0b8-ca6a-4273-80a5-3524051a336f"), 22, new Guid("34444444-4444-4444-4444-444444444444"), null, "Oncology" },
                    { new Guid("55cd9f5a-3d91-4e6a-879a-a1a82e3ed957"), 25, new Guid("24444444-4444-4444-4444-444444444444"), null, "Oncology" },
                    { new Guid("659b8ae3-84d1-4c2c-93eb-bfd2779953e3"), 31, new Guid("24444444-4444-4444-4444-444444444444"), null, "Ophthalmology" },
                    { new Guid("6b0d8f83-ae22-4210-89f4-b2a7749423fb"), 37, new Guid("34444444-4444-4444-4444-444444444444"), null, "Ophthalmology" },
                    { new Guid("6def89c2-3fb8-4672-ad36-9c9d48db5f4b"), 15, new Guid("34444444-4444-4444-4444-444444444444"), null, "Psychiatry" },
                    { new Guid("7c30f1f2-98d5-4208-92ff-3cbb436b78ec"), 24, new Guid("34444444-4444-4444-4444-444444444444"), null, "Surgery" },
                    { new Guid("7de3617e-6a01-46ba-a16e-e474d3cf9cc8"), 17, new Guid("24444444-4444-4444-4444-444444444444"), null, "Ophthalmology" },
                    { new Guid("89448b26-e257-48a9-a7c5-a38b489a2675"), 26, new Guid("44444444-4444-4444-4444-444444444444"), null, "Cardiology" },
                    { new Guid("94f06519-ddea-4a8f-830f-5236f164e8a1"), 10, new Guid("24444444-4444-4444-4444-444444444444"), null, "Cardiology" },
                    { new Guid("a27723f7-67e6-4ac1-abcb-dc2ef98e4803"), 22, new Guid("44444444-4444-4444-4444-444444444444"), null, "Neurology" },
                    { new Guid("b85b4049-c010-41d6-b3d3-f81994b72246"), 20, new Guid("44444444-4444-4444-4444-444444444444"), null, "Neurology" },
                    { new Guid("d76151b9-8f33-4bf9-a996-028431b8867a"), 35, new Guid("24444444-4444-4444-4444-444444444444"), null, "Pediatrics" },
                    { new Guid("f859601d-63a9-4521-9164-cabcefcfcd73"), 12, new Guid("44444444-4444-4444-4444-444444444444"), null, "Surgery" },
                    { new Guid("f8f35928-3eec-4a5e-b0b7-abef7bdde488"), 16, new Guid("24444444-4444-4444-4444-444444444444"), null, "Oncology" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_MedicalRecords_MedicalRecordId",
                schema: "Telemetry",
                table: "Patients",
                column: "MedicalRecordId",
                principalSchema: "Telemetry",
                principalTable: "MedicalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
