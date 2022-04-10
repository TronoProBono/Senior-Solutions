using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorSolutionsWeb.Migrations
{
    public partial class CommunityIssuesFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResidentId",
                table: "CommunityIssue",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommunityIssue_ResidentId",
                table: "CommunityIssue",
                column: "ResidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityIssue_Resident_ResidentId",
                table: "CommunityIssue",
                column: "ResidentId",
                principalTable: "Resident",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunityIssue_Resident_ResidentId",
                table: "CommunityIssue");

            migrationBuilder.DropIndex(
                name: "IX_CommunityIssue_ResidentId",
                table: "CommunityIssue");

            migrationBuilder.DropColumn(
                name: "ResidentId",
                table: "CommunityIssue");
        }
    }
}
