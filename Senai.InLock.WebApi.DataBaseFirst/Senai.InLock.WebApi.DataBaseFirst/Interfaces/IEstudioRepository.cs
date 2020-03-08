using Senai.InLock.WebApi.DataBaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Interfaces
{
    interface IEstudioRepository
    {
        List<Estudios> Listar();

        Estudios BuscarPorId(int id);

        void Cadastrar(Estudios novoEstudio);

        void Atualizar(int id, Estudios estudioAtualizado);

        void Deletar(int id);
    }
}
