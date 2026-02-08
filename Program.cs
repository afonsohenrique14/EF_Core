using System.Text.Json.Serialization;
using FuscaFilmesApi.DbContexts;
using FuscaFilmesApi.Entities;
using FuscaFilmesApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(
    options => options
        .UseSqlite(builder.Configuration["ConnectionStrings:FuscaFilmesStr"])
        .LogTo(Console.WriteLine, LogLevel.Information)
);

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
    .Include(f => f.Filmes)
    .ToList();
});

app.MapGet("/diretores/{id}", (int id, Context context) =>
{
    return context.Diretores
    .Include(f => f.Filmes)
    .Where(d => d.Id == id)
    .ToList();
});

app.MapGet("/diretores/agregacao/{name}", (string name, Context context) =>
{
    var resultado = context.Diretores
        .Include(d => d.Filmes)
        .FirstOrDefault(d => d.Name.Contains(name));

    if (resultado == null)
        return Results.NotFound( new {message = "Diretor não encontrado"});

    return Results.Ok(resultado);
});

app.MapGet("/diretores/where/{id}", (int id, Context context) =>
{
    return context.Diretores
    .Include(f => f.Filmes)
    .Where(d => d.Id == id)
    .ToList();
});


app.MapGet("/filmes", (Context context) =>
{
    return context.Filmes
    .OrderByDescending(f => f.Ano)
    .ThenBy(f => f.Titulo)
    .Select(f => new
    {
        f.Id,
        f.Titulo,
        f.Ano,
        Diretor = f.Diretor.Name
    })
    .ToList();
});
app.MapGet("/filmes/{id}", (int id, Context context) =>
{
    return context.Filmes
    .Select(f => new
    {
        f.Id,
        f.Titulo,
        f.Ano,
        Diretor = f.Diretor.Name
    })
    .Where(f => f.Id == id)
    .ToList();
});

app.MapGet("/filmesEFFunctions/byName/{titulo}", (string titulo, Context context) =>
{

    return context.Filmes
        .Include(f => f.Diretor)
        .Where(f =>
            EF.Functions.Like(f.Titulo, $"%{titulo}%")
        )
        .ToList();

});
app.MapGet("/filmesLinQ/byName/{titulo}", (string titulo, Context context) =>
{
    return context.Filmes
    .Include(f => f.Diretor)
    .Where(f => f.Titulo.ToUpper().Contains(titulo.ToUpper()))
    .ToList();

});

app.MapPost("/diretores", (Context context, Diretor diretor) =>
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
                    Ano = filmeNovo.Ano,
                    DiretorId = diretorNovo.Id,
                };

                context.Filmes.Add(filme);
            }

            diretor.Filmes.Add(filme!);
        }

        context.SaveChanges();
    }
});

app.MapPatch("/filmesUpdate", (Context context, FilmeUpdate filmeUpdate) =>
{

    var filme = context.Filmes.Find(filmeUpdate.Id);

    if (filme == null)
    {
         return Results.NotFound( new{ message = "Filme não encontrado"});
    }

    filme.Titulo = filmeUpdate.Titulo;
    filme.Ano = filmeUpdate.Ano;

    context.Filmes.Update(filme);

    context.SaveChanges();

   return Results.Ok( new{ message = $"Filme com Id {filmeUpdate.Id} foi atualizado com sucesso."});


});
app.MapPatch("/filmes", (Context context, FilmeUpdate filmeUpdate) =>
{
   var affectedRows = context.Filmes
        .Where(f => f.Id == filmeUpdate.Id)
        .ExecuteUpdate(setter => setter
            .SetProperty(f => f.Titulo, filmeUpdate.Titulo)
            .SetProperty(f => f.Ano, filmeUpdate.Ano)
        );

    if(affectedRows > 0)
    {
        return Results.Ok( new{ message = $"Você tem um total de {affectedRows} linha(s) afetada(s)."});
    }
    else
    {
        return Results.NoContent();   
    }


});

app.MapDelete("/filmes/{Id}", (Context context, int Id) =>
{
    context.Filmes
        .Where(f => f.Id == Id)
        .ExecuteDelete<Filme>();

});




app.MapDelete("/diretores/{Id}", (Context context, int Id) =>
{
    var diretor = context.Diretores.Find(Id);

    if (diretor != null)
        context.Diretores.Remove(diretor);

    context.SaveChanges();

});






app.MapGet("/docs", () =>
{
    return Results.Redirect("/swagger/v1/swagger.json");
})
.WithName("SwaggerJson");

app.Run();

