using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        //criar contexto para adicionar, remover e atualizar dados do bancp
        InLockContext ctx = new InLockContext();
        public Estudios BuscarPorId(int id)
        {
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == id);
        }

        public void Cadastrar(Estudios novoEstudio)
        {
            ctx.Estudios.Add(novoEstudio);
            //salva as informações do ctx;
            ctx.SaveChanges();
        }

        public List<Estudios> Listar()
        {
           return  ctx.Estudios.Include(estudio => estudio.Jogos).ToList();
        }

        public void Atualizar (int id, Estudios estudioAtualizado)
        {
            var entity = BuscarPorId(id);

            if(entity != null)
            {
                entity.NomeEstudio = estudioAtualizado.NomeEstudio;
            }

            ctx.Estudios.Update(estudioAtualizado);
            ctx.SaveChanges();
        }

        public void Deletar (int id)
        {
            ctx.Estudios.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }
    }
}
