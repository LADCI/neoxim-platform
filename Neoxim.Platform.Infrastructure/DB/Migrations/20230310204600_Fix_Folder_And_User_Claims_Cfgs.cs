using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Neoxim.Platform.Infrastructure.DB.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Folder_And_User_Claims_Cfgs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_folders_in_claims_folders_FolderId",
                schema: "nxm",
                table: "folders_in_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_users_in_claims_users_UserId",
                schema: "nxm",
                table: "users_in_claims");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "nxm",
                table: "users_in_claims",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_users_in_claims_UserId",
                schema: "nxm",
                table: "users_in_claims",
                newName: "IX_users_in_claims_user_id");

            migrationBuilder.RenameColumn(
                name: "FolderId",
                schema: "nxm",
                table: "folders_in_claims",
                newName: "folder_id");

            migrationBuilder.RenameIndex(
                name: "IX_folders_in_claims_FolderId",
                schema: "nxm",
                table: "folders_in_claims",
                newName: "IX_folders_in_claims_folder_id");

            migrationBuilder.AddForeignKey(
                name: "FK_folders_in_claims_folders_folder_id",
                schema: "nxm",
                table: "folders_in_claims",
                column: "folder_id",
                principalSchema: "nxm",
                principalTable: "folders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_in_claims_users_user_id",
                schema: "nxm",
                table: "users_in_claims",
                column: "user_id",
                principalSchema: "nxm",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_folders_in_claims_folders_folder_id",
                schema: "nxm",
                table: "folders_in_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_users_in_claims_users_user_id",
                schema: "nxm",
                table: "users_in_claims");

            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "nxm",
                table: "users_in_claims",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_users_in_claims_user_id",
                schema: "nxm",
                table: "users_in_claims",
                newName: "IX_users_in_claims_UserId");

            migrationBuilder.RenameColumn(
                name: "folder_id",
                schema: "nxm",
                table: "folders_in_claims",
                newName: "FolderId");

            migrationBuilder.RenameIndex(
                name: "IX_folders_in_claims_folder_id",
                schema: "nxm",
                table: "folders_in_claims",
                newName: "IX_folders_in_claims_FolderId");

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
                name: "FK_users_in_claims_users_UserId",
                schema: "nxm",
                table: "users_in_claims",
                column: "UserId",
                principalSchema: "nxm",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
