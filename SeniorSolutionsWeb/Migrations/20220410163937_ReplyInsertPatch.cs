using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorSolutionsWeb.Migrations
{
    public partial class ReplyInsertPatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunityIssueReplies_CommunityIssue_CommunityIssueId",
                table: "CommunityIssueReplies");

            migrationBuilder.DropColumn(
                name: "IssueID",
                table: "CommunityIssueReplies");

            migrationBuilder.RenameColumn(
                name: "CommunityIssueId",
                table: "CommunityIssueReplies",
                newName: "CommunityIssueID");

            migrationBuilder.RenameIndex(
                name: "IX_CommunityIssueReplies_CommunityIssueId",
                table: "CommunityIssueReplies",
                newName: "IX_CommunityIssueReplies_CommunityIssueID");

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityIssueReplies_CommunityIssue_CommunityIssueID",
                table: "CommunityIssueReplies",
                column: "CommunityIssueID",
                principalTable: "CommunityIssue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunityIssueReplies_CommunityIssue_CommunityIssueID",
                table: "CommunityIssueReplies");

            migrationBuilder.RenameColumn(
                name: "CommunityIssueID",
                table: "CommunityIssueReplies",
                newName: "CommunityIssueId");

            migrationBuilder.RenameIndex(
                name: "IX_CommunityIssueReplies_CommunityIssueID",
                table: "CommunityIssueReplies",
                newName: "IX_CommunityIssueReplies_CommunityIssueId");

            migrationBuilder.AddColumn<int>(
                name: "IssueID",
                table: "CommunityIssueReplies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityIssueReplies_CommunityIssue_CommunityIssueId",
                table: "CommunityIssueReplies",
                column: "CommunityIssueId",
                principalTable: "CommunityIssue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
