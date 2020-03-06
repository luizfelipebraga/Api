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
    public class TiposUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository tipousuarioRepository;
        public TiposUsuarioController()
        {
            tipousuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(tipousuarioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(tipousuarioRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(TiposUsuario novoTipo)
        {
            tipousuarioRepository.Cadastrar(novoTipo);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposUsuario tipoAtualizado)
        {
            TiposUsuario tipoBuscado = tipousuarioRepository.BuscarPorId(id);

            if (tipoBuscado != null)
            {
                try
                {
                    tipousuarioRepository.Atualizar(id, tipoAtualizado);
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
                            mensagem = "Tipo não encontrado",
                            erro = true
                        }
                    );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TiposUsuario tipoDeletado = tipousuarioRepository.BuscarPorId(id);

            if (tipoDeletado != null)
            {
                tipousuarioRepository.Deletar(id);
                return Ok($"O tipo{id} foi deletado");
            }
            return NotFound($"O tipo não foi encontrado");
        }
    }
}