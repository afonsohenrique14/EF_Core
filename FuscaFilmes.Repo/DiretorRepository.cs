using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.Contexts;
using FuscaFilmes.Repo.Contratos;
using FuscaFilmes.Repo.Models;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.Repo;

public class DiretorRepository(Context _context) : IDiretorRepository
{

    public Context Context { get; } = _context;

    public async Task AddAsync(Diretor diretor)
    {
        await Context.AddAsync(diretor);
    }

    public async Task DeleteAsync(int Id)
    {
        var diretor = await Context.Diretores.FindAsync(Id);

        if (diretor != null)
            Context.Diretores.Remove(diretor);

    }

    public async Task UpdateAsync(Diretor diretorNovo)
    {

        var diretor = await Context.Diretores
            .Include(d => d.Filmes)
            .FirstOrDefaultAsync(d => d.Id == diretorNovo.Id);

        if (diretor != null)
        {
            diretor.Name = diretorNovo.Name;

            diretor.Filmes.Clear();

            foreach (var filmeNovo in diretorNovo.Filmes)
            {
                Filme? filme;

                if (filmeNovo.Id != 0)
                {
                    // Buscar o filme existente
                    filme = await Context.Filmes.FindAsync(filmeNovo.Id);

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

                     await Context.Filmes.AddAsync(filme);
                }

                diretor.Filmes.Add(filme!);
            }

        }
    }

    public async Task<bool> SaveChangesAsync()
    {
       return (await Context.SaveChangesAsync()) > 0;
    }

    public async Task<IEnumerable<DiretorDto>> GetDiretoresAsync()
    {
        return await Context.Diretores
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
        .ToListAsync();
    }

    public async Task<IEnumerable<DiretorDto>> GetDiretorByIdAsync(int id)
    {
        return await Context.Diretores
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
        .ToListAsync();
    }

    public async Task<IEnumerable<DiretorDto>> GetDiretorWhereAsync(int id)
    {
        return await Context.Diretores
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
        .ToListAsync();
    }

    public async Task<Diretor> GetDiretorByNameAsync(string name)
    {
        return await Context.Diretores
            .Include(d => d.Filmes)
            .FirstOrDefaultAsync(d => d.Name.Contains(name)) 
            ?? new Diretor { Id = 5555, Name = "Marina" };
    }
}
