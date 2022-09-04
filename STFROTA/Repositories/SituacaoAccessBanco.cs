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
        private readonly string _connection = @"Data Source=IDESKTOP-IR1AB95;Initial Catalog=SQL_STFROTA;Integrated Security=True;";
        //private readonly string _connection = @"Data Source=ITELABD04\SQLEXPRESS;Initial Catalog=Frota;Integrated Security=True;";

        public bool Cadastrar(int idVeiculo, Situacao situacao)
        {
            try
            {
                var query = @"INSERT INTO Situacoes " +
                            "(Nome, DataCadastro, LoginCadastro, IdVeiculo)" +
                            "VALUES (@nome, @dataCadastro, @loginCadastro, @idVeiculo)";

                using (var sql = new SqlConnection(_connection))

                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@nome", situacao.Nome);
                    command.Parameters.AddWithValue("@dataCadastro", situacao.DataCadastro);
                    command.Parameters.AddWithValue("@loginCadastro", situacao.LoginCadastro);
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

        public bool Atualizar(int idVeiculo, Situacao situacao)
        {
            try
            {
                var query = @"UPDATE Situacoes SET Nome = @nome, DataAtualizacao = @dataAtualizacao, LoginCadastro = @loginCadastro
                                WHERE IdVeiculo = @idVeiculo";

                using (var sql = new SqlConnection(_connection))

                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@nome", situacao.Nome);
                    command.Parameters.AddWithValue("@loginCadastro", situacao.LoginCadastro);
                    command.Parameters.AddWithValue("@dataAtualizacao", situacao.DataAtualizacao);
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
