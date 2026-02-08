using FuscaFilmes.Api.EnpointsHandlers;

namespace FuscaFilmes.Api.EnpointsExtensions;

public static class EndpointDiretores
{
    public static void DiretoresEndpoints( this IEndpointRouteBuilder app)
    {
        // HANDLERS DIRETORES

        app.MapGet("/diretores", DiretoresHandlers.GetDiretores);

        app.MapGet("/diretores/{id}", DiretoresHandlers.GetDiretorById );

        app.MapGet("/diretores/agregacao/{name}", DiretoresHandlers.GetDiretorByName);

        app.MapGet("/diretores/where/{id}", DiretoresHandlers.GetDiretorWhere);

        app.MapPost("/diretores", DiretoresHandlers.PostDiretor);

        app.MapPut("/diretores", DiretoresHandlers.PutDiretor);

        app.MapDelete("/diretores/{Id}", DiretoresHandlers.DeleteDiretor);

    }
    

}
