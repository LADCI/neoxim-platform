using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Neoxim.Platform.Infrastructure.DB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "nxm");

            migrationBuilder.CreateTable(
                name: "tenants",
                schema: "nxm",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    contact_email = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    contact_phone = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    contact_address = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    creation_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_changes_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "folders",
                schema: "nxm",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    parent_id = table.Column<Guid>(type: "uuid", nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    creation_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_changes_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_folders", x => x.id);
                    table.ForeignKey(
                        name: "FK_folders_folders_parent_id",
                        column: x => x.parent_id,
                        principalSchema: "nxm",
                        principalTable: "folders",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_folders_tenants_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "nxm",
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                schema: "nxm",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    construction_type = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    contract_type = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    amount_value = table.Column<decimal>(type: "numeric", nullable: false),
                    amount_currency = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    start_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    customer = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    creation_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_changes_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.id);
                    table.ForeignKey(
                        name: "FK_projects_tenants_tenant_id",
                        column: x => x.tenant_id,
                        principalSchema: "nxm",
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subscriptions",
                schema: "nxm",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount_value = table.Column<decimal>(type: "numeric", nullable: false),
                    amount_currency = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    creation_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_changes_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscriptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_subscriptions_tenants_tenant_id",
                        column: x => x.tenant_id,
                        principalSchema: "nxm",
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "nxm",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    last_name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    gender = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    contact_email = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    contact_phone = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    contact_address = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    creation_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_changes_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_tenants_tenant_id",
                        column: x => x.tenant_id,
                        principalSchema: "nxm",
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "documents",
                schema: "nxm",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    url = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    project_id = table.Column<Guid>(type: "uuid", nullable: false),
                    folder_id = table.Column<Guid>(type: "uuid", nullable: false),
                    creation_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_changes_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documents", x => x.id);
                    table.ForeignKey(
                        name: "FK_documents_folders_folder_id",
                        column: x => x.folder_id,
                        principalSchema: "nxm",
                        principalTable: "folders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_documents_projects_project_id",
                        column: x => x.project_id,
                        principalSchema: "nxm",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_documents_tenants_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "nxm",
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "document_issues",
                schema: "nxm",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    snapshot = table.Column<byte[]>(type: "bytea", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uuid", nullable: false),
                    creation_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_changes_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_document_issues", x => x.id);
                    table.ForeignKey(
                        name: "FK_document_issues_documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "nxm",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "document_issue_comments",
                schema: "nxm",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    issue_id = table.Column<Guid>(type: "uuid", nullable: false),
                    author_id = table.Column<Guid>(type: "uuid", nullable: false),
                    creation_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_changes_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_document_issue_comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_document_issue_comments_document_issues_issue_id",
                        column: x => x.issue_id,
                        principalSchema: "nxm",
                        principalTable: "document_issues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_document_issue_comments_author_id",
                schema: "nxm",
                table: "document_issue_comments",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_document_issue_comments_issue_id",
                schema: "nxm",
                table: "document_issue_comments",
                column: "issue_id");

            migrationBuilder.CreateIndex(
                name: "IX_document_issues_DocumentId",
                schema: "nxm",
                table: "document_issues",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_document_issues_name",
                schema: "nxm",
                table: "document_issues",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_documents_folder_id",
                schema: "nxm",
                table: "documents",
                column: "folder_id");

            migrationBuilder.CreateIndex(
                name: "IX_documents_name",
                schema: "nxm",
                table: "documents",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_documents_project_id",
                schema: "nxm",
                table: "documents",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_documents_TenantId",
                schema: "nxm",
                table: "documents",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_folders_name",
                schema: "nxm",
                table: "folders",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_folders_parent_id",
                schema: "nxm",
                table: "folders",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_folders_TenantId",
                schema: "nxm",
                table: "folders",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_projects_name",
                schema: "nxm",
                table: "projects",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_projects_tenant_id",
                schema: "nxm",
                table: "projects",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "IX_subscriptions_tenant_id",
                schema: "nxm",
                table: "subscriptions",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "IX_tenants_name",
                schema: "nxm",
                table: "tenants",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_tenant_id",
                schema: "nxm",
                table: "users",
                column: "tenant_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "document_issue_comments",
                schema: "nxm");

            migrationBuilder.DropTable(
                name: "subscriptions",
                schema: "nxm");

            migrationBuilder.DropTable(
                name: "users",
                schema: "nxm");

            migrationBuilder.DropTable(
                name: "document_issues",
                schema: "nxm");

            migrationBuilder.DropTable(
                name: "documents",
                schema: "nxm");

            migrationBuilder.DropTable(
                name: "folders",
                schema: "nxm");

            migrationBuilder.DropTable(
                name: "projects",
                schema: "nxm");

            migrationBuilder.DropTable(
                name: "tenants",
                schema: "nxm");
        }
    }
}
