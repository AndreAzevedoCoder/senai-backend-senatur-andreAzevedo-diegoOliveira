using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        [HttpPost]
        public IActionResult Post(Usuarios login)
        {
            Usuarios usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);
            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos");
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario),
                new Claim("Claim personalizada", "Valor teste")
            };

            // Define a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senatur-chave-autenticacao"));

            // Define as credenciais do token - Header
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Gera o token
            var token = new JwtSecurityToken(
                issuer: "Senai.Senatur.WebApi",                // emissor do token
                audience: "Senai.Senatur.WebApi",              // destinatário do token
                claims: claims,                         // dados definidos acima
                expires: DateTime.Now.AddMinutes(30),   // tempo de expiração
                signingCredentials: creds               // credenciais do token
            );

            // Retorna Ok com o token
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
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