using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using Senai.InLock.WebApi.DataBaseFirst.Repositories;

namespace Senai.InLock.WebApi.DataBaseFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository usuarioRepository;
        public UsuariosController()
        {
            usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(usuarioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(usuarioRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Usuarios novoUsuario)
        {
            usuarioRepository.Cadastrar(novoUsuario);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuarios usuarioAtualizado)
        {
            Usuarios usuarioBuscado = usuarioRepository.BuscarPorId(id);

            if (usuarioBuscado != null)
            {
                try
                {
                    usuarioRepository.Atualizar(id, usuarioAtualizado);
                    return NoContent();
                }

                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            return NotFound
                    (
                        new
                        {
                            mensagem = "usuário não encontrado",
                            erro = true
                        }
                    );
        }
        public IActionResult Delete(int id)
        {
            Usuarios usuarioDeletado = usuarioRepository.BuscarPorId(id);

            if (usuarioDeletado != null)
            {
                usuarioRepository.Deletar(id);
                return Ok($"O usuário{id} foi deletado");
            }
            return NotFound($"O usuário não foi encontrado");
        }
    }
}