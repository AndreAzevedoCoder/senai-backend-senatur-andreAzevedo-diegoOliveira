using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        SenaturContext context = new SenaturContext();
        public List<TiposUsuario> Listar()
        {
            List<TiposUsuario> Tipos = context.TiposUsuario.ToList();
            return Tipos;
        }

        public TiposUsuario BuscarPorID(int Id)
        {
            TiposUsuario Tipo = context.TiposUsuario.FirstOrDefault(e => e.IdTipoUsuario == Id);
            return Tipo;
        }

        public void Cadastrar(TiposUsuario novoTipo)
        {
            context.TiposUsuario.Add(novoTipo);
            context.SaveChanges();
        }

        public void Deletar(int Id)
        {
            context.TiposUsuario.Remove(BuscarPorID(Id));
            context.SaveChanges();
        }

        public void Atualizar(int Id, TiposUsuario tipoAtualizado)
        {
            TiposUsuario Tipo = BuscarPorID(Id);
            if(tipoAtualizado.NomeTipo != null)
            {
                Tipo.NomeTipo = tipoAtualizado.NomeTipo;
            }

            context.SaveChanges();
        }
    }
}
