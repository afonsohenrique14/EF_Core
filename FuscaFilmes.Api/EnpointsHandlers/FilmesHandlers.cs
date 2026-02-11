using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.Contratos;
using FuscaFilmes.Repo.Models;

namespace FuscaFilmes.Api.EnpointsHandlers;

public static class FilmesHandlers
{
    public static IEnumerable<FilmeDto> GetFilmes(IFilmeRepository repositoryFilmes)
    {
        return  repositoryFilmes.GetFilmes();
    }

    public static IEnumerable<FilmeDto> GetFilmeById(IFilmeRepository repositoryFilmes, int id)
    {
         return repositoryFilmes.GetFilmeById(id);
    }

    public static IEnumerable<FilmeDto> GetFilmeByName(IFilmeRepository repositoryFilmes, string titulo)
    {
       return repositoryFilmes.GetFilmeByName(titulo);
    }

    public static IEnumerable<FilmeDto> GetFilmeByNameLinq(IFilmeRepository repositoryFilmes, string titulo) 
    {
        return repositoryFilmes.GetFilmeByNameLinq(titulo);

    }

    public static IResult PatchFilmeWithTRack(IFilmeRepository repositoryFilmes, FilmeUpdate filmeUpdate)
    {

        Filme? filme = repositoryFilmes.PatchFilmeWithTRack(filmeUpdate); 

        if (filme == null)
        {
            return Results.NotFound( new{ message = "Filme não encontrado"});
        }

        repositoryFilmes.SaveChanges();

        return Results.Ok( new{ message = $"Filme com Id {filmeUpdate.Id} foi atualizado com sucesso."});

    }

    public static IResult PatchFilme(IFilmeRepository repositoryFilmes, FilmeUpdate filmeUpdate)
    {
        var affectedRows = repositoryFilmes.PatchFilme(filmeUpdate);

        if(affectedRows > 0)
        {
            return Results.Ok( new{ message = $"Você tem um total de {affectedRows} linha(s) afetada(s)."});
        }
        else
        {
            return Results.NoContent();   
        }

    }


    public static void DeleteFilme(IFilmeRepository repositoryFilmes, int Id)
    {
        repositoryFilmes.DeleteFilme(Id);

    }

}
