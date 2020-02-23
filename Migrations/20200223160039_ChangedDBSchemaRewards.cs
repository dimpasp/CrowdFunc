using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFun.Core.Migrations
{
    public partial class ChangedDBSchemaRewards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Rewards",
                table: "Rewards");

            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "Rewards");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Rewards",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Rewards",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Rewards",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rewards",
                table: "Rewards",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_BackerId",
                table: "Rewards",
                column: "BackerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Rewards",
                table: "Rewards");

            migrationBuilder.DropIndex(
                name: "IX_Rewards_BackerId",
                table: "Rewards");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Rewards");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Rewards");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Rewards",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<int>(
                name: "Percentage",
                table: "Rewards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rewards",
                table: "Rewards",
                columns: new[] { "BackerId", "ProjectId" });
        }
    }
}
