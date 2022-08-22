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
                              OUTPUT Inserted.Id
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

                Console.WriteLine("Pessoa cadastrada com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }

        }
        //{
        //    int IdPessoaCriada = -1;
        //    try
        //    {
        //        var query = @"INSERT INTO Pessoa 
        //                      (Nome, Cpf, DataNascimento) 
        //                      OUTPUT Inserted.Id
        //                      VALUES (@nome,@cpf,@dataNascimento)";
        //        using (var sql = new SqlConnection(_connection))
        //        {
        //            SqlCommand command = new SqlCommand(query, sql);
        //            command.Parameters.AddWithValue("@nome", pessoa.Nome);
        //            command.Parameters.AddWithValue("@cpf", pessoa.Cpf);
        //            command.Parameters.AddWithValue("@dataNascimento", pessoa.DataNascimento);
        //            command.Connection.Open();
        //            IdPessoaCriada = (int)command.ExecuteScalar();
        //        }

        //        SalvarEndereco(endereco, IdPessoaCriada);

        //        SalvarTelefone(telefones, IdPessoaCriada);

        //        Console.WriteLine("Pessoa cadastrada com sucesso.");
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Erro: " + ex.Message);
        //        return false;
        //    }
        //}
        //private void SalvarTelefone(List<Telefone> telefones, int IdPessoa)
        //{
        //    try
        //    {
        //        foreach (var telefone in telefones)
        //        {
        //            var query = @"INSERT INTO Telefone 
        //                      (DDD, Numero, IdPessoa)                               
        //                      VALUES (@ddd,@numero,@idPessoa)";
        //            using (var sql = new SqlConnection(_connection))
        //            {
        //                SqlCommand command = new SqlCommand(query, sql);
        //                command.Parameters.AddWithValue("@ddd", telefone.DDD);
        //                command.Parameters.AddWithValue("@numero", telefone.Numero);
        //                command.Parameters.AddWithValue("@idPessoa", IdPessoa);
        //                command.Connection.Open();
        //                command.ExecuteNonQuery();
        //            }
        //            Console.WriteLine("Telefone cadastrado com sucesso.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Erro: " + ex.Message);
        //    }
        //}
        //private void SalvarEndereco(Endereco endereco, int IdPessoa)
        //{
        //    try
        //    {
        //        var query = @"INSERT INTO Endereco 
        //                      (Rua, Numero, Complemento, IdPessoa)                               
        //                      VALUES (@rua,@numero,@complemento, @idPessoa)";
        //        using (var sql = new SqlConnection(_connection))
        //        {
        //            SqlCommand command = new SqlCommand(query, sql);
        //            command.Parameters.AddWithValue("@rua", endereco.Rua);
        //            command.Parameters.AddWithValue("@numero", endereco.Numero);
        //            command.Parameters.AddWithValue("@complemento", endereco.Complemento);
        //            command.Parameters.AddWithValue("@idPessoa", IdPessoa);
        //            command.Connection.Open();
        //            command.ExecuteNonQuery();
        //        }
        //        Console.WriteLine("Endereço cadastrado com sucesso.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Erro: " + ex.Message);
        //    }
        //}

        public List<ClienteDto> BuscarPorNome(string nome)
        {
            List<ClienteDto> clientesEncontrados;
            try
            {
                var query = @"SELECT Id, Nome, CNH, Data_Cadastro, Login_Cadastro FROM Cliente
                                      WHERE Nome like CONCAT('%',@nome,'%')";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        nome
                    };
                    clientesEncontrados = connection.Query<ClienteDto>(query, parametros).ToList();
                }

                return clientesEncontrados;


            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }
        //private EnderecoDto BuscarEnderecoPessoa(int idPessoa)
        //{

        //    try
        //    {
        //        var query = @"SELECT * FROM Endereco
        //                              WHERE IdPessoa = @idPessoa";

        //        using (var connection = new SqlConnection(_connection))
        //        {
        //            var parametros = new
        //            {
        //                idPessoa
        //            };
        //            return connection.QueryFirstOrDefault<EnderecoDto>(query, parametros);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Erro: " + ex.Message);
        //        return null;
        //    }
        //}
        //private List<TelefoneDto> BuscarTelefonesPessoa(int idPessoa)
        //{
        //    try
        //    {
        //        var query = @"SELECT * FROM Telefone
        //                              WHERE IdPessoa = @idPessoa";

        //        using (var connection = new SqlConnection(_connection))
        //        {
        //            var parametros = new
        //            {
        //                idPessoa
        //            };
        //            return connection.Query<TelefoneDto>(query, parametros).ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Erro: " + ex.Message);
        //        return null;
        //    }

        //}
        public List<ClienteDto> BuscarTodos()
        {
            List<ClienteDto> clientesEncontrados;
            try
            {
                var query = @"SELECT Id, Nome, CNH, Data_Cadastro, Login_Cadastro FROM Cliente";

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
