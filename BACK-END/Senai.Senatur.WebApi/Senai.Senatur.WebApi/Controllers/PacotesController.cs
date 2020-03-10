using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Senai.Senatur.WebApi.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class PacotesController : ControllerBase
    {
        private IPacotesRepository _pacotesRepository { get; set; }

        public PacotesController()
        {
            _pacotesRepository = new PacotesRepository();
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
        public IActionResult Cadastrar(PacoteDomain pacote)
        {
            return StatusCode(200, _pacotesRepository.Cadastrar(pacote));
        }
    }
}