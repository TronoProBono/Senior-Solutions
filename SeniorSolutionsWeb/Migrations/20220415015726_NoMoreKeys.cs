using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorSolutionsWeb.Migrations
{
    public partial class NoMoreKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ClubMeeting_Locations_LocationId",
            //    table: "ClubMeeting");

            migrationBuilder.DropForeignKey(
                name: "FK_ClubMembership_ClubRoles_RolesRoleID",
                table: "ClubMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_ClubMembership_Resident_ResidentID",
                table: "ClubMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_EventMembership_EventRoles_RolesEventRoleID",
                table: "EventMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_EventMembership_Events_EventID",
                table: "EventMembership");

            migrationBuilder.DropIndex(
                name: "IX_EventMembership_EventID",
                table: "EventMembership");

            migrationBuilder.DropIndex(
                name: "IX_EventMembership_RolesEventRoleID",
                table: "EventMembership");

            migrationBuilder.DropIndex(
                name: "IX_ClubMembership_ResidentID",
                table: "ClubMembership");

            migrationBuilder.DropIndex(
                name: "IX_ClubMembership_RolesRoleID",
                table: "ClubMembership");

            //migrationBuilder.DropIndex(
            //    name: "IX_ClubMeeting_LocationId",
            //    table: "ClubMeeting");

            migrationBuilder.DropColumn(
                name: "RolesEventRoleID",
                table: "EventMembership");

            migrationBuilder.DropColumn(
                name: "RolesRoleID",
                table: "ClubMembership");

            //migrationBuilder.DropColumn(
            //    name: "LocationId",
            //    table: "ClubMeeting");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RolesEventRoleID",
                table: "EventMembership",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RolesRoleID",
                table: "ClubMembership",
                type: "int",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.AddColumn<int>(
            //    name: "LocationId",
            //    table: "ClubMeeting",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EventMembership_EventID",
                table: "EventMembership",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventMembership_RolesEventRoleID",
                table: "EventMembership",
                column: "RolesEventRoleID");

            migrationBuilder.CreateIndex(
                name: "IX_ClubMembership_ResidentID",
                table: "ClubMembership",
                column: "ResidentID");

            migrationBuilder.CreateIndex(
                name: "IX_ClubMembership_RolesRoleID",
                table: "ClubMembership",
                column: "RolesRoleID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ClubMeeting_LocationId",
            //    table: "ClubMeeting",
            //    column: "LocationId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ClubMeeting_Locations_LocationId",
            //    table: "ClubMeeting",
            //    column: "LocationId",
            //    principalTable: "Locations",
            //    principalColumn: "LocationId",
            //    onDelete: ReferentialAction.Cascade);

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
