using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;

namespace Senai.Senatur.WebApi.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class PacotesController : ControllerBase
    {
        private IPacotesRepository _pacotesRepository { get; set; }

        public PacotesController()
        {
            _pacotesRepository = new PacoteRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return StatusCode(200, _pacotesRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult ListarTodos(int id)
        {
            return StatusCode(200, _pacotesRepository.BuscarPorID(id));
        }

        [HttpPost]
        public IActionResult Cadastrar(Pacotes pacote)
        {
            _pacotesRepository.Cadastrar(pacote);
            return StatusCode(200);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Pacotes pacote)
        {
            _pacotesRepository.Atualizar(id,pacote);
            return StatusCode(200);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _pacotesRepository.Deletar(id);
            return StatusCode(200);
        }

    }
}