using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        InLockContext ctx = new InLockContext();

        public TiposUsuario BuscarPorId(int id)
        {
            return ctx.TiposUsuario.FirstOrDefault(t => t.IdTipoUsuario == id);
        }

        public void Cadastrar(TiposUsuario novoTipo)
        {
            ctx.TiposUsuario.Add(novoTipo);
            ctx.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return ctx.TiposUsuario.ToList();
        }

        public void Atualizar(int id, TiposUsuario tipoAtualizado)
        {
            ctx.TiposUsuario.Update(tipoAtualizado);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.TiposUsuario.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }
    }
}
