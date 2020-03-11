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
            Pacotes pacote = BuscarPorID(id);
            if (pacoteAtualizado.NomePacote != null)
            {
                pacote.NomePacote = pacoteAtualizado.NomePacote;
            }
            else if (pacoteAtualizado.Descricao != null)
            {
                pacote.Descricao = pacoteAtualizado.Descricao;
            }
            else if (pacoteAtualizado.DataIda != null)
            {
                pacote.DataIda = pacoteAtualizado.DataIda;
            }
            else if (pacoteAtualizado.DataVolta != null)
            {
                pacote.DataVolta = pacoteAtualizado.DataVolta;
            }
            else if (!pacoteAtualizado.Valor.Equals(null))
            {
                pacote.Valor = pacoteAtualizado.Valor;
            }
            else if (pacoteAtualizado.Ativo != null)
            {
                pacote.Ativo = pacote.Ativo;
            }
            else if (pacoteAtualizado.NomeCidade != null)
            {
                pacote.NomeCidade = pacoteAtualizado.NomeCidade;
            }

            ctx.SaveChanges();


        }
    }
}
