using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FuscaFilmes.Repo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCraation : Migration
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
                    Ano = table.Column<int>(type: "INTEGER", nullable: false),
                    DiretorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filmes_Diretores_DiretorId",
                        column: x => x.DiretorId,
                        principalTable: "Diretores",
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
                columns: new[] { "Id", "Ano", "DiretorId", "Titulo" },
                values: new object[,]
                {
                    { 1, 2010, 1, "Inception" },
                    { 2, 2014, 1, "Interstellar" },
                    { 3, 2008, 1, "The Dark Knight" },
                    { 4, 2017, 1, "Dunkirk" },
                    { 5, 1993, 2, "Jurassic Park" },
                    { 6, 1982, 2, "E.T. - O Extraterrestre" },
                    { 7, 1981, 2, "Indiana Jones e Os Caçadores da Arca Perdida" },
                    { 8, 1998, 2, "O Resgate do Soldado Ryan" },
                    { 9, 1994, 3, "Pulp Fiction" },
                    { 10, 2003, 3, "Kill Bill: Volume 1" },
                    { 11, 2009, 3, "Bastardos Inglórios" },
                    { 12, 2012, 3, "Django Livre" },
                    { 13, 1990, 4, "Os Bons Companheiros" },
                    { 14, 2013, 4, "O Lobo de Wall Street" },
                    { 15, 1976, 4, "Taxi Driver" },
                    { 16, 2010, 4, "Ilha do Medo" },
                    { 17, 2009, 5, "Avatar" },
                    { 18, 1997, 5, "Titanic" },
                    { 19, 1991, 5, "O Exterminador do Futuro 2" },
                    { 20, 2000, 6, "Gladiador" },
                    { 21, 1979, 6, "Alien: O Oitavo Passageiro" },
                    { 22, 1982, 6, "Blade Runner" },
                    { 23, 2001, 7, "O Senhor dos Anéis: A Sociedade do Anel" },
                    { 24, 2002, 7, "O Senhor dos Anéis: As Duas Torres" },
                    { 25, 2003, 7, "O Senhor dos Anéis: O Retorno do Rei" },
                    { 26, 2016, 8, "A Chegada" },
                    { 27, 2017, 8, "Blade Runner 2049" },
                    { 28, 2021, 8, "Duna" },
                    { 29, 1977, 9, "Star Wars: Episódio IV – Uma Nova Esperança" },
                    { 30, 1999, 9, "Star Wars: Episódio I – A Ameaça Fantasma" },
                    { 31, 1972, 10, "O Poderoso Chefão" },
                    { 32, 1974, 10, "O Poderoso Chefão II" },
                    { 33, 1979, 10, "Apocalypse Now" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_DiretorId",
                table: "Filmes",
                column: "DiretorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmes");

            migrationBuilder.DropTable(
                name: "Diretores");
        }
    }
}
