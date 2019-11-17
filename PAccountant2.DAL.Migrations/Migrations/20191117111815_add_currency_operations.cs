using Microsoft.EntityFrameworkCore.Migrations;

namespace PAccountant2.DAL.Migrations.Migrations
{
    public partial class add_currency_operations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "InvestmentOperation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "AccountOperation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentOperation_CurrencyId",
                table: "InvestmentOperation",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOperation_CurrencyId",
                table: "AccountOperation",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOperation_Currency_CurrencyId",
                table: "AccountOperation",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvestmentOperation_Currency_CurrencyId",
                table: "InvestmentOperation",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountOperation_Currency_CurrencyId",
                table: "AccountOperation");

            migrationBuilder.DropForeignKey(
                name: "FK_InvestmentOperation_Currency_CurrencyId",
                table: "InvestmentOperation");

            migrationBuilder.DropIndex(
                name: "IX_InvestmentOperation_CurrencyId",
                table: "InvestmentOperation");

            migrationBuilder.DropIndex(
                name: "IX_AccountOperation_CurrencyId",
                table: "AccountOperation");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "InvestmentOperation");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "AccountOperation");
        }
    }
}
