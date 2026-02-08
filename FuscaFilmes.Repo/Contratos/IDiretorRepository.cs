using System;
using FuscaFilmes.Domain.Entities;

namespace FuscaFilmes.Repo.Contratos;

public interface IDiretorRepository
{
    void Add(Diretor diretor);
    void Update(Diretor diretor);
    void Delete(int diretorId);

    IEnumerable<Diretor> GetDiretores();

    IEnumerable<Diretor> GetDiretorById(int id);
    
    IEnumerable<Diretor> GetDiretorWhere(int id);

    Diretor GetDiretorByName(string name);
    bool SaveChanges();
}
