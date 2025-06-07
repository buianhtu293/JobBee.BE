using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBee.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Migrate_Type : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DropColumn(
	        name: "related_entity_id",
	        table: "notifications");

			migrationBuilder.AddColumn<Guid>(
				name: "related_entity_id",
				table: "notifications",
				type: "uuid",
				nullable: true);
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
