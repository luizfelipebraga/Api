using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        ///// <summary>
        ///// Lista os usuários cadastrados.
        ///// </summary>
        ///// <returns>Lista de Usuários</returns>
        //List<UsuarioDomain> Listar();

        ///// <summary>
        ///// Busca um único pelo id do usuário.
        ///// </summary>
        ///// <param name="id">ID do usuário</param>
        ///// <returns>Usuário buscado</returns>
        //UsuarioDomain BuscarPorId(int id);

        ///// <summary>
        ///// Atualiza o usuário.
        ///// </summary>
        ///// <param name="id">ID do usuário a ser atualizado</param>
        ///// <param name="usuario">Domain do usuário atualizado</param>
        //void Atualizar(int id, UsuarioDomain usuario);

        ///// <summary>
        ///// Deleta um usuário.
        ///// </summary>
        ///// <param name="id">ID do usuário a ser deletado.</param>
        //void Deletar(int id);

        ///// <summary>
        ///// Insere um novo usuário no banco.
        ///// </summary>
        ///// <param name="usuario">Domain do usuário a ser cadastrado</param>
        //void Cadastrar(UsuarioDomain usuario);

        /// <summary>
        /// Busca um usuário através do e-mail e da senha
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Retorna um usuário validado</returns>
        UsuarioDomain BuscarPorEmailSenha(string email, string senha);
    }
}
