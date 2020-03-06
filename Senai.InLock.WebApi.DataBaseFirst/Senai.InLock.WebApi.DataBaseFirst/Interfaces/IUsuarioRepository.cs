using Senai.InLock.WebApi.DataBaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuarios> Listar();
        Usuarios BuscarPorId(int id);
        void Cadastrar(Usuarios novoUsuario);
        void Atualizar(int id, Usuarios usuarioAtualizado);
        void Deletar(int id);
    }
}
