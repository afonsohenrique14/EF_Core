
using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.Contexts;
using FuscaFilmes.Repo.Contratos;
using FuscaFilmes.Repo.Models;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.Repo;

public class FilmeRepository(Context _context) : IFilmeRepository
{   

    Context Context {get;} = _context;

    public async Task<IEnumerable<FilmeDto>> GetFilmesAsync()
    {
        return await Context.Filmes
            .Include(f=> f.Diretores)
            .OrderByDescending(f => f.Ano)
            .ThenBy(f => f.Titulo)
            .Select(f=> new FilmeDto
                {
                    Id = f.Id,
                    Titulo = f.Titulo,
                    Ano = f.Ano,
                    Diretores = f.Diretores.Select(
                        d=> new DiretorDto
                            {
                                Id = d.Id,
                                Name = d.Name

                            }
                    )
                }
            )
            .ToListAsync();
    }



    public async Task<IEnumerable<FilmeDto>> GetFilmeByIdAsync(int id)
    {
        return await Context.Filmes
            .Where(f => f.Id == id)
            .Select(f=> new FilmeDto
                {
                    Id = f.Id,
                    Titulo = f.Titulo,
                    Ano = f.Ano,
                    Diretores = f.Diretores.Select(
                        d=> new DiretorDto
                            {
                                Id = d.Id,
                                Name = d.Name

                            }
                    )
                }
            )
            .ToListAsync();
    }

    public async Task<IEnumerable<FilmeDto>> GetFilmeByNameAsync(string titulo)
    {

        return await Context.Filmes
            .Include(f => f.Diretores)
            .Where(f =>
                EF.Functions.Like(f.Titulo, $"%{titulo}%")
            )
            .Select(f=> new FilmeDto
                {
                    Id = f.Id,
                    Titulo = f.Titulo,
                    Ano = f.Ano,
                    Diretores = f.Diretores.Select(
                        d=> new DiretorDto
                            {
                                Id = d.Id,
                                Name = d.Name

                            }
                    )
                }
            )
            .ToListAsync();

    }

    public async Task<IEnumerable<FilmeDto>> GetFilmeByNameLinqAsync(string titulo)
    {
        return await Context.Filmes
            .Include(f => f.Diretores)
            .Where(f => f.Titulo.ToUpper().Contains(titulo.ToUpper()))
            .Select(f=> new FilmeDto
                {
                    Id = f.Id,
                    Titulo = f.Titulo,
                    Ano = f.Ano,
                    Diretores = f.Diretores.Select(
                        d=> new DiretorDto
                            {
                                Id = d.Id,
                                Name = d.Name

                            }
                    )
                }
            )
            .ToListAsync();

    }

    

    public async Task<int> PatchFilmeAsync(FilmeUpdate filmeUpdate)
    {
        return await Context.Filmes
            .Where(f => f.Id == filmeUpdate.Id)
            .ExecuteUpdateAsync(setter => setter
                .SetProperty(f => f.Titulo, filmeUpdate.Titulo)
                .SetProperty(f => f.Ano, filmeUpdate.Ano)
            );
    }

    public async Task<Filme?> PatchFilmeWithTRackAsync(FilmeUpdate filmeUpdate)
    {
        var filme = await Context.Filmes.FindAsync(filmeUpdate.Id);

        if (filme != null)
        {
            filme.Titulo = filmeUpdate.Titulo;
            filme.Ano = filmeUpdate.Ano;
            Context.Filmes.Update(filme);
        }

        return filme;

    }

    public async Task DeleteFilmeAsync(int Id)
    {
        await Context.Filmes
            .Where(f => f.Id == Id)
            .ExecuteDeleteAsync();

    }

    public async Task<bool> SaveChangesAsync()
    {
       return (await Context.SaveChangesAsync()) > 0;
    }

}
