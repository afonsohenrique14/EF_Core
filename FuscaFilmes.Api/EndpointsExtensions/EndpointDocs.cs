using FuscaFilmes.Api.EnpointsHandlers;

namespace FuscaFilmes.Api.EnpointsExtensions;

public static class EndpointDocs
{
    public static void DocsEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/docs", DocsHandlers.GetDocs).WithName("SwaggerJson");
    }

}
