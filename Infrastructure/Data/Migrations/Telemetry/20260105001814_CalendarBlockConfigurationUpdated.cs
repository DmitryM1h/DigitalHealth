using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CalendarBlockConfigurationUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CalendarBlocks_DoctorId",
                schema: "Telemetry",
                table: "CalendarBlocks");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarBlocks_DoctorId",
                schema: "Telemetry",
                table: "CalendarBlocks",
                column: "DoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CalendarBlocks_DoctorId",
                schema: "Telemetry",
                table: "CalendarBlocks");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarBlocks_DoctorId",
                schema: "Telemetry",
                table: "CalendarBlocks",
                column: "DoctorId",
                unique: true);
        }
    }
}
