
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

    public IEnumerable<FilmeDto> GetFilmeById(int id)
    {
        return Context.Filmes
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
            .ToList();
    }

    public IEnumerable<FilmeDto> GetFilmeByName(string titulo)
    {

        return Context.Filmes
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
            .ToList();

    }

    public IEnumerable<FilmeDto> GetFilmeByNameLinq(string titulo)
    {
        return Context.Filmes
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
            .ToList();

    }

    public IEnumerable<FilmeDto> GetFilmes()
    {
        return Context.Filmes
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
