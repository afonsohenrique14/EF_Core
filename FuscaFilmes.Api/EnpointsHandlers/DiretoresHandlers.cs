
using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.Contratos;
using FuscaFilmes.Repo.Models;

namespace FuscaFilmes.Api.EnpointsHandlers;

public static class DiretoresHandlers
{
    public static async Task<IEnumerable<DiretorDto>> GetDiretoresAsync(IDiretorRepository diretorRepository)
    {
        return await diretorRepository.GetDiretoresAsync();
    }
    public static async Task<IEnumerable<DiretorDto>> GetDiretorByIdAsync(int id, IDiretorRepository diretorRepository)
    {
        return await diretorRepository.GetDiretorByIdAsync(id);
    }
    public static async Task<IEnumerable<DiretorDto>> GetDiretorWhereAsync(int id, IDiretorRepository diretorRepository)
    {
        return await diretorRepository.GetDiretorWhereAsync(id);
    }

    public static async Task<Diretor> GetDiretorByNameAsync(string name, IDiretorRepository diretorRepository)
    {
        return await diretorRepository.GetDiretorByNameAsync(name);
    }

    public static async Task PostDiretorAsync(IDiretorRepository diretorRepository, Diretor diretor)
    {
        await diretorRepository.AddAsync(diretor);
        await diretorRepository.SaveChangesAsync();
    }

    public static async Task PutDiretorAsync(IDiretorRepository diretorRepository, Diretor diretorNovo)
    {

        await diretorRepository.UpdateAsync(diretorNovo);
        await diretorRepository.SaveChangesAsync();
    }

    public static async Task DeleteDiretorAsync(IDiretorRepository diretorRepository, int Id)
    {
        await diretorRepository.DeleteAsync(Id);
        await diretorRepository.SaveChangesAsync();

    }

}
