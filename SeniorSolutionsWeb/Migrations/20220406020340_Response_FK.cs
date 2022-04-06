using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorSolutionsWeb.Migrations
{
    public partial class Response_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommunityIssueId",
                table: "ResidentPostResponse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CommunityIssue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpVotes = table.Column<int>(type: "int", nullable: false),
                    DownVotes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityIssue", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResidentPostResponse_CommunityIssueId",
                table: "ResidentPostResponse",
                column: "CommunityIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentPostResponse_ResidentID",
                table: "ResidentPostResponse",
                column: "ResidentID");

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentPostResponse_CommunityIssue_CommunityIssueId",
                table: "ResidentPostResponse",
                column: "CommunityIssueId",
                principalTable: "CommunityIssue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentPostResponse_Resident_ResidentID",
                table: "ResidentPostResponse",
                column: "ResidentID",
                principalTable: "Resident",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidentPostResponse_CommunityIssue_CommunityIssueId",
                table: "ResidentPostResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentPostResponse_Resident_ResidentID",
                table: "ResidentPostResponse");

            migrationBuilder.DropTable(
                name: "CommunityIssue");

            migrationBuilder.DropIndex(
                name: "IX_ResidentPostResponse_CommunityIssueId",
                table: "ResidentPostResponse");

            migrationBuilder.DropIndex(
                name: "IX_ResidentPostResponse_ResidentID",
                table: "ResidentPostResponse");

            migrationBuilder.DropColumn(
                name: "CommunityIssueId",
                table: "ResidentPostResponse");
        }
    }
}
