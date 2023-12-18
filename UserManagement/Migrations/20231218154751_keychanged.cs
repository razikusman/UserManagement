using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagement.Migrations
{
    /// <inheritdoc />
    public partial class keychanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_salaries_employees_EmployeeId",
                table: "salaries");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "salaries",
                newName: "EmployeesId");

            migrationBuilder.RenameColumn(
                name: "SalaryId",
                table: "salaries",
                newName: "SalariesId");

            migrationBuilder.RenameIndex(
                name: "IX_salaries_EmployeeId",
                table: "salaries",
                newName: "IX_salaries_EmployeesId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "employees",
                newName: "EmployeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_salaries_employees_EmployeesId",
                table: "salaries",
                column: "EmployeesId",
                principalTable: "employees",
                principalColumn: "EmployeesId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_salaries_employees_EmployeesId",
                table: "salaries");

            migrationBuilder.RenameColumn(
                name: "EmployeesId",
                table: "salaries",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "SalariesId",
                table: "salaries",
                newName: "SalaryId");

            migrationBuilder.RenameIndex(
                name: "IX_salaries_EmployeesId",
                table: "salaries",
                newName: "IX_salaries_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "EmployeesId",
                table: "employees",
                newName: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_salaries_employees_EmployeeId",
                table: "salaries",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
