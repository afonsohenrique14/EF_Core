using System;
using FuscaFilmes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.Repo.Contexts;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Filme> Filmes {get; set;}
    public DbSet<Diretor> Diretores {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Diretor>()
            .HasMany(e => e.Filmes)
            .WithOne(e => e.Diretor)
            .HasForeignKey(e =>e.DiretorId)
            .IsRequired();

        modelBuilder.Entity<Diretor>()
            .HasData(
                new Diretor { Id = 1, Name = "Christopher Nolan" },
                new Diretor { Id = 2, Name = "Steven Spielberg" },
                new Diretor { Id = 3, Name = "Quentin Tarantino" },
                new Diretor { Id = 4, Name = "Martin Scorsese" },
                new Diretor { Id = 5, Name = "James Cameron" },
                new Diretor { Id = 6, Name = "Ridley Scott" },
                new Diretor { Id = 7, Name = "Peter Jackson" },
                new Diretor { Id = 8, Name = "Denis Villeneuve" },
                new Diretor { Id = 9, Name = "George Lucas" },
                new Diretor { Id = 10, Name = "Francis Ford Coppola" }
            );
            
        modelBuilder.Entity<Filme>()
            .HasData(
                // Nolan
                new Filme { Id = 1,  Titulo = "Inception", Ano = 2010, DiretorId = 1 },
                new Filme { Id = 2,  Titulo = "Interstellar", Ano = 2014, DiretorId = 1 },
                new Filme { Id = 3,  Titulo = "The Dark Knight", Ano = 2008, DiretorId = 1 },
                new Filme { Id = 4,  Titulo = "Dunkirk", Ano = 2017, DiretorId = 1 },

                // Spielberg
                new Filme { Id = 5,  Titulo = "Jurassic Park", Ano = 1993, DiretorId = 2 },
                new Filme { Id = 6,  Titulo = "E.T. - O Extraterrestre", Ano = 1982, DiretorId = 2 },
                new Filme { Id = 7,  Titulo = "Indiana Jones e Os Caçadores da Arca Perdida", Ano = 1981, DiretorId = 2 },
                new Filme { Id = 8,  Titulo = "O Resgate do Soldado Ryan", Ano = 1998, DiretorId = 2 },

                // Tarantino
                new Filme { Id = 9,  Titulo = "Pulp Fiction", Ano = 1994, DiretorId = 3 },
                new Filme { Id = 10, Titulo = "Kill Bill: Volume 1", Ano = 2003, DiretorId = 3 },
                new Filme { Id = 11, Titulo = "Bastardos Inglórios", Ano = 2009, DiretorId = 3 },
                new Filme { Id = 12, Titulo = "Django Livre", Ano = 2012, DiretorId = 3 },

                // Scorsese
                new Filme { Id = 13, Titulo = "Os Bons Companheiros", Ano = 1990, DiretorId = 4 },
                new Filme { Id = 14, Titulo = "O Lobo de Wall Street", Ano = 2013, DiretorId = 4 },
                new Filme { Id = 15, Titulo = "Taxi Driver", Ano = 1976, DiretorId = 4 },
                new Filme { Id = 16, Titulo = "Ilha do Medo", Ano = 2010, DiretorId = 4 },

                // Cameron
                new Filme { Id = 17, Titulo = "Avatar", Ano = 2009, DiretorId = 5 },
                new Filme { Id = 18, Titulo = "Titanic", Ano = 1997, DiretorId = 5 },
                new Filme { Id = 19, Titulo = "O Exterminador do Futuro 2", Ano = 1991, DiretorId = 5 },

                // Ridley Scott
                new Filme { Id = 20, Titulo = "Gladiador", Ano = 2000, DiretorId = 6 },
                new Filme { Id = 21, Titulo = "Alien: O Oitavo Passageiro", Ano = 1979, DiretorId = 6 },
                new Filme { Id = 22, Titulo = "Blade Runner", Ano = 1982, DiretorId = 6 },

                // Peter Jackson
                new Filme { Id = 23, Titulo = "O Senhor dos Anéis: A Sociedade do Anel", Ano = 2001, DiretorId = 7 },
                new Filme { Id = 24, Titulo = "O Senhor dos Anéis: As Duas Torres", Ano = 2002, DiretorId = 7 },
                new Filme { Id = 25, Titulo = "O Senhor dos Anéis: O Retorno do Rei", Ano = 2003, DiretorId = 7 },

                // Denis Villeneuve
                new Filme { Id = 26, Titulo = "A Chegada", Ano = 2016, DiretorId = 8 },
                new Filme { Id = 27, Titulo = "Blade Runner 2049", Ano = 2017, DiretorId = 8 },
                new Filme { Id = 28, Titulo = "Duna", Ano = 2021, DiretorId = 8 },

                // George Lucas
                new Filme { Id = 29, Titulo = "Star Wars: Episódio IV – Uma Nova Esperança", Ano = 1977, DiretorId = 9 },
                new Filme { Id = 30, Titulo = "Star Wars: Episódio I – A Ameaça Fantasma", Ano = 1999, DiretorId = 9 },

                // Coppola
                new Filme { Id = 31, Titulo = "O Poderoso Chefão", Ano = 1972, DiretorId = 10 },
                new Filme { Id = 32, Titulo = "O Poderoso Chefão II", Ano = 1974, DiretorId = 10 },
                new Filme { Id = 33, Titulo = "Apocalypse Now", Ano = 1979, DiretorId = 10 }
            );
    }

}
