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
    public class AluguelAccessBanco
    {
        //private readonly string _connection = @"Data Source=IDESKTOP-IR1AB95;Initial Catalog=Cadastro;Integrated Security=True;";
        private readonly string _connection = @"Data Source=ITELABD04\SQLEXPRESS;Initial Catalog=Frota;Integrated Security=True;";

        public bool SalvarAluguel(Aluguel aluguel)
        {

            try
            {
                var query = @"INSERT INTO Alugueis 
                              (IdCliente, IdVeiculo, DataInicio, DataFim, DataCadastro, LoginCadastro)
                              VALUES (@idCliente, @idVeiculo, @dataInicio, @dataFim, @dataCadastro, @loginCadastro)";

                using (var sql = new SqlConnection(_connection))

                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@idCliente", aluguel.IdCliente);
                    command.Parameters.AddWithValue("@idVeiculo", aluguel.IdVeiculo);
                    command.Parameters.AddWithValue("@dataInicio", aluguel.DataInicio);
                    command.Parameters.AddWithValue("@dataFim", aluguel.DataFim);
                    command.Parameters.AddWithValue("@dataCadastro", aluguel.DataCadastro);
                    command.Parameters.AddWithValue("@loginCadastro", aluguel.LoginCadastro);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Aluguel cadastrado com sucesso.");
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
