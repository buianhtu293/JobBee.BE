using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBee.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update_job_alert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "job_alerts_job_category_id_fkey",
                table: "job_alerts");

            migrationBuilder.DropForeignKey(
                name: "job_alerts_job_type_id_fkey",
                table: "job_alerts");

            migrationBuilder.DropIndex(
                name: "IX_job_alerts_job_category_id",
                table: "job_alerts");

            migrationBuilder.DropColumn(
                name: "frequency",
                table: "job_alerts");

            migrationBuilder.DropColumn(
                name: "job_category_id",
                table: "job_alerts");

            migrationBuilder.DropColumn(
                name: "keywords",
                table: "job_alerts");

            migrationBuilder.DropColumn(
                name: "location",
                table: "job_alerts");

            migrationBuilder.DropColumn(
                name: "min_salary",
                table: "job_alerts");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "job_alerts");

            migrationBuilder.RenameColumn(
                name: "job_type_id",
                table: "job_alerts",
                newName: "job_id");

            migrationBuilder.RenameIndex(
                name: "IX_job_alerts_job_type_id",
                table: "job_alerts",
                newName: "IX_job_alerts_job_id");

			migrationBuilder.DropColumn(
name: "related_entity_id",
table: "notifications");

			migrationBuilder.AddColumn<Guid>(
				name: "related_entity_id",
				table: "notifications",
				type: "uuid",
				nullable: true);

			migrationBuilder.AddForeignKey(
                name: "FK_job_alerts_jobs_job_id",
                table: "job_alerts",
                column: "job_id",
                principalTable: "jobs",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_job_alerts_jobs_job_id",
                table: "job_alerts");

            migrationBuilder.RenameColumn(
                name: "job_id",
                table: "job_alerts",
                newName: "job_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_job_alerts_job_id",
                table: "job_alerts",
                newName: "IX_job_alerts_job_type_id");

            

            migrationBuilder.AddColumn<string>(
                name: "frequency",
                table: "job_alerts",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "job_category_id",
                table: "job_alerts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "keywords",
                table: "job_alerts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "job_alerts",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "min_salary",
                table: "job_alerts",
                type: "numeric(12,2)",
                precision: 12,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "job_alerts",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_job_alerts_job_category_id",
                table: "job_alerts",
                column: "job_category_id");

            migrationBuilder.AddForeignKey(
                name: "job_alerts_job_category_id_fkey",
                table: "job_alerts",
                column: "job_category_id",
                principalTable: "job_categories",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "job_alerts_job_type_id_fkey",
                table: "job_alerts",
                column: "job_type_id",
                principalTable: "job_types",
                principalColumn: "id");
        }
    }
}
