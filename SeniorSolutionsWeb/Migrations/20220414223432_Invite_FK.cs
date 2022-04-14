using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorSolutionsWeb.Migrations
{
    public partial class Invite_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RolesRoleID",
                table: "Invite",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invite_ClubID",
                table: "Invite",
                column: "ClubID");

            migrationBuilder.CreateIndex(
                name: "IX_Invite_EventID",
                table: "Invite",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Invite_EventRoleID",
                table: "Invite",
                column: "EventRoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Invite_ResidentID",
                table: "Invite",
                column: "ResidentID");

            migrationBuilder.CreateIndex(
                name: "IX_Invite_RolesRoleID",
                table: "Invite",
                column: "RolesRoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invite_Club_ClubID",
                table: "Invite",
                column: "ClubID",
                principalTable: "Club",
                principalColumn: "ClubId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Invite_Events_EventID",
                table: "Invite",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invite_Resident_ResidentID",
                table: "Invite",
                column: "ResidentID",
                principalTable: "Resident",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invite_Club_ClubID",
                table: "Invite");

            migrationBuilder.DropForeignKey(
                name: "FK_Invite_ClubRoles_RolesRoleID",
                table: "Invite");

            migrationBuilder.DropForeignKey(
                name: "FK_Invite_EventRoles_EventRoleID",
                table: "Invite");

            migrationBuilder.DropForeignKey(
                name: "FK_Invite_Events_EventID",
                table: "Invite");

            migrationBuilder.DropForeignKey(
                name: "FK_Invite_Resident_ResidentID",
                table: "Invite");

            migrationBuilder.DropIndex(
                name: "IX_Invite_ClubID",
                table: "Invite");

            migrationBuilder.DropIndex(
                name: "IX_Invite_EventID",
                table: "Invite");

            migrationBuilder.DropIndex(
                name: "IX_Invite_EventRoleID",
                table: "Invite");

            migrationBuilder.DropIndex(
                name: "IX_Invite_ResidentID",
                table: "Invite");

            migrationBuilder.DropIndex(
                name: "IX_Invite_RolesRoleID",
                table: "Invite");

            migrationBuilder.DropColumn(
                name: "RolesRoleID",
                table: "Invite");
        }
    }
}
