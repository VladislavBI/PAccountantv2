using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PAccountant2.DAL.Migrations.Migrations
{
    public partial class addexcpected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isFinished",
                table: "WheelOfLifePlan",
                newName: "IsFinished");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "WheelOfLifeProblem",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ExpectedResult",
                table: "WheelOfLifeProblem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpectedResult",
                table: "WheelOfLifePlan",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "WheelOfLifeProblem");

            migrationBuilder.DropColumn(
                name: "ExpectedResult",
                table: "WheelOfLifeProblem");

            migrationBuilder.DropColumn(
                name: "ExpectedResult",
                table: "WheelOfLifePlan");

            migrationBuilder.RenameColumn(
                name: "IsFinished",
                table: "WheelOfLifePlan",
                newName: "isFinished");
        }
    }
}
