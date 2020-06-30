using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.WebAPI.Migrations
{
    public partial class HeroisBatalhas_identidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Herois_Batalhas_BatalhaId",
                table: "Herois");

            migrationBuilder.DropIndex(
                name: "IX_Herois_BatalhaId",
                table: "Herois");

            migrationBuilder.DropColumn(
                name: "BatalhaId",
                table: "Herois");

            migrationBuilder.CreateTable(
                name: "HeroiBatalhas",
                columns: table => new
                {
                    HeroiID = table.Column<int>(nullable: false),
                    BatalhaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroiBatalhas", x => new { x.BatalhaID, x.HeroiID });
                    table.ForeignKey(
                        name: "FK_HeroiBatalhas_Batalhas_BatalhaID",
                        column: x => x.BatalhaID,
                        principalTable: "Batalhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroiBatalhas_Herois_HeroiID",
                        column: x => x.HeroiID,
                        principalTable: "Herois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identidadeSecretas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeReal = table.Column<int>(nullable: false),
                    HeroiID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_identidadeSecretas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_identidadeSecretas_Herois_HeroiID",
                        column: x => x.HeroiID,
                        principalTable: "Herois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroiBatalhas_HeroiID",
                table: "HeroiBatalhas",
                column: "HeroiID");

            migrationBuilder.CreateIndex(
                name: "IX_identidadeSecretas_HeroiID",
                table: "identidadeSecretas",
                column: "HeroiID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroiBatalhas");

            migrationBuilder.DropTable(
                name: "identidadeSecretas");

            migrationBuilder.AddColumn<int>(
                name: "BatalhaId",
                table: "Herois",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Herois_BatalhaId",
                table: "Herois",
                column: "BatalhaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Herois_Batalhas_BatalhaId",
                table: "Herois",
                column: "BatalhaId",
                principalTable: "Batalhas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
