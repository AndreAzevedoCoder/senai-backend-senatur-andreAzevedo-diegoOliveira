using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class UsuarioRepository : IUsuariosRepository
    {
        SenaturContext ctx = new SenaturContext();

        //GET
        public List<Usuarios> Listar()
        {

            return ctx.Usuarios.ToList();
        }

        //GET
        public Usuarios BuscarPorID(int id)
        {
            return ctx.Usuarios.FirstOrDefault(p => p.IdUsuario == id);
        }

        //POST
        public void Cadastrar(Usuarios pacote)
        {
            ctx.Usuarios.Add(pacote);
            ctx.SaveChanges();
        }

        //DELETE
        public void Deletar(int id)
        {
            ctx.Usuarios.Remove(BuscarPorID(id));
            ctx.SaveChanges();
        }

        //PUT
        
        public void Atualizar(int id, Usuarios pacoteAtualizado)
        {

        }
    }
}
