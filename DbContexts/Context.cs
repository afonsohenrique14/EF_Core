using System;
using FuscaFilmesApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmesApi.DbContexts;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Filme> Filmes {get; set;}
    public DbSet<Diretor> Diretores {get; set;}
    // protected override void OnConfiguring(DbContextOptionsBuilder options) 
    // => options.UseSqlite("Data Source=EFCoreConsole.db");

}
