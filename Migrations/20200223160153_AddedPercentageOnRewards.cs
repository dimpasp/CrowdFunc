using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFun.Core.Migrations
{
    public partial class AddedPercentageOnRewards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Percentage",
                table: "Rewards",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "Rewards");
        }
    }
}
