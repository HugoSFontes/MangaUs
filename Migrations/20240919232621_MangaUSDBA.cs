using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangaUs.Migrations
{
    /// <inheritdoc />
    public partial class MangaUSDBA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mangas",
                columns: table => new
                {
                    MangaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapaManga = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DtCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mangas", x => x.MangaId);
                });

            migrationBuilder.CreateTable(
                name: "Capitulos",
                columns: table => new
                {
                    CapituloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCapitulo = table.Column<int>(type: "int", nullable: false),
                    DtAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MangaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capitulos", x => x.CapituloId);
                    table.ForeignKey(
                        name: "FK_Capitulos_Mangas_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "MangaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paginas",
                columns: table => new
                {
                    PaginaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroPagina = table.Column<int>(type: "int", nullable: false),
                    CapituloId = table.Column<int>(type: "int", nullable: false),
                    Imagem = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paginas", x => x.PaginaId);
                    table.ForeignKey(
                        name: "FK_Paginas_Capitulos_CapituloId",
                        column: x => x.CapituloId,
                        principalTable: "Capitulos",
                        principalColumn: "CapituloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Capitulos_MangaId",
                table: "Capitulos",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_Paginas_CapituloId",
                table: "Paginas",
                column: "CapituloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paginas");

            migrationBuilder.DropTable(
                name: "Capitulos");

            migrationBuilder.DropTable(
                name: "Mangas");
        }
    }
}
