using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IJogoRepository
    {
        /// <summary>
        /// Lista de Jogo.
        /// </summary>
        /// <returns>Lista de Jogo</returns>
        List<JogoDomain> Listar();

        /// <summary>
        /// Insere um novo Jogo no banco.
        /// </summary>
        /// <param name="jogo">Domain do Jogo a ser cadastrado</param>
        void Cadastrar(JogoDomain jogo);
    }
}
