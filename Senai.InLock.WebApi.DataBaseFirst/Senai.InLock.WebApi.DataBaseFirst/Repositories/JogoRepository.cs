using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        InLockContext ctx = new InLockContext();

        public Jogos BuscarPorId(int id)
        {
            return ctx.Jogos.FirstOrDefault(j => j.IdJogo == id);
        }

        public void Cadastrar (Jogos novoJogo)
        {
            ctx.Jogos.Add(novoJogo);
            ctx.SaveChanges();
        }

        public List<Jogos> Listar()
        {
            return ctx.Jogos.Include(jogo => jogo.IdEstudioNavigation).ToList();
        }

        public void Atualizar (int id, Jogos jogoAtualizado)
        {
            var entity = BuscarPorId(id);

            if(entity != null)
            {
                entity.DataLancamento = jogoAtualizado.DataLancamento;
                entity.Descricao = jogoAtualizado.Descricao;
                entity.IdEstudio = jogoAtualizado.IdEstudio;
                entity.NomeJogo = jogoAtualizado.NomeJogo;
                entity.Valor = jogoAtualizado.Valor;
            }
            ctx.Jogos.Update(jogoAtualizado);
            ctx.SaveChanges();
        }

        public void Deletar (int id)
        {
             ctx.Jogos.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }
    }
}
