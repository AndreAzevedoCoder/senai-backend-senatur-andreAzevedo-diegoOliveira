using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface IUsuariosRepository
    {
        List<Usuarios> Listar();

        Usuarios BuscarPorID(int id);

        void Cadastrar(Usuarios pacote);

        void Deletar(int id);

        void Atualizar(int id, Usuarios pacoteAtualizado);
    }
}
