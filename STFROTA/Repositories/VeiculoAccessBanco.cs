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
    public class VeiculoAccessBanco
    {
        //private readonly string _connection = @"Data Source=IDESKTOP-IR1AB95;Initial Catalog=Frota;Integrated Security=True;";//CASA
        private readonly string _connection = @"Data Source=ITELABD04\SQLEXPRESS;Initial Catalog=Frota;Integrated Security=True;";//SENAC

        public bool SalvarVeiculo(Veiculo veiculo)
        {

            try
            {
                var query = @"INSERT INTO Veiculos 
                              (Modelo, Placa, DataCadastro, LoginCadastro)
                              VALUES (@modelo,@placa,@dataCadastro,@loginCadastro)";

                using (var sql = new SqlConnection(_connection))

                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@modelo", veiculo.Modelo);
                    command.Parameters.AddWithValue("@placa", veiculo.Placa);
                    command.Parameters.AddWithValue("@dataCadastro", veiculo.DataCadastro);
                    command.Parameters.AddWithValue("@loginCadastro", veiculo.LoginCadastro);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Cliente cadastrado com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }

        }

        public List<VeiculoDto> BuscarTodos()
        {
            List<VeiculoDto> veiculosEncontrados;
            try
            {
                var query = @"SELECT IdVeiculo, Modelo, Placa, DataCadastro, LoginCadastro FROM Veiculos";

                using (var connection = new SqlConnection(_connection))
                {

                    veiculosEncontrados = connection.Query<VeiculoDto>(query).ToList();
                }

                return veiculosEncontrados;


            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);

                return null;
            }
        }

        public VeiculoDto BuscarPorModelo(string modelo)
        {
            VeiculoDto veiculosEncontrados;
            try
            {
                var query = @"SELECT IdVeiculo, Modelo, Placa,DataCadastro, LoginCadastro FROM Veiculos
                                      WHERE Modelo like CONCAT('%',@modelo,'%')";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        modelo
                    };
                    veiculosEncontrados = connection.QueryFirstOrDefault<VeiculoDto>(query, parametros);
                }

                return veiculosEncontrados;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }

        }

        public bool Atualizar(int idVeiculo, Veiculo veiculo)
        {
            try
            {
                var query = @"UPDATE Veiculos SET Modelo = @modelo, Placa = @placa, DataAtualizacao = @dataAtualizacao, LoginCadastro = @loginCadastro 
                                WHERE IdVeiculo = @idVeiculo";

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
        public void Remover(VeiculoDto modelo)
        {
            try
            {
                var query = @"DELETE FROM Veiculos WHERE Modelo = @modelo";

                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);

                    command.Parameters.AddWithValue("@modelo", modelo.Modelo);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }

        }
    }
}
