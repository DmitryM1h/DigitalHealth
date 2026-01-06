using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalHealth.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class doctorWrokSchkedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_WorkSchedules_Id",
                schema: "Telemetry",
                table: "Doctors");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkScheduleId",
                schema: "Telemetry",
                table: "Doctors",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_WorkScheduleId",
                schema: "Telemetry",
                table: "Doctors",
                column: "WorkScheduleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_WorkSchedules_WorkScheduleId",
                schema: "Telemetry",
                table: "Doctors",
                column: "WorkScheduleId",
                principalSchema: "Telemetry",
                principalTable: "WorkSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_WorkSchedules_WorkScheduleId",
                schema: "Telemetry",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_WorkScheduleId",
                schema: "Telemetry",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "WorkScheduleId",
                schema: "Telemetry",
                table: "Doctors");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_WorkSchedules_Id",
                schema: "Telemetry",
                table: "Doctors",
                column: "Id",
                principalSchema: "Telemetry",
                principalTable: "WorkSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
