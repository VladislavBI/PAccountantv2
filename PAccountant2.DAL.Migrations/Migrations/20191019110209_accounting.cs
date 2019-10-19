using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PAccountant2.DAL.Migrations.Migrations
{
    public partial class accounting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountingId",
                table: "Account",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountingId",
                table: "Account",
                column: "AccountingId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounting_UserEmail",
                table: "Accounting",
                column: "UserEmail",
                unique: true,
                filter: "[UserEmail] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Accounting_AccountingId",
                table: "Account",
                column: "AccountingId",
                principalTable: "Accounting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Accounting_AccountingId",
                table: "Account");

            migrationBuilder.DropTable(
                name: "Accounting");

            migrationBuilder.DropIndex(
                name: "IX_Account_AccountingId",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "AccountingId",
                table: "Account");
        }
    }
}
