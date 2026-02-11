using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FuscaFilmes.Repo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diretores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diretores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    Ano = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiretoresFilmes",
                columns: table => new
                {
                    DiretorId = table.Column<int>(type: "INTEGER", nullable: false),
                    FilmeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiretoresFilmes", x => new { x.DiretorId, x.FilmeId });
                    table.ForeignKey(
                        name: "FK_DiretoresFilmes_Diretores_DiretorId",
                        column: x => x.DiretorId,
                        principalTable: "Diretores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiretoresFilmes_Filmes_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Diretores",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Christopher Nolan" },
                    { 2, "Steven Spielberg" },
                    { 3, "Quentin Tarantino" },
                    { 4, "Martin Scorsese" },
                    { 5, "James Cameron" },
                    { 6, "Ridley Scott" },
                    { 7, "Peter Jackson" },
                    { 8, "Denis Villeneuve" },
                    { 9, "George Lucas" },
                    { 10, "Francis Ford Coppola" }
                });

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "Id", "Ano", "Titulo" },
                values: new object[,]
                {
                    { 1, 2010, "Inception" },
                    { 2, 2014, "Interstellar" },
                    { 3, 2008, "The Dark Knight" },
                    { 4, 2017, "Dunkirk" },
                    { 5, 1993, "Jurassic Park" },
                    { 6, 1982, "E.T. - O Extraterrestre" },
                    { 7, 1981, "Indiana Jones e Os Caçadores da Arca Perdida" },
                    { 8, 1998, "O Resgate do Soldado Ryan" },
                    { 9, 1994, "Pulp Fiction" },
                    { 10, 2003, "Kill Bill: Volume 1" },
                    { 11, 2009, "Bastardos Inglórios" },
                    { 12, 2012, "Django Livre" },
                    { 13, 1990, "Os Bons Companheiros" },
                    { 14, 2013, "O Lobo de Wall Street" },
                    { 15, 1976, "Taxi Driver" },
                    { 16, 2010, "Ilha do Medo" },
                    { 17, 2009, "Avatar" },
                    { 18, 1997, "Titanic" },
                    { 19, 1991, "O Exterminador do Futuro 2" },
                    { 20, 2000, "Gladiador" },
                    { 21, 1979, "Alien: O Oitavo Passageiro" },
                    { 22, 1982, "Blade Runner" },
                    { 23, 2001, "O Senhor dos Anéis: A Sociedade do Anel" },
                    { 24, 2002, "O Senhor dos Anéis: As Duas Torres" },
                    { 25, 2003, "O Senhor dos Anéis: O Retorno do Rei" },
                    { 26, 2016, "A Chegada" },
                    { 27, 2017, "Blade Runner 2049" },
                    { 28, 2021, "Duna" },
                    { 29, 1977, "Star Wars: Episódio IV – Uma Nova Esperança" },
                    { 30, 1999, "Star Wars: Episódio I – A Ameaça Fantasma" },
                    { 31, 1972, "O Poderoso Chefão" },
                    { 32, 1974, "O Poderoso Chefão II" },
                    { 33, 1979, "Apocalypse Now" }
                });

            migrationBuilder.InsertData(
                table: "DiretoresFilmes",
                columns: new[] { "DiretorId", "FilmeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 3, 9 },
                    { 3, 10 },
                    { 3, 11 },
                    { 3, 12 },
                    { 4, 13 },
                    { 4, 14 },
                    { 4, 15 },
                    { 4, 16 },
                    { 5, 17 },
                    { 5, 18 },
                    { 5, 19 },
                    { 6, 20 },
                    { 6, 21 },
                    { 6, 22 },
                    { 7, 23 },
                    { 7, 24 },
                    { 7, 25 },
                    { 8, 26 },
                    { 8, 27 },
                    { 8, 28 },
                    { 9, 29 },
                    { 9, 30 },
                    { 10, 31 },
                    { 10, 32 },
                    { 10, 33 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiretoresFilmes_FilmeId",
                table: "DiretoresFilmes",
                column: "FilmeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiretoresFilmes");

            migrationBuilder.DropTable(
                name: "Diretores");

            migrationBuilder.DropTable(
                name: "Filmes");
        }
    }
}
