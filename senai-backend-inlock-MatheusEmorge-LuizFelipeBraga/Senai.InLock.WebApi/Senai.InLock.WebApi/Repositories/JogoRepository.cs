using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {

        public EstudioRepository _estudioRepositorio = new EstudioRepository();

        private string stringConexao = "Data Source=N-1S-DEV-10\\SQLEXPRESS; initial catalog=InLock_Games_Tarde; user Id=sa; pwd=sa@132";


        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Jogos(NomeJogo, Descricao, DataLancamento, Valor, IdEstudio) VALUES (@Nome, @Desc, @Data, @Valor, @IdEstudio)";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Desc", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@Data", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<JogoDomain> Listar()
        {
            List<JogoDomain> jogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdJogo, NomeJogo, Descricao, DataLancamento, Valor, IdEstudio FROM Jogos";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        // Instancia um objeto jogo 
                        JogoDomain jogo = new JogoDomain
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            NomeJogo = rdr["NomeJogo"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),
                            Valor = Convert.ToSingle(rdr["Valor"]),
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Estudio = _estudioRepositorio.BuscarPorId(Convert.ToInt32(rdr["IdEstudio"]))

                        };

                        // Adiciona o jogo criado à lista jogos
                        jogos.Add(jogo);
                    }
                }
            }
            // Retorna a lista de jogos
            return jogos;
        }
    }
}
