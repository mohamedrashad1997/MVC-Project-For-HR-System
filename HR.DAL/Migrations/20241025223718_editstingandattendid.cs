using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.DAL.Migrations
{
    public partial class editstingandattendid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Attendances_AttendanceId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Settings_SettingId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "SettingId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AttendanceId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Attendances_AttendanceId",
                table: "Employees",
                column: "AttendanceId",
                principalTable: "Attendances",
                principalColumn: "AttendanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Settings_SettingId",
                table: "Employees",
                column: "SettingId",
                principalTable: "Settings",
                principalColumn: "SettingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Attendances_AttendanceId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Settings_SettingId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "SettingId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AttendanceId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Attendances_AttendanceId",
                table: "Employees",
                column: "AttendanceId",
                principalTable: "Attendances",
                principalColumn: "AttendanceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Settings_SettingId",
                table: "Employees",
                column: "SettingId",
                principalTable: "Settings",
                principalColumn: "SettingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
