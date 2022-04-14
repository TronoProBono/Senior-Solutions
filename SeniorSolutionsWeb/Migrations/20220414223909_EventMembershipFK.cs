using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorSolutionsWeb.Migrations
{
    public partial class EventMembershipFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RolesEventRoleID",
                table: "EventMembership",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EventMembership_EventID",
                table: "EventMembership",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventMembership_ResidentID",
                table: "EventMembership",
                column: "ResidentID");

            migrationBuilder.CreateIndex(
                name: "IX_EventMembership_RolesEventRoleID",
                table: "EventMembership",
                column: "RolesEventRoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_EventMembership_EventRoles_RolesEventRoleID",
                table: "EventMembership",
                column: "RolesEventRoleID",
                principalTable: "EventRoles",
                principalColumn: "EventRoleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventMembership_Events_EventID",
                table: "EventMembership",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_EventMembership_Resident_ResidentID",
                table: "EventMembership",
                column: "ResidentID",
                principalTable: "Resident",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventMembership_EventRoles_RolesEventRoleID",
                table: "EventMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_EventMembership_Events_EventID",
                table: "EventMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_EventMembership_Resident_ResidentID",
                table: "EventMembership");

            migrationBuilder.DropIndex(
                name: "IX_EventMembership_EventID",
                table: "EventMembership");

            migrationBuilder.DropIndex(
                name: "IX_EventMembership_ResidentID",
                table: "EventMembership");

            migrationBuilder.DropIndex(
                name: "IX_EventMembership_RolesEventRoleID",
                table: "EventMembership");

            migrationBuilder.DropColumn(
                name: "RolesEventRoleID",
                table: "EventMembership");
        }
    }
}
