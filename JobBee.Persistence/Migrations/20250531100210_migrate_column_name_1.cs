using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBee.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migrate_column_name_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "jobs",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Responsibilities",
                table: "jobs",
                newName: "responsibilities");

            migrationBuilder.RenameColumn(
                name: "Requirements",
                table: "jobs",
                newName: "requirements");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "jobs",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "jobs",
                newName: "currency");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "job_applications",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "job_alerts",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "Keywords",
                table: "job_alerts",
                newName: "keywords");

            migrationBuilder.RenameColumn(
                name: "Frequency",
                table: "job_alerts",
                newName: "frequency");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "jobs",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "responsibilities",
                table: "jobs",
                newName: "Responsibilities");

            migrationBuilder.RenameColumn(
                name: "requirements",
                table: "jobs",
                newName: "Requirements");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "jobs",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "currency",
                table: "jobs",
                newName: "Currency");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "job_applications",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "job_alerts",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "keywords",
                table: "job_alerts",
                newName: "Keywords");

            migrationBuilder.RenameColumn(
                name: "frequency",
                table: "job_alerts",
                newName: "Frequency");
        }
    }
}
