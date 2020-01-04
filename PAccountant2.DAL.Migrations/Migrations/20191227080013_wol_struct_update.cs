using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PAccountant2.DAL.Migrations.Migrations
{
    public partial class wol_struct_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WheelOfLifeElementMemento");

            migrationBuilder.AddColumn<int>(
                name: "ElementId",
                table: "WheelOfLifeMemento",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "WheelOfLifeMemento",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WheelOfLifeMemento_ElementId",
                table: "WheelOfLifeMemento",
                column: "ElementId");

            migrationBuilder.AddForeignKey(
                name: "FK_WheelOfLifeMemento_WheelOfLifeElement_ElementId",
                table: "WheelOfLifeMemento",
                column: "ElementId",
                principalTable: "WheelOfLifeElement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WheelOfLifeMemento_WheelOfLifeElement_ElementId",
                table: "WheelOfLifeMemento");

            migrationBuilder.DropIndex(
                name: "IX_WheelOfLifeMemento_ElementId",
                table: "WheelOfLifeMemento");

            migrationBuilder.DropColumn(
                name: "ElementId",
                table: "WheelOfLifeMemento");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "WheelOfLifeMemento");

            migrationBuilder.CreateTable(
                name: "WheelOfLifeElementMemento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WheelElementId = table.Column<int>(nullable: false),
                    WheelMementoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WheelOfLifeElementMemento", x => x.Id);
                    table.ForeignKey(
                        name: "ElementManyToManyFK",
                        column: x => x.WheelElementId,
                        principalTable: "WheelOfLifeElement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "MementoManyToManyFK",
                        column: x => x.WheelMementoId,
                        principalTable: "WheelOfLifeMemento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WheelOfLifeElementMemento_WheelElementId",
                table: "WheelOfLifeElementMemento",
                column: "WheelElementId");

            migrationBuilder.CreateIndex(
                name: "IX_WheelOfLifeElementMemento_WheelMementoId",
                table: "WheelOfLifeElementMemento",
                column: "WheelMementoId");
        }
    }
}
