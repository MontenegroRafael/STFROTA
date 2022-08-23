using STFROTA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using STFROTA.Dtos;

namespace STFROTA.Repositories
{
    public class ClienteAccessBanco
    {

        //private readonly string _connection = @"Data Source=IDESKTOP-IR1AB95;Initial Catalog=Cadastro;Integrated Security=True;";
        private readonly string _connection = @"Data Source=ITELABD04\SQLEXPRESS;Initial Catalog=Cadastro;Integrated Security=True;";

        public bool SalvarCliente(Cliente cliente)
        {
            int IdPessoaCriada = -1;
            try
            {
                var query = @"INSERT INTO Cliente 
                              (Nome, CNH, Data_Cadastro, Login_Cadastro) 
                              OUTPUT Inserted.Id_Cliente
                              VALUES (@nome,@cpf,@data_Cadastro,@Login_Cadastro)";

                using (var sql = new SqlConnection(_connection))

                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@nome", cliente.Nome);
                    command.Parameters.AddWithValue("@CNH", cliente.Cnh);
                    command.Parameters.AddWithValue("@data_Cadastro", cliente.DataCadastro);
                    command.Parameters.AddWithValue("@data_Cadastro", cliente.LoginCadastro);
                    command.Connection.Open();
                    IdPessoaCriada = (int)command.ExecuteScalar();
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
                var query = @"SELECT IdMotorista, Nome, CPF, RG, CNH, Telefone FROM MotoristaME";

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
    }
}
