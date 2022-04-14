using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorSolutionsWeb.Migrations
{
    public partial class ClubMeetings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ClubMeeting_MeetingPlace",
                table: "ClubMeeting",
                column: "MeetingPlace");

            migrationBuilder.AddForeignKey(
                name: "FK_ClubMeeting_Locations_LocationId",
                table: "ClubMeeting",
                column: "MeetingPlace",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubMeeting_Locations_LocationId",
                table: "ClubMeeting");

            migrationBuilder.DropIndex(
                name: "IX_ClubMeeting_MeetingPlace",
                table: "ClubMeeting");
        }
    }
}
