using System;
using System.Collections.Generic;
using System.Text;
using Client.Models;
using System.Data.SqlClient;
using System.Linq;

namespace Client.Menu
{
    public class Listar
    {
        public static void MostarMenu()
        {

            Console.WriteLine("|******************************** Menu ********************************|");
            Console.WriteLine(" [1]  - Cliente - Listar Todos");
            Console.WriteLine(" [2]  - Cliente - Cadastrar");
            Console.WriteLine(" [3]  - Cliente - Excluir");
            Console.WriteLine(" [4]  - Cliente - Atualizar");
            Console.WriteLine(" [5]  - Veiculo - Listar Todos");
            Console.WriteLine(" [6]  - Veiculo - Cadastrar");
            Console.WriteLine(" [7]  - Veiculo - Excluir");
            Console.WriteLine(" [8]  - Veiculo - Atualizar");
            Console.WriteLine(" [9]  - ");
            Console.WriteLine(" [10] - ");
            Console.WriteLine(" [0]  - Sair");
            Console.WriteLine("|_____________________________________________________________________|");
        }
        public static void ClienteMostrarIdNome()
        {
            
            try
            {
                string connection = @"Data Source=ITELABD04\SQLEXPRESS;Initial Catalog=Frota;Integrated Security=True;";
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
                string connection = @"Data Source=ITELABD04\SQLEXPRESS;Initial Catalog=Frota;Integrated Security=True;";
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
    }
}
