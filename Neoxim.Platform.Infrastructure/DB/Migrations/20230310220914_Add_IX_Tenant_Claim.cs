using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Neoxim.Platform.Infrastructure.DB.Migrations
{
    /// <inheritdoc />
    public partial class Add_IX_Tenant_Claim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tenant_claims_tenants_tenant_id",
                schema: "nxm",
                table: "tenant_claims");

            migrationBuilder.DropIndex(
                name: "IX_tenant_claims_name",
                schema: "nxm",
                table: "tenant_claims");

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

            migrationBuilder.CreateIndex(
                name: "IX_tenant_claims_name_tenant_id",
                schema: "nxm",
                table: "tenant_claims",
                columns: new[] { "name", "TenantId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "tenant_id",
                schema: "nxm",
                table: "tenant_claims",
                column: "TenantId",
                principalSchema: "nxm",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "tenant_id",
                schema: "nxm",
                table: "tenant_claims");

            migrationBuilder.DropIndex(
                name: "IX_tenant_claims_name_tenant_id",
                schema: "nxm",
                table: "tenant_claims");

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

            migrationBuilder.CreateIndex(
                name: "IX_tenant_claims_name",
                schema: "nxm",
                table: "tenant_claims",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tenant_claims_tenants_tenant_id",
                schema: "nxm",
                table: "tenant_claims",
                column: "tenant_id",
                principalSchema: "nxm",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
