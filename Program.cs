using System.Text.Json.Serialization;
using FuscaFilmesApi.DbContexts;
using FuscaFilmesApi.Entities;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(
    options => options.UseSqlite(builder.Configuration["ConnectionStrings:FuscaFilmesStr"])
);

// using (var context = new Context())
// {
//     context.Database.EnsureCreated();
// }

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.AllowTrailingCommas = true;
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

// app.UseHttpsRedirection();

app.MapGet("/diretores", (Context context) =>
{
    return context.Diretores
    .Include(f=> f.Filmes)
    .ToList();
});



app.MapPost("/diretores", (Context context, Diretor diretor)  =>
{
    context.Add(diretor);
    context.SaveChanges();
    
});

app.MapPut("/diretores/{Id}", (Context context, int Id, Diretor diretorNovo) =>
{

    var diretor = context.Diretores
        .Include(d => d.Filmes)
        .FirstOrDefault(d => d.Id == Id);

    if (diretor != null)
    {
        diretor.Name = diretorNovo.Name;

        diretor.Filmes.Clear();

        foreach (var filmeNovo in diretorNovo.Filmes)
        {
            Filme filme;

            if (filmeNovo.Id != 0)
            {
                // Buscar o filme existente
                filme = context.Filmes.Find(filmeNovo.Id)!;

                if (filme != null)
                {
                    // Atualizar dados do filme
                    filme.Titulo = filmeNovo.Titulo;
                    filme.Ano = filmeNovo.Ano;
                }
            }
            else
            {
                // Criar novo filme
                filme = new Filme
                {
                    Titulo = filmeNovo.Titulo,
                    Ano = filmeNovo.Ano
                };

                context.Filmes.Add(filme);
            }

            diretor.Filmes.Add(filme!);
        }

        context.SaveChanges();
    }
});

app.MapDelete("/diretores/{Id}", (Context context, int Id) =>
{
    var diretor = context.Diretores.Find(Id);

    if (diretor !=null)
        context.Diretores.Remove(diretor);
    
    context.SaveChanges();
    
});






app.MapGet("/docs", () =>
{
    return Results.Redirect("/swagger/v1/swagger.json");
})
.WithName("SwaggerJson");

app.Run();

