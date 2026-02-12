using System;
using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.Models;

namespace FuscaFilmes.Repo.Contratos;

public interface IFilmeRepository
{
   Task<IEnumerable<FilmeDto>> GetFilmesAsync();
   Task<IEnumerable<FilmeDto>> GetFilmeByIdAsync(int id);
   Task<IEnumerable<FilmeDto>> GetFilmeByNameAsync(string titulo);
   Task<IEnumerable<FilmeDto>> GetFilmeByNameLinqAsync(string titulo);
   Task<Filme?> PatchFilmeWithTRackAsync(FilmeUpdate filmeUpdate);
   Task<int> PatchFilmeAsync(FilmeUpdate filmeUpdate);
   Task DeleteFilmeAsync(int Id);

   Task<bool> SaveChangesAsync();
}

