
using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.Models;

namespace FuscaFilmes.Repo.Contratos;

public interface IDiretorRepository
{
    Task AddAsync(Diretor diretor);
    Task UpdateAsync(Diretor diretor);
    Task DeleteAsync(int diretorId);

    Task<IEnumerable<DiretorDto>> GetDiretoresAsync();

    Task<IEnumerable<DiretorDto>> GetDiretorByIdAsync(int id);
    
    Task<IEnumerable<DiretorDto>> GetDiretorWhereAsync(int id);

    Task<Diretor> GetDiretorByNameAsync(string name);
    Task<bool> SaveChangesAsync();
}
