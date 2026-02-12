using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.Contratos;
using FuscaFilmes.Repo.Models;

namespace FuscaFilmes.Api.EnpointsHandlers;

public static class FilmesHandlers
{
    public static Task<IEnumerable<FilmeDto>> GetFilmesAsync(IFilmeRepository repositoryFilmes)
    {
        return  repositoryFilmes.GetFilmesAsync();
    }

    public static Task<IEnumerable<FilmeDto>> GetFilmeByIdAsync(IFilmeRepository repositoryFilmes, int id)
    {
         return repositoryFilmes.GetFilmeByIdAsync(id);
    }

    public static Task<IEnumerable<FilmeDto>> GetFilmeByNameAsync(IFilmeRepository repositoryFilmes, string titulo)
    {
       return repositoryFilmes.GetFilmeByNameAsync(titulo);
    }

    public static Task<IEnumerable<FilmeDto>> GetFilmeByNameLinqAsync(IFilmeRepository repositoryFilmes, string titulo) 
    {
        return repositoryFilmes.GetFilmeByNameLinqAsync(titulo);

    }

    public static async Task<IResult> PatchFilmeWithTRackAsync(IFilmeRepository repositoryFilmes, FilmeUpdate filmeUpdate)
    {

        Filme? filme = await repositoryFilmes.PatchFilmeWithTRackAsync(filmeUpdate); 

        if (filme == null)
        {
            return Results.NotFound( new{ message = "Filme não encontrado"});
        }

        await repositoryFilmes.SaveChangesAsync();

        return Results.Ok( new{ message = $"Filme com Id {filmeUpdate.Id} foi atualizado com sucesso."});

    }

    public static async Task<IResult> PatchFilmeAsync(IFilmeRepository repositoryFilmes, FilmeUpdate filmeUpdate)
    {
        var affectedRows = await repositoryFilmes.PatchFilmeAsync(filmeUpdate);

        if(affectedRows > 0)
        {
            return Results.Ok( new{ message = $"Você tem um total de {affectedRows} linha(s) afetada(s)."});
        }
        else
        {
            return Results.NoContent();   
        }

    }


    public static void DeleteFilmeAsync(IFilmeRepository repositoryFilmes, int Id)
    {
        repositoryFilmes.DeleteFilmeAsync(Id);

    }

}
