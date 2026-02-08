
using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.Contexts;
using FuscaFilmes.Repo.Contratos;
using FuscaFilmes.Repo.Models;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.Repo;

public class FilmeRepository(Context _context) : IFilmeRepository
{   

    Context Context {get;} = _context;
    public void DeleteFilme(int Id)
    {
        Context.Filmes
            .Where(f => f.Id == Id)
            .ExecuteDelete();

    }

    public IEnumerable<Filme> GetFilmeById(int id)
    {
        return Context.Filmes
            .Where(f => f.Id == id)
            .ToList();
    }

    public IEnumerable<Filme> GetFilmeByName(string titulo)
    {

        return Context.Filmes
            .Include(f => f.Diretor)
            .Where(f =>
                EF.Functions.Like(f.Titulo, $"%{titulo}%")
            )
            .ToList();

    }

    public IEnumerable<Filme> GetFilmeByNameLinq(string titulo)
    {
        return Context.Filmes
            .Include(f => f.Diretor)
            .Where(f => f.Titulo.ToUpper().Contains(titulo.ToUpper()))
            .ToList();

    }

    public IEnumerable<Filme> GetFilmes()
    {
        return Context.Filmes
            .OrderByDescending(f => f.Ano)
            .ThenBy(f => f.Titulo)
            .ToList();
    }

    public int PatchFilme(FilmeUpdate filmeUpdate)
    {
        return Context.Filmes
            .Where(f => f.Id == filmeUpdate.Id)
            .ExecuteUpdate(setter => setter
                .SetProperty(f => f.Titulo, filmeUpdate.Titulo)
                .SetProperty(f => f.Ano, filmeUpdate.Ano)
            );
    }

    public Filme? PatchFilmeWithTRack(FilmeUpdate filmeUpdate)
    {
        var filme = Context.Filmes.Find(filmeUpdate.Id);

        if (filme != null)
        {
            filme.Titulo = filmeUpdate.Titulo;
            filme.Ano = filmeUpdate.Ano;
            Context.Filmes.Update(filme);
        }

        return filme;

    }


    public bool SaveChanges()
    {
       return Context.SaveChanges() > 0;
    }

}
