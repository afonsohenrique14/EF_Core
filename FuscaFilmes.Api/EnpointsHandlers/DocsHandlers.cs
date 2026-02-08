using System;

namespace FuscaFilmes.Api.EnpointsHandlers;

public static class DocsHandlers
{
    public static IResult GetDocs()
    {
        return Results.Redirect("/swagger/v1/swagger.json");
    }
}
