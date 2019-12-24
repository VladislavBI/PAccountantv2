using Microsoft.EntityFrameworkCore.Migrations;

namespace PAccountant2.DAL.Migrations.Migrations
{
    public partial class wheeloflifeseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WheelOfLifeElement",
                columns: new[] { "Id", "Name", "Score" },
                values: new object[,]
                {
                    { 1, "Health", 10 },
                    { 2, "Spiritual", 10 },
                    { 3, "Financial", 10 },
                    { 4, "Social", 10 },
                    { 5, "Life quality", 10 },
                    { 6, "Education", 10 },
                    { 7, "Work", 10 },
                    { 8, "Relations", 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WheelOfLifeElement",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WheelOfLifeElement",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WheelOfLifeElement",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WheelOfLifeElement",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WheelOfLifeElement",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WheelOfLifeElement",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "WheelOfLifeElement",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "WheelOfLifeElement",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
