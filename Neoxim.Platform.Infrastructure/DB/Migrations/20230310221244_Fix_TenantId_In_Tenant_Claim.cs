using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Neoxim.Platform.Infrastructure.DB.Migrations
{
    /// <inheritdoc />
    public partial class Fix_TenantId_In_Tenant_Claim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TenantId",
                schema: "nxm",
                table: "tenant_claims",
                newName: "tenant_id");

            migrationBuilder.RenameIndex(
                name: "IX_tenant_claims_TenantId",
                schema: "nxm",
                table: "tenant_claims",
                newName: "IX_tenant_claims_tenant_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tenant_id",
                schema: "nxm",
                table: "tenant_claims",
                newName: "TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_tenant_claims_tenant_id",
                schema: "nxm",
                table: "tenant_claims",
                newName: "IX_tenant_claims_TenantId");
        }
    }
}
