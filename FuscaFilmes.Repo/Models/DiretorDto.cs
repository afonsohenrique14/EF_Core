namespace FuscaFilmes.Repo.Models;

public class DiretorDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public IEnumerable<FilmeDto> Filmes { get; set; } = [];
}

