using System.Text.Json.Serialization;
using FuscaFilmes.Repo.Contexts;
using FuscaFilmes.Api.EnpointsExtensions;
using Microsoft.EntityFrameworkCore;
using FuscaFilmes.Repo.Contratos;
using FuscaFilmes.Repo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(
    options => options
        .UseSqlite(builder.Configuration["ConnectionStrings:FuscaFilmesStr"])
        .LogTo(Console.WriteLine, LogLevel.Information)
);

builder.Services.AddScoped<IDiretorRepository, DiretorRepository>();
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();

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

app.DiretoresEndpoints();
app.FilmesEndpoints();
app.DocsEndpoint();

app.Run();