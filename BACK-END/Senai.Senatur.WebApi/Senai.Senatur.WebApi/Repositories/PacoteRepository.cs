using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class PacoteRepository : IPacoteRepository
    {
        SenaturContext ctx = new SenaturContext();

        //GET
        public List<PacoteDomain> Listar()
        {

            return ctx.Pacotes.ToList();
        }

        //GET
        public PacoteDomain BuscarPorID(int id)
        {
            return ctx.PacoteDomain.FirstOrDefault(p => p.IdPacote == id);
        }

        //POST
        public void Cadastrar(PacoteDomain pacote)
        {
            ctx.PacoteDomain.Add(pacote);
            ctx.SaveChanges();
        }

        //DELETE
        public void Deletar(int id)
        {
            ctx.PacoteDomain.Remove(BuscarPorID(id));
            ctx.SaveChanges();
        }
    }
}
