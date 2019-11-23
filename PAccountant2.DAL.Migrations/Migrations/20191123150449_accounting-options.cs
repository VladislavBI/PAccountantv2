using Microsoft.EntityFrameworkCore.Migrations;

namespace PAccountant2.DAL.Migrations.Migrations
{
    public partial class accountingoptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountingOptions",
                columns: table => new
                {
                    AccountingId = table.Column<int>(nullable: false),
                    AccountingBaseCurrencyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingOptions", x => x.AccountingId);
                    table.ForeignKey(
                        name: "FK_AccountingOptions_Currency_AccountingBaseCurrencyId",
                        column: x => x.AccountingBaseCurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountingOptions_Accounting_AccountingId",
                        column: x => x.AccountingId,
                        principalTable: "Accounting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountingOptions_AccountingBaseCurrencyId",
                table: "AccountingOptions",
                column: "AccountingBaseCurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountingOptions");
        }
    }
}
