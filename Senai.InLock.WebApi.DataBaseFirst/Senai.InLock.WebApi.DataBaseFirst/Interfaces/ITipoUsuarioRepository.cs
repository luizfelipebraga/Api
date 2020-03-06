using Senai.InLock.WebApi.DataBaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TiposUsuario> Listar();
        TiposUsuario BuscarPorId(int id);
        void Cadastrar(TiposUsuario novoTipoUsuario);
        void Atualizar(int id, TiposUsuario tipousuarioAtualizado);
        void Deletar(int id);
        
    }
}
