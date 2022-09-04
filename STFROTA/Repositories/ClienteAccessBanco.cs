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
    public class ClienteAccessBanco
    {
        private readonly string _connection = @"Data Source=IDESKTOP-IR1AB95;Initial Catalog=SQL_STFROTA;Integrated Security=True;";
        //private readonly string _connection = @"Data Source=ITELABD04\SQLEXPRESS;Initial Catalog=Frota;Integrated Security=True;";

        public bool SalvarCliente(Cliente cliente)
        {
            
            try
            {
                var query = @"INSERT INTO Clientes 
                              (Nome, CNH, DataCadastro, LoginCadastro)
                              VALUES (@nome,@CNH,@dataCadastro,@loginCadastro)";

                using (var sql = new SqlConnection(_connection))

                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@nome", cliente.Nome);
                    command.Parameters.AddWithValue("@CNH", cliente.Cnh);
                    command.Parameters.AddWithValue("@dataCadastro", cliente.DataCadastro);
                    command.Parameters.AddWithValue("@loginCadastro", cliente.LoginCadastro);
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

        public List<ClienteDto> BuscarTodos()
        {
            List<ClienteDto> clientesEncontrados;
            try
            {
                var query = @"SELECT IdCliente, Nome, CNH, DataCadastro, LoginCadastro FROM Clientes";

                using (var connection = new SqlConnection(_connection))
                {

                    clientesEncontrados = connection.Query<ClienteDto>(query).ToList();
                }

                return clientesEncontrados;


            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                
                return null;
            }
        }

        public ClienteDto BuscarPorNome(string nome)
        {
            ClienteDto clientesEncontrados;
            try
            {
                var query = @"SELECT IdCliente, Nome, CNH, DataCadastro, LoginCadastro FROM Clientes
                                      WHERE Nome like CONCAT('%',@nome,'%')";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        nome
                    };
                    clientesEncontrados = connection.QueryFirstOrDefault<ClienteDto>(query, parametros);
                }

                return clientesEncontrados;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }

        }

        public bool Atualizar(int idCliente, Cliente cliente)
        {
            try
            {
                var query = @"UPDATE Clientes SET Nome = @nome, CNH = @cnh, DataAtualizacao = @dataAtualizacao, LoginCadastro = @loginCadastro 
                                WHERE IdCliente = @idCliente";

                using (var sql = new SqlConnection(_connection))

                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@nome", cliente.Nome);
                    command.Parameters.AddWithValue("@cnh", cliente.Cnh);
                    command.Parameters.AddWithValue("@loginCadastro", cliente.LoginCadastro);
                    command.Parameters.AddWithValue("@dataAtualizacao", cliente.DataAtualizacao);
                    command.Parameters.AddWithValue("@idCliente", idCliente);
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
        public void Remover(ClienteDto nome)
        {
            try
            {
                var query = @"DELETE FROM Clientes WHERE Nome = @nome";
                
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    
                    command.Parameters.AddWithValue("@nome", nome.Nome);
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
