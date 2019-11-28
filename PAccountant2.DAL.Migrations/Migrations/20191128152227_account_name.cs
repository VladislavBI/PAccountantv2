using Microsoft.EntityFrameworkCore.Migrations;

namespace PAccountant2.DAL.Migrations.Migrations
{
    public partial class account_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Account",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Account");
        }
    }
}
