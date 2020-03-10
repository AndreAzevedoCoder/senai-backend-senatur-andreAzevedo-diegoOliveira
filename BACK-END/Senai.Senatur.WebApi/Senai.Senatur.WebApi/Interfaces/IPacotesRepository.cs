using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface IPacotesRepository
    {
        List<PacoteDomain> Listar();

        PacoteDomain BuscarPorID(int id);

        void Cadastrar(PacoteDomain pacote);

        void Deletar(int id);

        void Atualizar(int id, PacoteDomain pacoteAtualizado);
    }
}
