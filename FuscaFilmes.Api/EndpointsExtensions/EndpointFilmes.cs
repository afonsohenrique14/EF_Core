using FuscaFilmes.Api.EnpointsHandlers;

namespace FuscaFilmes.Api.EnpointsExtensions;

public static class EndpointFilmes
{
    
    public static void FilmesEndpoints( this IEndpointRouteBuilder app)
    {
        // HANDLERS DIRETORES

        app.MapGet("/filmes", FilmesHandlers.GetFilmes);

        app.MapGet("/filmes/{id}", FilmesHandlers.GetFilmeById );

        app.MapGet("/filmesEFFunctions/byName/{titulo}", FilmesHandlers.GetFilmeByName);

        app.MapGet("/filmesLinQ/byName/{titulo}", FilmesHandlers.GetFilmeByNameLinq );

        app.MapPatch("/filmesUpdate", FilmesHandlers.PatchFilmeWithTRack );

        app.MapPatch("/filmes", FilmesHandlers.PatchFilme );

        app.MapDelete("/filmes/{Id}", FilmesHandlers.DeleteFilme);
    }


}
