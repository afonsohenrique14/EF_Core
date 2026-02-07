using System;
using System.Text.Json.Serialization;

namespace FuscaFilmesApi.Entities;

public class Filme
{
    public int Id { get; set; }

    public required string Titulo { get; set; }

    public int Ano { get; set; }

    public int DiretorId { get; set; }

    public required Diretor Diretor { get; set; }

}
