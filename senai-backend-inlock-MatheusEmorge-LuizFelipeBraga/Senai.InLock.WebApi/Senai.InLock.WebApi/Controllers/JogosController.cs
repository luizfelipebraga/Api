using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class JogosController : ControllerBase
    {

        IJogoRepository _jogoRepository;

        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }
        /// <summary>
        /// Lista todos os jogos e seus estudios
        /// </summary>
        /// <remarks>
        /// Exemplo de resposta:
        /// 
        ///     {
        ///         "idJogo": 0,
        ///         "nomeJogo": "Name",
        ///         "sobrenome": "LastName",
        ///         "dataNascimento": "YYYY-MM-DDTHH:MM:SS"
        ///     }
        ///     
        /// </remarks>
        /// <returns>Uma lista de funcionarios e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de funcionários</response>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_jogoRepository.Listar());
        }

        /// <summary>
        /// Cadastra um novo jogo.
        /// </summary>
        /// <remarks>
        /// Exemplo de entrada:
        /// 
        ///     {
        ///         "nomeJogo": "Red Dead Redemption II",
        ///         "descricao": "jogo eletrônico de ação-aventura western",
        ///         "dataLancamento": "2018-10-26T00:00:00",
        ///         "valor": 120.0,
        ///         "idEstudio": 2
        ///     }
        ///     
        /// </remarks>
        /// <response code="201">Cadastro de usuário feito com sucesso</response>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult CadastrarJogo(JogoDomain novoJogo)
        {
            _jogoRepository.Cadastrar(novoJogo);
            return Created("http://localhost:5000/api/Funcionarios", novoJogo);
        }
    }
}