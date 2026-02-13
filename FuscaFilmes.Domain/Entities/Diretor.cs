using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuscaFilmes.Domain.Entities;

public class Diretor
{
    [Key]
    // [Column("id_diretor")] // mapeando para coluna com outro nome no bd
    public int Id { get; set; }

    public required string Name { get; set; }

    public ICollection<DiretorFilme> DiretoresFilmes { get; set; } = null!;

    public ICollection<Filme> Filmes { get; set; } = [];

    public DiretorDetalhe? DiretorDetalhe {get; set;} 
}
