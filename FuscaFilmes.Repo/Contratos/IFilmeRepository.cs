using System;
using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.Models;

namespace FuscaFilmes.Repo.Contratos;

public interface IFilmeRepository
{
   IEnumerable<Filme> GetFilmes();
   IEnumerable<Filme> GetFilmeById(int id);
   IEnumerable<Filme> GetFilmeByName(string titulo);
   IEnumerable<Filme> GetFilmeByNameLinq(string titulo);
   Filme? PatchFilmeWithTRack(FilmeUpdate filmeUpdate);
   int PatchFilme(FilmeUpdate filmeUpdate);
   void DeleteFilme(int Id);

   bool SaveChanges();
}

