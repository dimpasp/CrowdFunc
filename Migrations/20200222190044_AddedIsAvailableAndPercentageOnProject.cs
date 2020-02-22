using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFun.Core.Migrations
{
    public partial class AddedIsAvailableAndPercentageOnProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateStatus",
                table: "Projects");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvaliable",
                table: "Projects",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Percentage",
                table: "Projects",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvaliable",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "Projects");

            migrationBuilder.AddColumn<bool>(
                name: "UpdateStatus",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
