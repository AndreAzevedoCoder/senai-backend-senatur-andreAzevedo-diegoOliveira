﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Senai.Senatur.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class TiposUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TiposUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200, _tipoUsuarioRepository.Listar());
        }

        [Authorize(Roles = "1")]
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            return StatusCode(200, _tipoUsuarioRepository.BuscarPorID(Id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TiposUsuario novoTipo)
        {
            _tipoUsuarioRepository.Cadastrar(novoTipo);
            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _tipoUsuarioRepository.Deletar(Id);
            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult Put(int Id,TiposUsuario tipoAtualizado)
        {
            _tipoUsuarioRepository.Atualizar(Id, tipoAtualizado);
            return StatusCode(200);
        }
    }
}
