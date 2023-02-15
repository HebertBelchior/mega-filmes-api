using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaFilmes.Infra.Migrations
{
    public partial class Criatabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "atores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_atores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "generos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "filmes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ano = table.Column<int>(type: "int", nullable: false),
                    diretor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    genero_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filmes", x => x.id);
                    table.ForeignKey(
                        name: "FK_filmes_generos_genero_id",
                        column: x => x.genero_id,
                        principalTable: "generos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "avaliacoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    criterio = table.Column<int>(type: "int", nullable: false),
                    comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    filme_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avaliacoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_avaliacoes_filmes_filme_id",
                        column: x => x.filme_id,
                        principalTable: "filmes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "filmes_atores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    filme_id = table.Column<int>(type: "int", nullable: false),
                    ator_id = table.Column<int>(type: "int", nullable: false),
                    papel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filmes_atores", x => x.id);
                    table.ForeignKey(
                        name: "FK_filmes_atores_atores_ator_id",
                        column: x => x.ator_id,
                        principalTable: "atores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_filmes_atores_filmes_filme_id",
                        column: x => x.filme_id,
                        principalTable: "filmes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_avaliacoes_filme_id",
                table: "avaliacoes",
                column: "filme_id");

            migrationBuilder.CreateIndex(
                name: "IX_filmes_genero_id",
                table: "filmes",
                column: "genero_id");

            migrationBuilder.CreateIndex(
                name: "IX_filmes_atores_ator_id",
                table: "filmes_atores",
                column: "ator_id");

            migrationBuilder.CreateIndex(
                name: "IX_filmes_atores_filme_id",
                table: "filmes_atores",
                column: "filme_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "avaliacoes");

            migrationBuilder.DropTable(
                name: "filmes_atores");

            migrationBuilder.DropTable(
                name: "atores");

            migrationBuilder.DropTable(
                name: "filmes");

            migrationBuilder.DropTable(
                name: "generos");
        }
    }
}
