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
        public void Atualizar(int id, Usuarios usuarioAtualizado)
        {
            Usuarios usuario = BuscarPorID(id);

            if (usuarioAtualizado.Email != null)
            {
                usuario.Email = usuarioAtualizado.Email;
            }
            else if (usuarioAtualizado.IdTipoUsuario != null)
            {
                usuario.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
            }
            else if (usuarioAtualizado.Senha != null)
            {
                usuario.Senha = usuarioAtualizado.Senha;
            }
        }

        //LOGIN
        public Usuarios BuscarPorEmailSenha(string email, string senha)
        {
            Usuarios usuario = new Usuarios();
            List<Usuarios> ListaDeUsuarios = Listar();
            for (int i = 0; i < ListaDeUsuarios.Count; i++)
            {
                if (ListaDeUsuarios[i].Email == email)
                {
                    if (ListaDeUsuarios[i].Senha == senha)
                    {
                        usuario = ListaDeUsuarios[i];
                    }
                }
            }
            return usuario;

        }
    }


}
