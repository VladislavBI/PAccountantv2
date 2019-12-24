using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PAccountant2.DAL.Migrations.Migrations
{
    public partial class wheeloflifemanytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WheelOfLifeElementMemento");
        }
    }
}
