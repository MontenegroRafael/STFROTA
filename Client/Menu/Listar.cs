using System;
using System.Collections.Generic;
using System.Text;
using Client.Models;
using System.Data.SqlClient;
using System.Linq;
using System.Data;

namespace Client.Menu
{
    public class Listar
    {

        public static void MostarMenu()
        {

            Console.WriteLine("|******************************** Menu ********************************|");
            Console.WriteLine("|______________________________ Cliente  ______________________________|");
            Console.WriteLine("|                                                                      |");
            Console.WriteLine("|>>> [ 1  ] - Listar Todos                                             |");
            Console.WriteLine("|>>> [ 2  ] - Cadastrar                                                |");
            Console.WriteLine("|>>> [ 3  ] - Excluir                                                  |");
            Console.WriteLine("|>>> [ 4  ] - Atualizar                                                |");
            Console.WriteLine("|______________________________ Veiculo  ______________________________|");
            Console.WriteLine("|                                                                      |");
            Console.WriteLine("|>>> [ 5  ] - Listar Todos                                             |");
            Console.WriteLine("|>>> [ 6  ] - Cadastrar                                                |");
            Console.WriteLine("|>>> [ 7  ] - Excluir                                                  |");
            Console.WriteLine("|>>> [ 8  ] - Atualizar                                                |");
            Console.WriteLine("|______________________________ Aluguel  ______________________________|");
            Console.WriteLine("|                                                                      |");
            Console.WriteLine("|>>> [ 9  ] - Listar Todos                                             |");
            Console.WriteLine("|>>> [ 10 ] - Cadastrar                                                |");
            Console.WriteLine("|>>> [ 11 ] - Excluir por ID                                           |");
            Console.WriteLine("|>>> [ 12 ] - Atualizar                                                |");
            Console.WriteLine("|________________________ Situação do Veiculo _________________________|");
            Console.WriteLine("|                                                                      |");
            Console.WriteLine("|>>> [ 13 ] - Cadastrar                                                |");
            Console.WriteLine("|>>> [ 14 ] - Atualizar                                                |");
            Console.WriteLine("|________________________  Controle de Frota  _________________________|");
            Console.WriteLine("|                                                                      |");
            Console.WriteLine("|>>> [ 15 ] - Listar Todos                                             |");
            Console.WriteLine("|______________________________________________________________________|");
            Console.WriteLine("|                                                                      |");
            Console.WriteLine("|>>> [ 0  ] - Sair");
        }
        public static void ClienteMostrarIdNome()
        {
            
            try
            {
                string connection = @"Data Source=DESKTOP-IR1AB95;Initial Catalog=Frota;Integrated Security=True;";//CASA
                //string connection = @"Data Source=ITELABD04\SQLEXPRESS;Initial Catalog=Frota;Integrated Security=True;";//SENAC

                List<Cliente> listarClientes = new List<Cliente>();

                SqlDataReader resultado;
                var query = "SELECT IdCliente, Nome FROM Clientes ";

                using (var sql = new SqlConnection(connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Connection.Open();
                    resultado = command.ExecuteReader();


                    while (resultado.Read())
                    {
                        listarClientes.Add(new Cliente(resultado.GetInt32(resultado.GetOrdinal("IdCliente")),
                                                     resultado.GetString(resultado.GetOrdinal("Nome"))));
                    }
                }
                Console.WriteLine("========Listagem========");
                foreach (Cliente p in listarClientes)
                {
                    Console.WriteLine(" Id: " + p.IdCliente);
                    Console.WriteLine(" Nome: " + p.Nome);
                    Console.WriteLine("---------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        public static void VeiculoMostrarIdModelo()
        {

            try
            {
                string connection = @"Data Source=DESKTOP-IR1AB95;Initial Catalog=Frota;Integrated Security=True;";//CASA
                //string connection = @"Data Source=ITELABD04\SQLEXPRESS;Initial Catalog=Frota;Integrated Security=True;";//SENAC
                List<Veiculo> listarVeiculos = new List<Veiculo>();

                SqlDataReader resultado;
                var query = "SELECT IdVeiculo, Modelo FROM Veiculos ";

                using (var sql = new SqlConnection(connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Connection.Open();
                    resultado = command.ExecuteReader();


                    while (resultado.Read())
                    {
                        listarVeiculos.Add(new Veiculo(resultado.GetInt32(resultado.GetOrdinal("IdVeiculo")),
                                                     resultado.GetString(resultado.GetOrdinal("Modelo"))));
                    }
                }
                Console.WriteLine("========Listagem========");
                foreach (Veiculo p in listarVeiculos)
                {
                    Console.WriteLine(" Id: " + p.IdVeiculo);
                    Console.WriteLine(" Modelo: " + p.Modelo);
                    Console.WriteLine("---------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        public static void VeiculoMostrarIdModeloSituacao()
        {

            try
            {
                string connection = @"Data Source=DESKTOP-IR1AB95;Initial Catalog=Frota;Integrated Security=True;";//CASA
                //string connection = @"Data Source=ITELABD04\SQLEXPRESS;Initial Catalog=Frota;Integrated Security=True;";//SENAC
                List<Veiculo> listarVeiculos = new List<Veiculo>();
                List<Situacao> listarVeiculos1 = new List<Situacao>();

                SqlDataReader resultado;
                var query = "SELECT v.IdVeiculo, v.Modelo, s.Nome FROM Veiculos v LEFT JOIN Situacoes s ON v.IdVeiculo = s.IdVeiculo ";
                //SELECT p.Id, p.Nome, p.Cpf, p.Rg, p.DatadeNascimento, p.Naturalidade, t.Numero, t.Ddd
                //FROM Pessoa p LEFT JOIN Telefone t ON p.Id = t.IdPessoa ";
                using (var sql = new SqlConnection(connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Connection.Open();
                    resultado = command.ExecuteReader();


                    while (resultado.Read())
                    {
                        listarVeiculos.Add(new Veiculo(resultado.GetInt32(resultado.GetOrdinal("IdVeiculo")),
                                                     resultado.GetString(resultado.GetOrdinal("Modelo"))));
                        listarVeiculos1.Add(new Situacao(resultado.SafeGetString(resultado.GetOrdinal("Nome"))));
                    }
                }
                Console.WriteLine("========Listagem========");
                for (int i = 0; i < listarVeiculos.Count; i++)
                {
                    Console.WriteLine(" Id: " + listarVeiculos[i].IdVeiculo);
                    Console.WriteLine(" Modelo: " + listarVeiculos[i].Modelo);
                    Console.WriteLine(" Situação: " + listarVeiculos1[i].Nome);
                    Console.WriteLine("---------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        public static void AluguelMostrarTodos()
        {

            try
            {
                string connection = @"Data Source=DESKTOP-IR1AB95;Initial Catalog=Frota;Integrated Security=True;";//CASA
                //string connection = @"Data Source=ITELABD04\SQLEXPRESS;Initial Catalog=Frota;Integrated Security=True;";//SENAC

                List<Aluguel> listarAlugueis = new List<Aluguel>();

                SqlDataReader resultado;
                var query = "SELECT a.IdAluguel, a.IdCliente, a.IdVeiculo FROM Alugueis a";

                using (var sql = new SqlConnection(connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Connection.Open();
                    resultado = command.ExecuteReader();


                    while (resultado.Read())
                    {
                        listarAlugueis.Add(new Aluguel(resultado.GetInt32(resultado.GetOrdinal("IdAluguel")),
                                                       resultado.GetInt32(resultado.GetOrdinal("IdCliente")),
                                                       resultado.GetInt32(resultado.GetOrdinal("IdVeiculo"))));
                    }
                }
                Console.WriteLine("========Listagem========");
                foreach (Aluguel p in listarAlugueis)
                {
                    Console.WriteLine(" IdAluguel: " + p.IdAluguel);
                    Console.WriteLine(" IdCliente: " + p.IdCliente);
                    Console.WriteLine(" IdVeiculo: " + p.IdVeiculo);
                    Console.WriteLine("---------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

    }

    public static class Extensions // EXTENSÃO CRIADA PARA QUANDO O VALOR RESGATADO DO BANCO FOR NULL ENTÃO FICA VAZIO (Empty)
    {
        public static string SafeGetString(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }

        

    }
}
