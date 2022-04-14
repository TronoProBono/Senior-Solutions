using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorSolutionsWeb.Migrations
{
    public partial class Club_Meeting_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ClubMeeting_ClubId",
                table: "ClubMeeting",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClubMeeting_Club_ClubId",
                table: "ClubMeeting",
                column: "ClubId",
                principalTable: "Club",
                principalColumn: "ClubId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubMeeting_Club_ClubId",
                table: "ClubMeeting");

            migrationBuilder.DropIndex(
                name: "IX_ClubMeeting_ClubId",
                table: "ClubMeeting");
        }
    }
}
