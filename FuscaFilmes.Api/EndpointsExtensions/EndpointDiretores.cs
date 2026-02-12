using FuscaFilmes.Api.EnpointsHandlers;

namespace FuscaFilmes.Api.EnpointsExtensions;

public static class EndpointDiretores
{
    public static void DiretoresEndpoints( this IEndpointRouteBuilder app)
    {
        // HANDLERS DIRETORES

        app.MapGet("/diretores", DiretoresHandlers.GetDiretoresAsync);

        app.MapGet("/diretores/{id}", DiretoresHandlers.GetDiretorByIdAsync );

        app.MapGet("/diretores/agregacao/{name}", DiretoresHandlers.GetDiretorByNameAsync);

        app.MapGet("/diretores/where/{id}", DiretoresHandlers.GetDiretorWhereAsync);

        app.MapPost("/diretores", DiretoresHandlers.PostDiretorAsync);

        app.MapPut("/diretores", DiretoresHandlers.PutDiretorAsync);

        app.MapDelete("/diretores/{Id}", DiretoresHandlers.DeleteDiretorAsync);

    }
    

}
