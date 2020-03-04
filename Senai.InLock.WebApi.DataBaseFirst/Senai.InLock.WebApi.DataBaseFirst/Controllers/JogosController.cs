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
    public class JogosController : ControllerBase
    {
        private IJogoRepository jogoRepository;
        public JogosController()
        {
            jogoRepository = new JogoRepository();
        }

        [HttpGet]
        public IActionResult Get ()
        {
            return Ok(jogoRepository.Listar());
        }

        [HttpGet ("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(jogoRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Jogos novoJogo)
        {
            jogoRepository.Cadastrar(novoJogo);
            return StatusCode(201);
        }


    }
}