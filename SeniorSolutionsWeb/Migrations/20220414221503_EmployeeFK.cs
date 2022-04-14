using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorSolutionsWeb.Migrations
{
    public partial class EmployeeFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EmployeeAssignedId",
                table: "ServiceRequest",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequest_EmployeeAssignedId",
                table: "ServiceRequest",
                column: "EmployeeAssignedId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequest_RequestorId",
                table: "ServiceRequest",
                column: "RequestorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequest_Employee_EmployeeAssignedId",
                table: "ServiceRequest",
                column: "EmployeeAssignedId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequest_Resident_RequestorId",
                table: "ServiceRequest",
                column: "RequestorId",
                principalTable: "Resident",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequest_Employee_EmployeeAssignedId",
                table: "ServiceRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequest_Resident_RequestorId",
                table: "ServiceRequest");

            migrationBuilder.DropIndex(
                name: "IX_ServiceRequest_EmployeeAssignedId",
                table: "ServiceRequest");

            migrationBuilder.DropIndex(
                name: "IX_ServiceRequest_RequestorId",
                table: "ServiceRequest");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeAssignedId",
                table: "ServiceRequest",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
