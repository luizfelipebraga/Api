using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IEstudioRepository
    {
        /// <summary>
        /// Lista de Estudio.
        /// </summary>
        /// <returns>Lista de Estudio</returns>
        List<EstudioDomain> Listar();

        /// <summary>
        /// Busca um único Estudio pelo ID.
        /// </summary>
        /// <param name="id">ID do Estudio</param>
        /// <returns>Estudio buscado</returns>
        EstudioDomain BuscarPorId(int id);
    }
}
