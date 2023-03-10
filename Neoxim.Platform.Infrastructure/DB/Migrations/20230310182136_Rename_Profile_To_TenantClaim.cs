using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Neoxim.Platform.Infrastructure.DB.Migrations
{
    /// <inheritdoc />
    public partial class Rename_Profile_To_TenantClaim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_document_issues_documents_DocumentId",
                schema: "nxm",
                table: "document_issues");

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                schema: "nxm",
                table: "document_issues",
                newName: "document_id");

            migrationBuilder.RenameIndex(
                name: "IX_document_issues_DocumentId",
                schema: "nxm",
                table: "document_issues",
                newName: "IX_document_issues_document_id");

            migrationBuilder.CreateTable(
                name: "TenantClaim",
                schema: "nxm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastChangesDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantClaim_tenants_tenant_id",
                        column: x => x.tenant_id,
                        principalSchema: "nxm",
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FolderInClaim",
                schema: "nxm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FolderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastChangesDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolderInClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FolderInClaim_TenantClaim_ClaimId",
                        column: x => x.ClaimId,
                        principalSchema: "nxm",
                        principalTable: "TenantClaim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FolderInClaim_folders_FolderId",
                        column: x => x.FolderId,
                        principalSchema: "nxm",
                        principalTable: "folders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInClaim",
                schema: "nxm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastChangesDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInClaim_TenantClaim_ClaimId",
                        column: x => x.ClaimId,
                        principalSchema: "nxm",
                        principalTable: "TenantClaim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInClaim_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "nxm",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FolderInClaim_ClaimId",
                schema: "nxm",
                table: "FolderInClaim",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_FolderInClaim_FolderId",
                schema: "nxm",
                table: "FolderInClaim",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantClaim_tenant_id",
                schema: "nxm",
                table: "TenantClaim",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserInClaim_ClaimId",
                schema: "nxm",
                table: "UserInClaim",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInClaim_UserId",
                schema: "nxm",
                table: "UserInClaim",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_document_issues_documents_document_id",
                schema: "nxm",
                table: "document_issues",
                column: "document_id",
                principalSchema: "nxm",
                principalTable: "documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_document_issues_documents_document_id",
                schema: "nxm",
                table: "document_issues");

            migrationBuilder.DropTable(
                name: "FolderInClaim",
                schema: "nxm");

            migrationBuilder.DropTable(
                name: "UserInClaim",
                schema: "nxm");

            migrationBuilder.DropTable(
                name: "TenantClaim",
                schema: "nxm");

            migrationBuilder.RenameColumn(
                name: "document_id",
                schema: "nxm",
                table: "document_issues",
                newName: "DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_document_issues_document_id",
                schema: "nxm",
                table: "document_issues",
                newName: "IX_document_issues_DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_document_issues_documents_DocumentId",
                schema: "nxm",
                table: "document_issues",
                column: "DocumentId",
                principalSchema: "nxm",
                principalTable: "documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
