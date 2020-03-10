using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface IPacotesRepository
    {
        List<Pacotes> Listar();

        Pacotes BuscarPorID(int id);

        void Cadastrar(Pacotes pacote);

        void Deletar(int id);

        void Atualizar(int id, Pacotes pacoteAtualizado);
    }
}
