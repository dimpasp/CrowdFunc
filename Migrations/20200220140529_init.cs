using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFun.Core.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Backer",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Creator",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tittle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Photos = table.Column<string>(nullable: true),
                    Videos = table.Column<string>(nullable: true),
                    UpdateStatus = table.Column<bool>(nullable: false),
                    BackersId = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    Projectid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.id);
                    table.ForeignKey(
                        name: "FK_Project_Backer_BackersId",
                        column: x => x.BackersId,
                        principalTable: "Backer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Creator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Creator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Project_Projectid",
                        column: x => x.Projectid,
                        principalTable: "Project",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reward",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Value = table.Column<float>(nullable: false),
                    backersId = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    Projectid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reward", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reward_Creator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Creator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reward_Project_Projectid",
                        column: x => x.Projectid,
                        principalTable: "Project",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reward_Backer_backersId",
                        column: x => x.backersId,
                        principalTable: "Backer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BackerReward",
                columns: table => new
                {
                    BackerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackersId = table.Column<string>(nullable: true),
                    RewardsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackerReward", x => x.BackerId);
                    table.ForeignKey(
                        name: "FK_BackerReward_Backer_BackersId",
                        column: x => x.BackersId,
                        principalTable: "Backer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BackerReward_Reward_RewardsId",
                        column: x => x.RewardsId,
                        principalTable: "Reward",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Backer_Email",
                table: "Backer",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Backer_FirstName",
                table: "Backer",
                column: "FirstName",
                unique: true,
                filter: "[FirstName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Backer_LastName",
                table: "Backer",
                column: "LastName",
                unique: true,
                filter: "[LastName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BackerReward_BackersId",
                table: "BackerReward",
                column: "BackersId");

            migrationBuilder.CreateIndex(
                name: "IX_BackerReward_RewardsId",
                table: "BackerReward",
                column: "RewardsId");

            migrationBuilder.CreateIndex(
                name: "IX_Creator_Id",
                table: "Creator",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Creator_LastName",
                table: "Creator",
                column: "LastName",
                unique: true,
                filter: "[LastName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Project_BackersId",
                table: "Project",
                column: "BackersId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatorId",
                table: "Project",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Projectid",
                table: "Project",
                column: "Projectid");

            migrationBuilder.CreateIndex(
                name: "IX_Reward_CreatorId",
                table: "Reward",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reward_Projectid",
                table: "Reward",
                column: "Projectid");

            migrationBuilder.CreateIndex(
                name: "IX_Reward_backersId",
                table: "Reward",
                column: "backersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackerReward");

            migrationBuilder.DropTable(
                name: "Reward");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Backer");

            migrationBuilder.DropTable(
                name: "Creator");
        }
    }
}
