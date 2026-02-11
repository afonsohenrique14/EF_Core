using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FuscaFilmes.Repo.Migrations
{
    /// <inheritdoc />
    public partial class _121_DiretorDetalhe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiretorDetalhe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Biografia = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DiretorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiretorDetalhe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiretorDetalhe_Diretores_DiretorId",
                        column: x => x.DiretorId,
                        principalTable: "Diretores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DiretorDetalhe",
                columns: new[] { "Id", "Biografia", "DataNascimento", "DiretorId" },
                values: new object[,]
                {
                    { 1, "Christopher Nolan é um cineasta britânico-americano conhecido por narrativas complexas e visuais inovadores.", new DateTime(1970, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Steven Spielberg é um dos diretores mais influentes da história, responsável por clássicos do cinema moderno.", new DateTime(1946, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, "Quentin Tarantino é conhecido por seu estilo único, diálogos marcantes e narrativas não lineares.", new DateTime(1963, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, "Martin Scorsese é um dos maiores diretores americanos, famoso por filmes sobre crime e personagens complexos.", new DateTime(1942, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, "James Cameron é conhecido por grandes produções e inovações tecnológicas no cinema.", new DateTime(1954, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 6, "Ridley Scott é um diretor britânico renomado por obras de ficção científica e épicos visuais.", new DateTime(1937, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 7, "Peter Jackson ganhou destaque mundial com a trilogia O Senhor dos Anéis.", new DateTime(1961, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 8, "Denis Villeneuve é conhecido por sua estética visual marcante e narrativas profundas.", new DateTime(1967, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 9, "George Lucas é o criador da saga Star Wars e fundador da Lucasfilm.", new DateTime(1944, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 10, "Francis Ford Coppola é um dos grandes diretores do cinema americano, conhecido por O Poderoso Chefão.", new DateTime(1939, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiretorDetalhe_DiretorId",
                table: "DiretorDetalhe",
                column: "DiretorId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiretorDetalhe");
        }
    }
}
