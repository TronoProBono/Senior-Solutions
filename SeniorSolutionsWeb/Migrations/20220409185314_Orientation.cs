using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorSolutionsWeb.Migrations
{
    public partial class Orientation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orientations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orientations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrientationAttendees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResidentId = table.Column<int>(type: "int", nullable: false),
                    OrientationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrientationAttendees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrientationAttendees_Orientations_OrientationId",
                        column: x => x.OrientationId,
                        principalTable: "Orientations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrientationAttendees_Resident_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Resident",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrientationAttendees_OrientationId",
                table: "OrientationAttendees",
                column: "OrientationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrientationAttendees_ResidentId",
                table: "OrientationAttendees",
                column: "ResidentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrientationAttendees");

            migrationBuilder.DropTable(
                name: "Orientations");
        }
    }
}
