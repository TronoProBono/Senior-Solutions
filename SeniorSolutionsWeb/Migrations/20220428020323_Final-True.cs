using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorSolutionsWeb.Migrations
{
    public partial class FinalTrue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invite_ClubRoles_RolesRoleID",
                table: "Invite");

            migrationBuilder.DropForeignKey(
                name: "FK_Invite_EventRoles_EventRoleID",
                table: "Invite");

            migrationBuilder.DropIndex(
                name: "IX_Invite_EventRoleID",
                table: "Invite");

            migrationBuilder.DropIndex(
                name: "IX_Invite_RolesRoleID",
                table: "Invite");

            migrationBuilder.DropColumn(
                name: "RolesRoleID",
                table: "Invite");

            migrationBuilder.AddColumn<int>(
                name: "ClubRolesRoleID",
                table: "Invite",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventRolesEventRoleID",
                table: "Invite",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invite_ClubRolesRoleID",
                table: "Invite",
                column: "ClubRolesRoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Invite_EventRolesEventRoleID",
                table: "Invite",
                column: "EventRolesEventRoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invite_ClubRoles_ClubRolesRoleID",
                table: "Invite",
                column: "ClubRolesRoleID",
                principalTable: "ClubRoles",
                principalColumn: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invite_EventRoles_EventRolesEventRoleID",
                table: "Invite",
                column: "EventRolesEventRoleID",
                principalTable: "EventRoles",
                principalColumn: "EventRoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invite_ClubRoles_ClubRolesRoleID",
                table: "Invite");

            migrationBuilder.DropForeignKey(
                name: "FK_Invite_EventRoles_EventRolesEventRoleID",
                table: "Invite");

            migrationBuilder.DropIndex(
                name: "IX_Invite_ClubRolesRoleID",
                table: "Invite");

            migrationBuilder.DropIndex(
                name: "IX_Invite_EventRolesEventRoleID",
                table: "Invite");

            migrationBuilder.DropColumn(
                name: "ClubRolesRoleID",
                table: "Invite");

            migrationBuilder.DropColumn(
                name: "EventRolesEventRoleID",
                table: "Invite");

            migrationBuilder.AddColumn<int>(
                name: "RolesRoleID",
                table: "Invite",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invite_EventRoleID",
                table: "Invite",
                column: "EventRoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Invite_RolesRoleID",
                table: "Invite",
                column: "RolesRoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invite_ClubRoles_RolesRoleID",
                table: "Invite",
                column: "RolesRoleID",
                principalTable: "ClubRoles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invite_EventRoles_EventRoleID",
                table: "Invite",
                column: "EventRoleID",
                principalTable: "EventRoles",
                principalColumn: "EventRoleID");
        }
    }
}
