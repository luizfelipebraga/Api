using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        InLockContext ctx = new InLockContext();

        public Usuarios BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Cadastrar(Usuarios novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public List<Usuarios> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public void Atualizar(int id, Usuarios usuarioAtualizado)
        {
            var entity = BuscarPorId(id);

            if(entity != null)
            {
                entity.Email = usuarioAtualizado.Email;
                entity.Senha = usuarioAtualizado.Senha;
                entity.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;

                ctx.Usuarios.Update(usuarioAtualizado);
                ctx.SaveChanges();
            }

        }

        public void Deletar(int id)
        {
            ctx.Usuarios.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }
    }
}
