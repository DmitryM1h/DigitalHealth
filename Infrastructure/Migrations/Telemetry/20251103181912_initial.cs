using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("010ec82e-cbb0-4287-8ae7-b2b3d15ec3bd"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("0538e8aa-a1cc-44ea-a733-298c2a3178df"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("1a223f5f-dfee-4471-992b-7edf285e2efa"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("21d99907-299a-4199-b683-8c27e7919d07"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("279c8e2c-3b46-4034-8b97-e9d1b93d05bc"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("30f99b5a-c21a-4d58-9d9a-fb458f63b68e"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("428c03d6-1ded-4d62-a279-5d28591b5634"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("4ef99f3c-6f37-4b6d-b704-620cf6b460c4"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("509c7f59-e199-4325-bd4a-2990d3118deb"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("591e08d0-7117-4154-819e-297d1b597462"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("a038faff-7234-4101-baa4-186025dc1972"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("aeddd81c-688a-4481-816c-a6983475ba45"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("b3304078-16d7-416f-806f-5b6e7197e56e"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("b6cc452d-5711-47fd-aee5-a5483df8d31f"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("bcd069af-9a79-4f17-8240-7e8414c23616"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("c064aed7-b71a-4af2-a092-05f2a7d1f717"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("c1286101-66b8-4717-a97e-232584623f62"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("ce367d1b-affe-4b98-a1a9-9fe93629dfe7"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("d808433a-ee98-4bed-9c8c-e2bfb628aed1"));

            migrationBuilder.DeleteData(
                schema: "Telemetry",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("e1b0282d-fb1d-4add-83fa-182663c2f02f"));

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

            migrationBuilder.CreateIndex(
                name: "IX_CalendarBlocks_DoctorId",
                schema: "Telemetry",
                table: "CalendarBlocks",
                column: "DoctorId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendarBlocks",
                schema: "Telemetry");

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
        }
    }
}
