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
            Console.WriteLine(" [1]  - Mostrar Lista de Cliente");
            Console.WriteLine(" [2]  - Cadastrar Cliente");
            Console.WriteLine(" [3]  - Excluir Cliente");
            Console.WriteLine(" [4]  - Atualizar Cliente");
            Console.WriteLine(" [5]  - ");
            Console.WriteLine(" [6]  - ");
            Console.WriteLine(" [7]  - ");
            Console.WriteLine(" [8]  - ");
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
                    Console.WriteLine("---------------------------");
                    Console.WriteLine(" Id: " + p.IdCliente);
                    Console.WriteLine(" Nome: " + p.Nome);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
    }
}
