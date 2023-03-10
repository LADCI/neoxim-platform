using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Neoxim.Platform.Infrastructure.DB.Migrations
{
    /// <inheritdoc />
    public partial class Add_Tenant_Status_Col : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "status",
                schema: "nxm",
                table: "tenants",
                type: "character varying(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                schema: "nxm",
                table: "tenants");
        }
    }
}
