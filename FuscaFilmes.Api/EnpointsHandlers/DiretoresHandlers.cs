
using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.Contratos;
using FuscaFilmes.Repo.Models;

namespace FuscaFilmes.Api.EnpointsHandlers;

public static class DiretoresHandlers
{
    public static IEnumerable<DiretorDto> GetDiretores(IDiretorRepository diretorRepository)
    {
        return diretorRepository.GetDiretores();
    }
    public static IEnumerable<DiretorDto> GetDiretorById(int id, IDiretorRepository diretorRepository)
    {
        return diretorRepository.GetDiretorById(id);
    }
    public static IEnumerable<DiretorDto> GetDiretorWhere(int id, IDiretorRepository diretorRepository)
    {
        return diretorRepository.GetDiretorWhere(id);
    }

    public static Diretor GetDiretorByName(string name, IDiretorRepository diretorRepository)
    {
        return diretorRepository.GetDiretorByName(name);
    }

    public static void PostDiretor(IDiretorRepository diretorRepository, Diretor diretor)
    {
        diretorRepository.Add(diretor);
        diretorRepository.SaveChanges();
    }

    public static void PutDiretor(IDiretorRepository diretorRepository, Diretor diretorNovo)
    {

        diretorRepository.Update(diretorNovo);
        diretorRepository.SaveChanges();
    }

    public static void DeleteDiretor(IDiretorRepository diretorRepository, int Id)
    {
        diretorRepository.Delete(Id);
        diretorRepository.SaveChanges();

    }

}
