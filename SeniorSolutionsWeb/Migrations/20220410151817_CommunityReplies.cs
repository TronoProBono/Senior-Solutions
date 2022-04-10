using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorSolutionsWeb.Migrations
{
    public partial class CommunityReplies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResidentPostResponse");

            migrationBuilder.CreateTable(
                name: "CommunityIssueReplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueID = table.Column<int>(type: "int", nullable: false),
                    CommunityIssueId = table.Column<int>(type: "int", nullable: false),
                    ResidentID = table.Column<int>(type: "int", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateResponse = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityIssueReplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunityIssueReplies_CommunityIssue_CommunityIssueId",
                        column: x => x.CommunityIssueId,
                        principalTable: "CommunityIssue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityIssueReplies_Resident_ResidentID",
                        column: x => x.ResidentID,
                        principalTable: "Resident",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunityIssueReplies_CommunityIssueId",
                table: "CommunityIssueReplies",
                column: "CommunityIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityIssueReplies_ResidentID",
                table: "CommunityIssueReplies",
                column: "ResidentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunityIssueReplies");

            migrationBuilder.CreateTable(
                name: "ResidentPostResponse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunityIssueId = table.Column<int>(type: "int", nullable: false),
                    ResidentID = table.Column<int>(type: "int", nullable: false),
                    DateResponse = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssueID = table.Column<int>(type: "int", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vote = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentPostResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentPostResponse_CommunityIssue_CommunityIssueId",
                        column: x => x.CommunityIssueId,
                        principalTable: "CommunityIssue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentPostResponse_Resident_ResidentID",
                        column: x => x.ResidentID,
                        principalTable: "Resident",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResidentPostResponse_CommunityIssueId",
                table: "ResidentPostResponse",
                column: "CommunityIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentPostResponse_ResidentID",
                table: "ResidentPostResponse",
                column: "ResidentID");
        }
    }
}
