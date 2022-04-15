using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorSolutionsWeb.Migrations
{
    public partial class RevisedNullID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequest_Employee_EmployeeAssignedId",
                table: "ServiceRequest");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeAssignedId",
                table: "ServiceRequest",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequest_Employee_EmployeeAssignedId",
                table: "ServiceRequest",
                column: "EmployeeAssignedId",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequest_Employee_EmployeeAssignedId",
                table: "ServiceRequest");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeAssignedId",
                table: "ServiceRequest",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequest_Employee_EmployeeAssignedId",
                table: "ServiceRequest",
                column: "EmployeeAssignedId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
