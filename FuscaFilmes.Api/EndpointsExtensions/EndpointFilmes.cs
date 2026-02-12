using FuscaFilmes.Api.EnpointsHandlers;

namespace FuscaFilmes.Api.EnpointsExtensions;

public static class EndpointFilmes
{
    
    public static void FilmesEndpoints( this IEndpointRouteBuilder app)
    {
        // HANDLERS DIRETORES

        app.MapGet("/filmes", FilmesHandlers.GetFilmesAsync);

        app.MapGet("/filmes/{id}", FilmesHandlers.GetFilmeByIdAsync );

        app.MapGet("/filmesEFFunctions/byName/{titulo}", FilmesHandlers.GetFilmeByNameAsync);

        app.MapGet("/filmesLinQ/byName/{titulo}", FilmesHandlers.GetFilmeByNameLinqAsync );

        app.MapPatch("/filmesUpdate", FilmesHandlers.PatchFilmeWithTRackAsync );

        app.MapPatch("/filmes", FilmesHandlers.PatchFilmeAsync );

        app.MapDelete("/filmes/{Id}", FilmesHandlers.DeleteFilmeAsync);
    }


}
