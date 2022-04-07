using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorSolutionsWeb.Migrations
{
    public partial class Polls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Poll",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Answer1Votes = table.Column<int>(type: "int", nullable: false),
                    Answer2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Answer2Votes = table.Column<int>(type: "int", nullable: false),
                    Answer3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Answer3Votes = table.Column<int>(type: "int", nullable: false),
                    Answer4 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Answer4Votes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poll", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PollVote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PollId = table.Column<int>(type: "int", nullable: false),
                    ResidentId = table.Column<int>(type: "int", nullable: false),
                    VotedFor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollVote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PollVote_Poll_PollId",
                        column: x => x.PollId,
                        principalTable: "Poll",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PollVote_Resident_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Resident",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PollVote_PollId",
                table: "PollVote",
                column: "PollId");

            migrationBuilder.CreateIndex(
                name: "IX_PollVote_ResidentId",
                table: "PollVote",
                column: "ResidentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PollVote");

            migrationBuilder.DropTable(
                name: "Poll");
        }
    }
}
