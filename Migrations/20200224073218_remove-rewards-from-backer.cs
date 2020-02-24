using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFun.Core.Migrations
{
    public partial class removerewardsfrombacker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_Backers_BackerId",
                table: "Rewards");

            migrationBuilder.DropIndex(
                name: "IX_Rewards_BackerId",
                table: "Rewards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Backers",
                table: "Backers");

            migrationBuilder.DropColumn(
                name: "BackerId",
                table: "Rewards");

            migrationBuilder.RenameTable(
                name: "Backers",
                newName: "Backer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Backer",
                table: "Backer",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Backer",
                table: "Backer");

            migrationBuilder.RenameTable(
                name: "Backer",
                newName: "Backers");

            migrationBuilder.AddColumn<int>(
                name: "BackerId",
                table: "Rewards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Backers",
                table: "Backers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_BackerId",
                table: "Rewards",
                column: "BackerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_Backers_BackerId",
                table: "Rewards",
                column: "BackerId",
                principalTable: "Backers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
