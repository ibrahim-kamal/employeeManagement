using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Migrations
{
    public partial class Indentitychangename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "usertoken");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "userRole");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "userLogin");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "userClaim");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "role");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "roleClaim");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "userRole",
                newName: "IX_userRole_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "userLogin",
                newName: "IX_userLogin_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "userClaim",
                newName: "IX_userClaim_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "roleClaim",
                newName: "IX_roleClaim_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usertoken",
                table: "usertoken",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userRole",
                table: "userRole",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_userLogin",
                table: "userLogin",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_userClaim",
                table: "userClaim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_role",
                table: "role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roleClaim",
                table: "roleClaim",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_roleClaim_role_RoleId",
                table: "roleClaim",
                column: "RoleId",
                principalTable: "role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userClaim_user_UserId",
                table: "userClaim",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userLogin_user_UserId",
                table: "userLogin",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userRole_role_RoleId",
                table: "userRole",
                column: "RoleId",
                principalTable: "role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userRole_user_UserId",
                table: "userRole",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usertoken_user_UserId",
                table: "usertoken",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roleClaim_role_RoleId",
                table: "roleClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_userClaim_user_UserId",
                table: "userClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_userLogin_user_UserId",
                table: "userLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_userRole_role_RoleId",
                table: "userRole");

            migrationBuilder.DropForeignKey(
                name: "FK_userRole_user_UserId",
                table: "userRole");

            migrationBuilder.DropForeignKey(
                name: "FK_usertoken_user_UserId",
                table: "usertoken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usertoken",
                table: "usertoken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userRole",
                table: "userRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userLogin",
                table: "userLogin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userClaim",
                table: "userClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roleClaim",
                table: "roleClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_role",
                table: "role");

            migrationBuilder.RenameTable(
                name: "usertoken",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "userRole",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "userLogin",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "userClaim",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "roleClaim",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "role",
                newName: "AspNetRoles");

            migrationBuilder.RenameIndex(
                name: "IX_userRole_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_userLogin_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_userClaim_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_roleClaim_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
