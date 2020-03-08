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
    public class EstudiosController : ControllerBase
    {
        private IEstudioRepository estudioRepository;
        public EstudiosController()
        {
            estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(estudioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(estudioRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Estudios novoEstudio)
        {
            estudioRepository.Cadastrar(novoEstudio);
            return StatusCode(201);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Estudios estudioDeletado = estudioRepository.BuscarPorId(id);

            if(estudioDeletado != null)
            {
            estudioRepository.Deletar(id);
            return Ok($"O Estúdio {id} foi deletado");
               
            }

            return NotFound($"O Estúdio {id} não foi encontrado");

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Estudios estudioAtualizado)
        {
            Estudios estudioBuscado = estudioRepository.BuscarPorId(id);

            if (estudioBuscado != null)
            {
                try
                {
                    estudioRepository.Atualizar(id, estudioAtualizado);
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
                            mensagem = "Estudio não encontrado",
                            erro = true
                        }
                    );
        }
    }
}