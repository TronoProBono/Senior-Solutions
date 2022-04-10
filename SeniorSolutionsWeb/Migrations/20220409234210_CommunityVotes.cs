using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorSolutionsWeb.Migrations
{
    public partial class CommunityVotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommunityIssueVote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResidentId = table.Column<int>(type: "int", nullable: false),
                    CommunityIssueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityIssueVote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunityIssueVote_CommunityIssue_CommunityIssueId",
                        column: x => x.CommunityIssueId,
                        principalTable: "CommunityIssue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityIssueVote_Resident_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Resident",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunityIssueVote_CommunityIssueId",
                table: "CommunityIssueVote",
                column: "CommunityIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityIssueVote_ResidentId",
                table: "CommunityIssueVote",
                column: "ResidentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunityIssueVote");
        }
    }
}
