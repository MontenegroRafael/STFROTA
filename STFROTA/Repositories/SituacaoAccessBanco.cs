using STFROTA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using STFROTA.Dtos;
using Dapper;

namespace STFROTA.Repositories
{
    public class SituacaoAccessBanco
    {
        public bool Atualizar(int idVeiculo, Situacao situacao)
        {
            try
            {
                var query = @"INSERT INTO Situacoes " +
                            "(Nome, DataCadastro, LoginCadastro, IdVeiculo)" +
                            "VALUES (@ddd, @numero, @idVeiculo)";

                using (var sql = new SqlConnection(_connection))

                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@modelo", veiculo.Modelo);
                    command.Parameters.AddWithValue("@placa", veiculo.Placa);
                    command.Parameters.AddWithValue("@dataAtualizacao", veiculo.DataAtualizacao);
                    command.Parameters.AddWithValue("@loginCadastro", veiculo.LoginCadastro);
                    command.Parameters.AddWithValue("@idVeiculo", idVeiculo);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }
    }
}
