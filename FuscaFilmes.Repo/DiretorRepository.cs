using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.Contexts;
using FuscaFilmes.Repo.Contratos;
using FuscaFilmes.Repo.Models;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.Repo;

public class DiretorRepository(Context _context) : IDiretorRepository
{

    public Context Context { get; } = _context;

    public void Add(Diretor diretor)
    {
        Context.Add(diretor);
    }

    public void Delete(int Id)
    {
        var diretor = Context.Diretores.Find(Id);

        if (diretor != null)
            Context.Diretores.Remove(diretor);

    }

    public void Update(Diretor diretorNovo)
    {

        var diretor = Context.Diretores
            .Include(d => d.Filmes)
            .FirstOrDefault(d => d.Id == diretorNovo.Id);

        if (diretor != null)
        {
            diretor.Name = diretorNovo.Name;

            diretor.Filmes.Clear();

            foreach (var filmeNovo in diretorNovo.Filmes)
            {
                Filme filme;

                if (filmeNovo.Id != 0)
                {
                    // Buscar o filme existente
                    filme = Context.Filmes.Find(filmeNovo.Id)!;

                    if (filme != null)
                    {
                        // Atualizar dados do filme
                        filme.Titulo = filmeNovo.Titulo;
                        filme.Ano = filmeNovo.Ano;
                    }
                }
                else
                {
                    // Criar novo filme
                    filme = new Filme
                    {
                        Titulo = filmeNovo.Titulo,
                        Ano = filmeNovo.Ano,
                        // DiretorId = diretorNovo.Id,
                    };

                    Context.Filmes.Add(filme);
                }

                diretor.Filmes.Add(filme!);
            }

        }
    }

    public bool SaveChanges()
    {
       return Context.SaveChanges() > 0;
    }

    public IEnumerable<DiretorDto> GetDiretores()
    {
        return Context.Diretores
        .Include(f => f.Filmes)
        .Select(d => new DiretorDto
        {
            Id = d.Id,
            Name = d.Name,
            Filmes = d.Filmes.Select(
                f => new FilmeDto
                {
                    Id = f.Id,
                    Titulo = f.Titulo,
                    Ano = f.Ano
                }
            ).ToList()
        })
        .ToList();
    }

    public IEnumerable<DiretorDto> GetDiretorById(int id)
    {
        return Context.Diretores
        .Include(f => f.Filmes)
        .Where( d => d.Id == id)
        .Select(d => new DiretorDto
        {
            Id = d.Id,
            Name = d.Name,
            Filmes = d.Filmes.Select(
                f => new FilmeDto
                {
                    Id = f.Id,
                    Titulo = f.Titulo,
                    Ano = f.Ano
                }
            ).ToList()
        })
        .ToList();
    }

    public IEnumerable<DiretorDto> GetDiretorWhere(int id)
    {
        return Context.Diretores
        .Include(f => f.Filmes)
        .Where( d => d.Id == id)
        .Select(d => new DiretorDto
        {
            Id = d.Id,
            Name = d.Name,
            Filmes = d.Filmes.Select(
                f => new FilmeDto
                {
                    Id = f.Id,
                    Titulo = f.Titulo,
                    Ano = f.Ano
                }
            ).ToList()
        })
        .ToList();
    }

    public Diretor GetDiretorByName(string name)
    {
        return Context.Diretores
            .Include(d => d.Filmes)
            .FirstOrDefault(d => d.Name.Contains(name)) 
            ?? new Diretor { Id = 5555, Name = "Marina" };
    }
}
