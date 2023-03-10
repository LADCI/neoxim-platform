using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Neoxim.Platform.Infrastructure.DB.Migrations
{
    /// <inheritdoc />
    public partial class Fix_DB_Cfgs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_documents_tenants_TenantId",
                schema: "nxm",
                table: "documents");

            migrationBuilder.DropForeignKey(
                name: "FK_FolderInClaim_TenantClaim_ClaimId",
                schema: "nxm",
                table: "FolderInClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_FolderInClaim_folders_FolderId",
                schema: "nxm",
                table: "FolderInClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_folders_tenants_TenantId",
                schema: "nxm",
                table: "folders");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantClaim_tenants_tenant_id",
                schema: "nxm",
                table: "TenantClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInClaim_TenantClaim_ClaimId",
                schema: "nxm",
                table: "UserInClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInClaim_users_UserId",
                schema: "nxm",
                table: "UserInClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInClaim",
                schema: "nxm",
                table: "UserInClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TenantClaim",
                schema: "nxm",
                table: "TenantClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FolderInClaim",
                schema: "nxm",
                table: "FolderInClaim");

            migrationBuilder.RenameTable(
                name: "UserInClaim",
                schema: "nxm",
                newName: "users_in_claims",
                newSchema: "nxm");

            migrationBuilder.RenameTable(
                name: "TenantClaim",
                schema: "nxm",
                newName: "tenant_claims",
                newSchema: "nxm");

            migrationBuilder.RenameTable(
                name: "FolderInClaim",
                schema: "nxm",
                newName: "folders_in_claims",
                newSchema: "nxm");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                schema: "nxm",
                table: "subscriptions",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                schema: "nxm",
                table: "folders",
                newName: "tenant_id");

            migrationBuilder.RenameIndex(
                name: "IX_folders_TenantId",
                schema: "nxm",
                table: "folders",
                newName: "IX_folders_tenant_id");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                schema: "nxm",
                table: "documents",
                newName: "tenant_id");

            migrationBuilder.RenameIndex(
                name: "IX_documents_TenantId",
                schema: "nxm",
                table: "documents",
                newName: "IX_documents_tenant_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "nxm",
                table: "users_in_claims",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LastChangesDate",
                schema: "nxm",
                table: "users_in_claims",
                newName: "last_changes_date");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                schema: "nxm",
                table: "users_in_claims",
                newName: "creation_date");

            migrationBuilder.RenameColumn(
                name: "ClaimId",
                schema: "nxm",
                table: "users_in_claims",
                newName: "claim_id");

            migrationBuilder.RenameIndex(
                name: "IX_UserInClaim_UserId",
                schema: "nxm",
                table: "users_in_claims",
                newName: "IX_users_in_claims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserInClaim_ClaimId",
                schema: "nxm",
                table: "users_in_claims",
                newName: "IX_users_in_claims_claim_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "nxm",
                table: "tenant_claims",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "nxm",
                table: "tenant_claims",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "nxm",
                table: "tenant_claims",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LastChangesDate",
                schema: "nxm",
                table: "tenant_claims",
                newName: "last_changes_date");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                schema: "nxm",
                table: "tenant_claims",
                newName: "creation_date");

            migrationBuilder.RenameIndex(
                name: "IX_TenantClaim_tenant_id",
                schema: "nxm",
                table: "tenant_claims",
                newName: "IX_tenant_claims_tenant_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "nxm",
                table: "folders_in_claims",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LastChangesDate",
                schema: "nxm",
                table: "folders_in_claims",
                newName: "last_changes_date");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                schema: "nxm",
                table: "folders_in_claims",
                newName: "creation_date");

            migrationBuilder.RenameColumn(
                name: "ClaimId",
                schema: "nxm",
                table: "folders_in_claims",
                newName: "claim_id");

            migrationBuilder.RenameIndex(
                name: "IX_FolderInClaim_FolderId",
                schema: "nxm",
                table: "folders_in_claims",
                newName: "IX_folders_in_claims_FolderId");

            migrationBuilder.RenameIndex(
                name: "IX_FolderInClaim_ClaimId",
                schema: "nxm",
                table: "folders_in_claims",
                newName: "IX_folders_in_claims_claim_id");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "nxm",
                table: "tenant_claims",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users_in_claims",
                schema: "nxm",
                table: "users_in_claims",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tenant_claims",
                schema: "nxm",
                table: "tenant_claims",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_folders_in_claims",
                schema: "nxm",
                table: "folders_in_claims",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_tenant_claims_name",
                schema: "nxm",
                table: "tenant_claims",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_documents_tenants_tenant_id",
                schema: "nxm",
                table: "documents",
                column: "tenant_id",
                principalSchema: "nxm",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_folders_tenants_tenant_id",
                schema: "nxm",
                table: "folders",
                column: "tenant_id",
                principalSchema: "nxm",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_folders_in_claims_folders_FolderId",
                schema: "nxm",
                table: "folders_in_claims",
                column: "FolderId",
                principalSchema: "nxm",
                principalTable: "folders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_folders_in_claims_tenant_claims_claim_id",
                schema: "nxm",
                table: "folders_in_claims",
                column: "claim_id",
                principalSchema: "nxm",
                principalTable: "tenant_claims",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tenant_claims_tenants_tenant_id",
                schema: "nxm",
                table: "tenant_claims",
                column: "tenant_id",
                principalSchema: "nxm",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_in_claims_tenant_claims_claim_id",
                schema: "nxm",
                table: "users_in_claims",
                column: "claim_id",
                principalSchema: "nxm",
                principalTable: "tenant_claims",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_in_claims_users_UserId",
                schema: "nxm",
                table: "users_in_claims",
                column: "UserId",
                principalSchema: "nxm",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_documents_tenants_tenant_id",
                schema: "nxm",
                table: "documents");

            migrationBuilder.DropForeignKey(
                name: "FK_folders_tenants_tenant_id",
                schema: "nxm",
                table: "folders");

            migrationBuilder.DropForeignKey(
                name: "FK_folders_in_claims_folders_FolderId",
                schema: "nxm",
                table: "folders_in_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_folders_in_claims_tenant_claims_claim_id",
                schema: "nxm",
                table: "folders_in_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_tenant_claims_tenants_tenant_id",
                schema: "nxm",
                table: "tenant_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_users_in_claims_tenant_claims_claim_id",
                schema: "nxm",
                table: "users_in_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_users_in_claims_users_UserId",
                schema: "nxm",
                table: "users_in_claims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users_in_claims",
                schema: "nxm",
                table: "users_in_claims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tenant_claims",
                schema: "nxm",
                table: "tenant_claims");

            migrationBuilder.DropIndex(
                name: "IX_tenant_claims_name",
                schema: "nxm",
                table: "tenant_claims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_folders_in_claims",
                schema: "nxm",
                table: "folders_in_claims");

            migrationBuilder.RenameTable(
                name: "users_in_claims",
                schema: "nxm",
                newName: "UserInClaim",
                newSchema: "nxm");

            migrationBuilder.RenameTable(
                name: "tenant_claims",
                schema: "nxm",
                newName: "TenantClaim",
                newSchema: "nxm");

            migrationBuilder.RenameTable(
                name: "folders_in_claims",
                schema: "nxm",
                newName: "FolderInClaim",
                newSchema: "nxm");

            migrationBuilder.RenameColumn(
                name: "start_date",
                schema: "nxm",
                table: "subscriptions",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "tenant_id",
                schema: "nxm",
                table: "folders",
                newName: "TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_folders_tenant_id",
                schema: "nxm",
                table: "folders",
                newName: "IX_folders_TenantId");

            migrationBuilder.RenameColumn(
                name: "tenant_id",
                schema: "nxm",
                table: "documents",
                newName: "TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_documents_tenant_id",
                schema: "nxm",
                table: "documents",
                newName: "IX_documents_TenantId");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "nxm",
                table: "UserInClaim",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "last_changes_date",
                schema: "nxm",
                table: "UserInClaim",
                newName: "LastChangesDate");

            migrationBuilder.RenameColumn(
                name: "creation_date",
                schema: "nxm",
                table: "UserInClaim",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "claim_id",
                schema: "nxm",
                table: "UserInClaim",
                newName: "ClaimId");

            migrationBuilder.RenameIndex(
                name: "IX_users_in_claims_UserId",
                schema: "nxm",
                table: "UserInClaim",
                newName: "IX_UserInClaim_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_users_in_claims_claim_id",
                schema: "nxm",
                table: "UserInClaim",
                newName: "IX_UserInClaim_ClaimId");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "nxm",
                table: "TenantClaim",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "nxm",
                table: "TenantClaim",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "nxm",
                table: "TenantClaim",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "last_changes_date",
                schema: "nxm",
                table: "TenantClaim",
                newName: "LastChangesDate");

            migrationBuilder.RenameColumn(
                name: "creation_date",
                schema: "nxm",
                table: "TenantClaim",
                newName: "CreationDate");

            migrationBuilder.RenameIndex(
                name: "IX_tenant_claims_tenant_id",
                schema: "nxm",
                table: "TenantClaim",
                newName: "IX_TenantClaim_tenant_id");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "nxm",
                table: "FolderInClaim",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "last_changes_date",
                schema: "nxm",
                table: "FolderInClaim",
                newName: "LastChangesDate");

            migrationBuilder.RenameColumn(
                name: "creation_date",
                schema: "nxm",
                table: "FolderInClaim",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "claim_id",
                schema: "nxm",
                table: "FolderInClaim",
                newName: "ClaimId");

            migrationBuilder.RenameIndex(
                name: "IX_folders_in_claims_FolderId",
                schema: "nxm",
                table: "FolderInClaim",
                newName: "IX_FolderInClaim_FolderId");

            migrationBuilder.RenameIndex(
                name: "IX_folders_in_claims_claim_id",
                schema: "nxm",
                table: "FolderInClaim",
                newName: "IX_FolderInClaim_ClaimId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "nxm",
                table: "TenantClaim",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInClaim",
                schema: "nxm",
                table: "UserInClaim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TenantClaim",
                schema: "nxm",
                table: "TenantClaim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FolderInClaim",
                schema: "nxm",
                table: "FolderInClaim",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_documents_tenants_TenantId",
                schema: "nxm",
                table: "documents",
                column: "TenantId",
                principalSchema: "nxm",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FolderInClaim_TenantClaim_ClaimId",
                schema: "nxm",
                table: "FolderInClaim",
                column: "ClaimId",
                principalSchema: "nxm",
                principalTable: "TenantClaim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FolderInClaim_folders_FolderId",
                schema: "nxm",
                table: "FolderInClaim",
                column: "FolderId",
                principalSchema: "nxm",
                principalTable: "folders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_folders_tenants_TenantId",
                schema: "nxm",
                table: "folders",
                column: "TenantId",
                principalSchema: "nxm",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TenantClaim_tenants_tenant_id",
                schema: "nxm",
                table: "TenantClaim",
                column: "tenant_id",
                principalSchema: "nxm",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInClaim_TenantClaim_ClaimId",
                schema: "nxm",
                table: "UserInClaim",
                column: "ClaimId",
                principalSchema: "nxm",
                principalTable: "TenantClaim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInClaim_users_UserId",
                schema: "nxm",
                table: "UserInClaim",
                column: "UserId",
                principalSchema: "nxm",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
