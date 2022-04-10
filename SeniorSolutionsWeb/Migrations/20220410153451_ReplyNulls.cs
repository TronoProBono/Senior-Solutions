using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorSolutionsWeb.Migrations
{
    public partial class ReplyNulls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunityIssueReplies_CommunityIssue_CommunityIssueId",
                table: "CommunityIssueReplies");

            migrationBuilder.AlterColumn<int>(
                name: "CommunityIssueId",
                table: "CommunityIssueReplies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityIssueReplies_CommunityIssue_CommunityIssueId",
                table: "CommunityIssueReplies",
                column: "CommunityIssueId",
                principalTable: "CommunityIssue",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunityIssueReplies_CommunityIssue_CommunityIssueId",
                table: "CommunityIssueReplies");

            migrationBuilder.AlterColumn<int>(
                name: "CommunityIssueId",
                table: "CommunityIssueReplies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
