
using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.Models;

namespace FuscaFilmes.Repo.Contratos;

public interface IDiretorRepository
{
    void Add(Diretor diretor);
    void Update(Diretor diretor);
    void Delete(int diretorId);

    IEnumerable<DiretorDto> GetDiretores();

    IEnumerable<DiretorDto> GetDiretorById(int id);
    
    IEnumerable<DiretorDto> GetDiretorWhere(int id);

    Diretor GetDiretorByName(string name);
    bool SaveChanges();
}
