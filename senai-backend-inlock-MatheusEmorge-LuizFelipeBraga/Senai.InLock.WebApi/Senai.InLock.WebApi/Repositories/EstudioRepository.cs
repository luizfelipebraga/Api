using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {

        private string stringConexao = "Data Source=N-1S-DEV-10\\SQLEXPRESS; initial catalog=InLock_Games_Tarde; user Id=sa; pwd=sa@132";


        public EstudioDomain BuscarPorId(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string querySelectById = "SELECT IdEstudio, NomeEstudio FROM Estudios WHERE IdEstudio = @ID";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para receber os dados do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Caso o resultado da query possua registro
                    if (rdr.Read())
                    {
                        // Instancia um objeto funcionario 
                        EstudioDomain funcionario = new EstudioDomain
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            NomeEstudio = rdr["NomeEstudio"].ToString(),
                        };

                        // Retorna o funcionário buscado
                        return funcionario;
                    }

                    // Caso o resultado da query não possua registros, retorna null
                    return null;
                }
            }
        }

        public List<EstudioDomain> Listar()
        {
            List<EstudioDomain> funcionarios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdEstudio, NomeEstudio FROM Estudios";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto funcionario 
                        EstudioDomain funcionario = new EstudioDomain
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            NomeEstudio = rdr["NomeEstudio"].ToString()
                        };

                        // Adiciona o funcionario criado à lista funcionarios
                        funcionarios.Add(funcionario);
                    }
                }
            }
            // Retorna a lista de funcionarios
            return funcionarios;
        }
    }
}
