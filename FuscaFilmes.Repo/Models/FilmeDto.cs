using System;

namespace FuscaFilmes.Repo.Models;

public class FilmeDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = null!;
    public int Ano { get; set; }

    public IEnumerable<DiretorDto> Diretores {get; set;} = [];
}

