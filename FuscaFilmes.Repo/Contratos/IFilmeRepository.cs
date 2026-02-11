using System;
using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.Models;

namespace FuscaFilmes.Repo.Contratos;

public interface IFilmeRepository
{
   IEnumerable<FilmeDto> GetFilmes();
   IEnumerable<FilmeDto> GetFilmeById(int id);
   IEnumerable<FilmeDto> GetFilmeByName(string titulo);
   IEnumerable<FilmeDto> GetFilmeByNameLinq(string titulo);
   Filme? PatchFilmeWithTRack(FilmeUpdate filmeUpdate);
   int PatchFilme(FilmeUpdate filmeUpdate);
   void DeleteFilme(int Id);

   bool SaveChanges();
}

