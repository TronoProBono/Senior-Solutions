using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorSolutionsWeb.Migrations
{
    public partial class ClubMembershipFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RolesRoleID",
                table: "ClubMembership",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClubMembership_CID",
                table: "ClubMembership",
                column: "CID");

            migrationBuilder.CreateIndex(
                name: "IX_ClubMembership_ResidentID",
                table: "ClubMembership",
                column: "ResidentID");

            migrationBuilder.CreateIndex(
                name: "IX_ClubMembership_RolesRoleID",
                table: "ClubMembership",
                column: "RolesRoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClubMembership_Club_CID",
                table: "ClubMembership",
                column: "CID",
                principalTable: "Club",
                principalColumn: "ClubId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClubMembership_ClubRoles_RolesRoleID",
                table: "ClubMembership",
                column: "RolesRoleID",
                principalTable: "ClubRoles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClubMembership_Resident_ResidentID",
                table: "ClubMembership",
                column: "ResidentID",
                principalTable: "Resident",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubMembership_Club_CID",
                table: "ClubMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_ClubMembership_ClubRoles_RolesRoleID",
                table: "ClubMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_ClubMembership_Resident_ResidentID",
                table: "ClubMembership");

            migrationBuilder.DropIndex(
                name: "IX_ClubMembership_CID",
                table: "ClubMembership");

            migrationBuilder.DropIndex(
                name: "IX_ClubMembership_ResidentID",
                table: "ClubMembership");

            migrationBuilder.DropIndex(
                name: "IX_ClubMembership_RolesRoleID",
                table: "ClubMembership");

            migrationBuilder.DropColumn(
                name: "RolesRoleID",
                table: "ClubMembership");
        }
    }
}
