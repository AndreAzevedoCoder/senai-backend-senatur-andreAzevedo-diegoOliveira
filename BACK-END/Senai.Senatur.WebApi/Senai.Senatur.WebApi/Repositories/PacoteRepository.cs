using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class PacoteRepository : IPacotesRepository
    {
        SenaturContext ctx = new SenaturContext();

        //GET
        public List<Pacotes> Listar()
        {

            return ctx.Pacotes.ToList();
        }

        //GET
        public Pacotes BuscarPorID(int id)
        {
            return ctx.Pacotes.FirstOrDefault(p => p.IdPacote == id);
        }

        //POST
        public void Cadastrar(Pacotes pacote)
        {
            ctx.Pacotes.Add(pacote);
            ctx.SaveChanges();
        }

        //DELETE
        public void Deletar(int id)
        {
            ctx.Pacotes.Remove(BuscarPorID(id));
            ctx.SaveChanges();
        }

        //PUT
        
        public void Atualizar(int id, Pacotes pacoteAtualizado)
        {

        }
    }
}
