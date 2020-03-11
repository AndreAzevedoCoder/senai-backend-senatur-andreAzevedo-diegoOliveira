using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TiposUsuario> Listar();

        TiposUsuario BuscarPorID(int id);

        void Cadastrar(TiposUsuario novoTipo);

        void Deletar(int id);

        void Atualizar(int id, TiposUsuario tipoAtualizado);
    }
}
