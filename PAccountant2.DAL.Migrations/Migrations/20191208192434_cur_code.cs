using Microsoft.EntityFrameworkCore.Migrations;

namespace PAccountant2.DAL.Migrations.Migrations
{
    public partial class cur_code : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Currency",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Currency");
        }
    }
}
