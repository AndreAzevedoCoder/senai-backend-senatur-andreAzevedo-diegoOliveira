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
    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return StatusCode(200, _usuarioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult ListarTodos(int id)
        {
            return StatusCode(200, _usuarioRepository.BuscarPorID(id));
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            _usuarioRepository.Cadastrar(usuario);
            return StatusCode(200);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuarios usuario)
        {
            _usuarioRepository.Atualizar(id,usuario);
            return StatusCode(200);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _usuarioRepository.Deletar(id);
            return StatusCode(200);
        }

    }
}