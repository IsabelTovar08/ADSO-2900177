using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class esquemas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleFormPermissions_Forms_FormId",
                table: "RoleFormPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleFormPermissions_Permissions_PermissionId",
                table: "RoleFormPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleFormPermissions_Role_RolId",
                table: "RoleFormPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Role_RolId",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleFormPermissions",
                table: "RoleFormPermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.EnsureSchema(
                name: "ModelSecurity");

            migrationBuilder.RenameTable(
                name: "Permissions",
                newName: "Permissions",
                newSchema: "ModelSecurity");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "People",
                newSchema: "ModelSecurity");

            migrationBuilder.RenameTable(
                name: "Modules",
                newName: "Modules",
                newSchema: "ModelSecurity");

            migrationBuilder.RenameTable(
                name: "ModuleForms",
                newName: "ModuleForms",
                newSchema: "ModelSecurity");

            migrationBuilder.RenameTable(
                name: "Forms",
                newName: "Forms",
                newSchema: "ModelSecurity");

            migrationBuilder.RenameTable(
                name: "RoleFormPermissions",
                newName: "RolFormPermissions",
                newSchema: "ModelSecurity");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles",
                newSchema: "ModelSecurity");

            migrationBuilder.RenameIndex(
                name: "IX_RoleFormPermissions_RolId",
                schema: "ModelSecurity",
                table: "RolFormPermissions",
                newName: "IX_RolFormPermissions_RolId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleFormPermissions_PermissionId",
                schema: "ModelSecurity",
                table: "RolFormPermissions",
                newName: "IX_RolFormPermissions_PermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleFormPermissions_FormId",
                schema: "ModelSecurity",
                table: "RolFormPermissions",
                newName: "IX_RolFormPermissions_FormId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolFormPermissions",
                schema: "ModelSecurity",
                table: "RolFormPermissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                schema: "ModelSecurity",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolFormPermissions_Forms_FormId",
                schema: "ModelSecurity",
                table: "RolFormPermissions",
                column: "FormId",
                principalSchema: "ModelSecurity",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolFormPermissions_Permissions_PermissionId",
                schema: "ModelSecurity",
                table: "RolFormPermissions",
                column: "PermissionId",
                principalSchema: "ModelSecurity",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolFormPermissions_Roles_RolId",
                schema: "ModelSecurity",
                table: "RolFormPermissions",
                column: "RolId",
                principalSchema: "ModelSecurity",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RolId",
                table: "UserRoles",
                column: "RolId",
                principalSchema: "ModelSecurity",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolFormPermissions_Forms_FormId",
                schema: "ModelSecurity",
                table: "RolFormPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RolFormPermissions_Permissions_PermissionId",
                schema: "ModelSecurity",
                table: "RolFormPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RolFormPermissions_Roles_RolId",
                schema: "ModelSecurity",
                table: "RolFormPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RolId",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolFormPermissions",
                schema: "ModelSecurity",
                table: "RolFormPermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                schema: "ModelSecurity",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Permissions",
                schema: "ModelSecurity",
                newName: "Permissions");

            migrationBuilder.RenameTable(
                name: "People",
                schema: "ModelSecurity",
                newName: "People");

            migrationBuilder.RenameTable(
                name: "Modules",
                schema: "ModelSecurity",
                newName: "Modules");

            migrationBuilder.RenameTable(
                name: "ModuleForms",
                schema: "ModelSecurity",
                newName: "ModuleForms");

            migrationBuilder.RenameTable(
                name: "Forms",
                schema: "ModelSecurity",
                newName: "Forms");

            migrationBuilder.RenameTable(
                name: "RolFormPermissions",
                schema: "ModelSecurity",
                newName: "RoleFormPermissions");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "ModelSecurity",
                newName: "Role");

            migrationBuilder.RenameIndex(
                name: "IX_RolFormPermissions_RolId",
                table: "RoleFormPermissions",
                newName: "IX_RoleFormPermissions_RolId");

            migrationBuilder.RenameIndex(
                name: "IX_RolFormPermissions_PermissionId",
                table: "RoleFormPermissions",
                newName: "IX_RoleFormPermissions_PermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_RolFormPermissions_FormId",
                table: "RoleFormPermissions",
                newName: "IX_RoleFormPermissions_FormId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleFormPermissions",
                table: "RoleFormPermissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleFormPermissions_Forms_FormId",
                table: "RoleFormPermissions",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleFormPermissions_Permissions_PermissionId",
                table: "RoleFormPermissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleFormPermissions_Role_RolId",
                table: "RoleFormPermissions",
                column: "RolId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Role_RolId",
                table: "UserRoles",
                column: "RolId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
