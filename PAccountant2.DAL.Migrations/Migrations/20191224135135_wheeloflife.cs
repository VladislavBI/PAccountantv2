using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PAccountant2.DAL.Migrations.Migrations
{
    public partial class wheeloflife : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WheelOfLifeElement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Score = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WheelOfLifeElement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WheelOfLifeMemento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WheelOfLifeMemento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WheelOfLifeProblem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false),
                    IsFinished = table.Column<bool>(nullable: false),
                    ElementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WheelOfLifeProblem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WheelOfLifeProblem_WheelOfLifeElement_ElementId",
                        column: x => x.ElementId,
                        principalTable: "WheelOfLifeElement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WheelOfLifePlan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    isFinished = table.Column<bool>(nullable: false),
                    ProblemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WheelOfLifePlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WheelOfLifePlan_WheelOfLifeProblem_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "WheelOfLifeProblem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WheelOfLifePlan_ProblemId",
                table: "WheelOfLifePlan",
                column: "ProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_WheelOfLifeProblem_ElementId",
                table: "WheelOfLifeProblem",
                column: "ElementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WheelOfLifeMemento");

            migrationBuilder.DropTable(
                name: "WheelOfLifePlan");

            migrationBuilder.DropTable(
                name: "WheelOfLifeProblem");

            migrationBuilder.DropTable(
                name: "WheelOfLifeElement");
        }
    }
}
