using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PAccountant2.DAL.Migrations.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeRate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BaseCurrencyId = table.Column<int>(nullable: false),
                    ResultCurrencyId = table.Column<int>(nullable: false),
                    Buy = table.Column<float>(nullable: false),
                    Sell = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExchangeRate_Currency_BaseCurrencyId",
                        column: x => x.BaseCurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExchangeRate_Currency_ResultCurrencyId",
                        column: x => x.ResultCurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accounting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounting_User_UserEmail",
                        column: x => x.UserEmail,
                        principalTable: "User",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(nullable: false),
                    AccountingId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 500, nullable: true),
                    CurrencyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Accounting_AccountingId",
                        column: x => x.AccountingId,
                        principalTable: "Accounting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Account_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Contragent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    AccountingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contragent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contragent_Accounting_AccountingId",
                        column: x => x.AccountingId,
                        principalTable: "Accounting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Credit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreditType = table.Column<int>(nullable: false),
                    PercentPeriod = table.Column<int>(nullable: false),
                    BodyAmount = table.Column<decimal>(nullable: false),
                    LeftAmount = table.Column<decimal>(nullable: false),
                    PercentAmount = table.Column<decimal>(nullable: false),
                    Percent = table.Column<float>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Term = table.Column<long>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    AccountingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credit_Accounting_AccountingId",
                        column: x => x.AccountingId,
                        principalTable: "Accounting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Investment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvestmentType = table.Column<int>(nullable: false),
                    PaymentPeriod = table.Column<int>(nullable: false),
                    StartBodyAmount = table.Column<decimal>(nullable: false),
                    CurrentBodyAmount = table.Column<decimal>(nullable: false),
                    Percent = table.Column<float>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Term = table.Column<long>(nullable: false),
                    MoneyIncomeOption = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Completed = table.Column<bool>(nullable: false),
                    AccountingId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investment_Accounting_AccountingId",
                        column: x => x.AccountingId,
                        principalTable: "Accounting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Investment_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountOperation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    OperationType = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    AccountId = table.Column<int>(nullable: false),
                    ContragentId = table.Column<int>(nullable: true),
                    CurrencyId = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountOperation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountOperation_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountOperation_Contragent_ContragentId",
                        column: x => x.ContragentId,
                        principalTable: "Contragent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountOperation_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditOperation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    OperationType = table.Column<int>(nullable: false),
                    CreditId = table.Column<int>(nullable: false),
                    ContragentId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditOperation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditOperation_Contragent_ContragentId",
                        column: x => x.ContragentId,
                        principalTable: "Contragent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditOperation_Credit_CreditId",
                        column: x => x.CreditId,
                        principalTable: "Credit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditOperation_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvestmentOperation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    NewTotalAmount = table.Column<decimal>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    InvestmentId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    ContragentDboId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentOperation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestmentOperation_Contragent_ContragentDboId",
                        column: x => x.ContragentDboId,
                        principalTable: "Contragent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvestmentOperation_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvestmentOperation_Investment_InvestmentId",
                        column: x => x.InvestmentId,
                        principalTable: "Investment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountingId",
                table: "Account",
                column: "AccountingId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_CurrencyId",
                table: "Account",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounting_UserEmail",
                table: "Accounting",
                column: "UserEmail",
                unique: true,
                filter: "[UserEmail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingOptions_AccountingBaseCurrencyId",
                table: "AccountingOptions",
                column: "AccountingBaseCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOperation_AccountId",
                table: "AccountOperation",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOperation_ContragentId",
                table: "AccountOperation",
                column: "ContragentId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOperation_CurrencyId",
                table: "AccountOperation",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contragent_AccountingId",
                table: "Contragent",
                column: "AccountingId");

            migrationBuilder.CreateIndex(
                name: "IX_Credit_AccountingId",
                table: "Credit",
                column: "AccountingId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditOperation_ContragentId",
                table: "CreditOperation",
                column: "ContragentId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditOperation_CreditId",
                table: "CreditOperation",
                column: "CreditId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditOperation_CurrencyId",
                table: "CreditOperation",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRate_BaseCurrencyId",
                table: "ExchangeRate",
                column: "BaseCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRate_ResultCurrencyId",
                table: "ExchangeRate",
                column: "ResultCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Investment_AccountingId",
                table: "Investment",
                column: "AccountingId");

            migrationBuilder.CreateIndex(
                name: "IX_Investment_CurrencyId",
                table: "Investment",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentOperation_ContragentDboId",
                table: "InvestmentOperation",
                column: "ContragentDboId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentOperation_CurrencyId",
                table: "InvestmentOperation",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentOperation_InvestmentId",
                table: "InvestmentOperation",
                column: "InvestmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountingOptions");

            migrationBuilder.DropTable(
                name: "AccountOperation");

            migrationBuilder.DropTable(
                name: "CreditOperation");

            migrationBuilder.DropTable(
                name: "ExchangeRate");

            migrationBuilder.DropTable(
                name: "InvestmentOperation");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Credit");

            migrationBuilder.DropTable(
                name: "Contragent");

            migrationBuilder.DropTable(
                name: "Investment");

            migrationBuilder.DropTable(
                name: "Accounting");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
