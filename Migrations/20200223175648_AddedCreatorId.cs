using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFun.Core.Migrations
{
    public partial class AddedCreatorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Creators_CreatorId",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Creators_CreatorId",
                table: "Projects",
                column: "CreatorId",
                principalTable: "Creators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Creators_CreatorId",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Projects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Creators_CreatorId",
                table: "Projects",
                column: "CreatorId",
                principalTable: "Creators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
