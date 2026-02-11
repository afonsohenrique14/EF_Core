using System;
using FuscaFilmes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.Repo.Contexts;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Filme> Filmes {get; set;}
    public DbSet<Diretor> Diretores {get; set;}

    public DbSet<DiretorFilme> DiretoresFilmes { get; set; }

    // public DbSet<DiretorDetalhe> DiretorDetalhes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Diretor>()
            .HasMany(e => e.Filmes)
            .WithMany(f => f.Diretores)
            .UsingEntity<DiretorFilme>(
                df => df.HasOne(e => e.Filme)
                        .WithMany(e => e.DiretoresFilmes)
                        .HasForeignKey(e => e.FilmeId),
        
                df => df.HasOne(e => e.Diretor)
                        .WithMany(e => e.DiretoresFilmes)
                        .HasForeignKey(e => e.DiretorId),
                df =>
                {
                    df.HasKey( e=> new { e.DiretorId, e.FilmeId});
                    df.ToTable("DiretoresFilmes");
                }
            );

        modelBuilder.Entity<Diretor>()
            .HasOne(d =>d.DiretorDetalhe)
            .WithOne(d => d.Diretor)
            .HasForeignKey<DiretorDetalhe>(dd => dd.DiretorId);

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

            modelBuilder.Entity<DiretorDetalhe>().HasData(
                new DiretorDetalhe {
                    Id = 1,
                    DiretorId = 1,
                    Biografia = "Christopher Nolan é um cineasta britânico-americano conhecido por narrativas complexas e visuais inovadores.",
                    DataNascimento = new DateTime(1970, 7, 30)
                },
                new DiretorDetalhe {
                    Id = 2,
                    DiretorId = 2,
                    Biografia = "Steven Spielberg é um dos diretores mais influentes da história, responsável por clássicos do cinema moderno.",
                    DataNascimento = new DateTime(1946, 12, 18)
                },
                new DiretorDetalhe {
                    Id = 3,
                    DiretorId = 3,
                    Biografia = "Quentin Tarantino é conhecido por seu estilo único, diálogos marcantes e narrativas não lineares.",
                    DataNascimento = new DateTime(1963, 3, 27)
                },
                new DiretorDetalhe {
                    Id = 4,
                    DiretorId = 4,
                    Biografia = "Martin Scorsese é um dos maiores diretores americanos, famoso por filmes sobre crime e personagens complexos.",
                    DataNascimento = new DateTime(1942, 11, 17)
                },
                new DiretorDetalhe {
                    Id = 5,
                    DiretorId = 5,
                    Biografia = "James Cameron é conhecido por grandes produções e inovações tecnológicas no cinema.",
                    DataNascimento = new DateTime(1954, 8, 16)
                },
                new DiretorDetalhe {
                    Id = 6,
                    DiretorId = 6,
                    Biografia = "Ridley Scott é um diretor britânico renomado por obras de ficção científica e épicos visuais.",
                    DataNascimento = new DateTime(1937, 11, 30)
                },
                new DiretorDetalhe {
                    Id = 7,
                    DiretorId = 7,
                    Biografia = "Peter Jackson ganhou destaque mundial com a trilogia O Senhor dos Anéis.",
                    DataNascimento = new DateTime(1961, 10, 31)
                },
                new DiretorDetalhe {
                    Id = 8,
                    DiretorId = 8,
                    Biografia = "Denis Villeneuve é conhecido por sua estética visual marcante e narrativas profundas.",
                    DataNascimento = new DateTime(1967, 10, 3)
                },
                new DiretorDetalhe {
                    Id = 9,
                    DiretorId = 9,
                    Biografia = "George Lucas é o criador da saga Star Wars e fundador da Lucasfilm.",
                    DataNascimento = new DateTime(1944, 5, 14)
                },
                new DiretorDetalhe {
                    Id = 10,
                    DiretorId = 10,
                    Biografia = "Francis Ford Coppola é um dos grandes diretores do cinema americano, conhecido por O Poderoso Chefão.",
                    DataNascimento = new DateTime(1939, 4, 7)
                }
            );
            
        modelBuilder.Entity<Filme>()
            .HasData(
                // Nolan
                new Filme { Id = 1,  Titulo = "Inception", Ano = 2010 },
                new Filme { Id = 2,  Titulo = "Interstellar", Ano = 2014 },
                new Filme { Id = 3,  Titulo = "The Dark Knight", Ano = 2008 },
                new Filme { Id = 4,  Titulo = "Dunkirk", Ano = 2017 },

                // Spielberg
                new Filme { Id = 5,  Titulo = "Jurassic Park", Ano = 1993 },
                new Filme { Id = 6,  Titulo = "E.T. - O Extraterrestre", Ano = 1982 },
                new Filme { Id = 7,  Titulo = "Indiana Jones e Os Caçadores da Arca Perdida", Ano = 1981 },
                new Filme { Id = 8,  Titulo = "O Resgate do Soldado Ryan", Ano = 1998 },

                // Tarantino
                new Filme { Id = 9,  Titulo = "Pulp Fiction", Ano = 1994 },
                new Filme { Id = 10, Titulo = "Kill Bill: Volume 1", Ano = 2003 },
                new Filme { Id = 11, Titulo = "Bastardos Inglórios", Ano = 2009 },
                new Filme { Id = 12, Titulo = "Django Livre", Ano = 2012 },

                // Scorsese
                new Filme { Id = 13, Titulo = "Os Bons Companheiros", Ano = 1990 },
                new Filme { Id = 14, Titulo = "O Lobo de Wall Street", Ano = 2013 },
                new Filme { Id = 15, Titulo = "Taxi Driver", Ano = 1976 },
                new Filme { Id = 16, Titulo = "Ilha do Medo", Ano = 2010 },

                // Cameron
                new Filme { Id = 17, Titulo = "Avatar", Ano = 2009 },
                new Filme { Id = 18, Titulo = "Titanic", Ano = 1997 },
                new Filme { Id = 19, Titulo = "O Exterminador do Futuro 2", Ano = 1991 },

                // Ridley Scott
                new Filme { Id = 20, Titulo = "Gladiador", Ano = 2000 },
                new Filme { Id = 21, Titulo = "Alien: O Oitavo Passageiro", Ano = 1979 },
                new Filme { Id = 22, Titulo = "Blade Runner", Ano = 1982 },

                // Peter Jackson
                new Filme { Id = 23, Titulo = "O Senhor dos Anéis: A Sociedade do Anel", Ano = 2001 },
                new Filme { Id = 24, Titulo = "O Senhor dos Anéis: As Duas Torres", Ano = 2002 },
                new Filme { Id = 25, Titulo = "O Senhor dos Anéis: O Retorno do Rei", Ano = 2003 },

                // Denis Villeneuve
                new Filme { Id = 26, Titulo = "A Chegada", Ano = 2016 },
                new Filme { Id = 27, Titulo = "Blade Runner 2049", Ano = 2017 },
                new Filme { Id = 28, Titulo = "Duna", Ano = 2021 },

                // George Lucas
                new Filme { Id = 29, Titulo = "Star Wars: Episódio IV – Uma Nova Esperança", Ano = 1977 },
                new Filme { Id = 30, Titulo = "Star Wars: Episódio I – A Ameaça Fantasma", Ano = 1999 },

                // Coppola
                new Filme { Id = 31, Titulo = "O Poderoso Chefão", Ano = 1972 },
                new Filme { Id = 32, Titulo = "O Poderoso Chefão II", Ano = 1974 },
                new Filme { Id = 33, Titulo = "Apocalypse Now", Ano = 1979 }
            );


            //PODE FALHAR: 
            modelBuilder.Entity<DiretorFilme>()
            .HasData(

                new {DiretorId = 1, FilmeId = 1},
                new {DiretorId = 1, FilmeId = 2},
                new {DiretorId = 1, FilmeId = 3},
                new {DiretorId = 1, FilmeId = 4},
                new {DiretorId = 2, FilmeId = 5},
                new {DiretorId = 2, FilmeId = 6},
                new {DiretorId = 2, FilmeId = 7},
                new {DiretorId = 2, FilmeId = 8},
                new {DiretorId = 3, FilmeId = 9},
                new {DiretorId = 3, FilmeId = 10},
                new {DiretorId = 3, FilmeId = 11},
                new {DiretorId = 3, FilmeId = 12},
                new {DiretorId = 4, FilmeId = 13},
                new {DiretorId = 4, FilmeId = 14},
                new {DiretorId = 4, FilmeId = 15},
                new {DiretorId = 4, FilmeId = 16},
                new {DiretorId = 5, FilmeId = 17},
                new {DiretorId = 5, FilmeId = 18},
                new {DiretorId = 5, FilmeId = 19},
                new {DiretorId = 6, FilmeId = 20},
                new {DiretorId = 6, FilmeId = 21},
                new {DiretorId = 6, FilmeId = 22},
                new {DiretorId = 7, FilmeId = 23},
                new {DiretorId = 7, FilmeId = 24},
                new {DiretorId = 7, FilmeId = 25},
                new {DiretorId = 8, FilmeId = 26},
                new {DiretorId = 8, FilmeId = 27},
                new {DiretorId = 8, FilmeId = 28},
                new {DiretorId = 9, FilmeId = 29},
                new {DiretorId = 9, FilmeId = 30},
                new {DiretorId = 10, FilmeId = 31},
                new {DiretorId = 10, FilmeId = 32},
                new {DiretorId = 10, FilmeId = 33}
            );
    }

}
