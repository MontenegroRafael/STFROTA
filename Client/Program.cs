using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Models;
using Client.Service;
using Newtonsoft.Json;
using Client.Menu;

namespace Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // INSTANCIAR
            ClienteService clienteService = new ClienteService();

            Listar.MostarMenu();
            Console.Write("Qual Opção Deseja? ");
            int opcao = Convert.ToInt32(Console.ReadLine());

            while (true)
            {
                // MOSTRAR LISTA DE CLIENTES
                if (opcao == 1) 
                {
                    var resultado = clienteService.BuscarTodos();
                    //mostra os dados na tela
                    foreach (var item in resultado)
                    {
                        Console.WriteLine("=====================================");
                        Console.WriteLine("Id: " + item.IdCliente);
                        Console.WriteLine("Nome: " + item.Nome);
                        Console.WriteLine("CNH: " + item.Cnh);
                        Console.WriteLine("Data_Cadastro: " + item.DataCadastro);
                        Console.WriteLine("Login_Cadastro: " + item.LoginCadastro);
                        Console.WriteLine("=====================================");
                    }
                }
                // CADASTRAR CLIENTE
                else if (opcao == 2) 
                {
                    Console.WriteLine("Informe os dados do Cliente:");
                    Console.WriteLine("Nome:");
                    string Nome = Console.ReadLine();
                    Console.WriteLine("CNH: ");
                    string Cnh = Console.ReadLine();
                    Console.WriteLine("Data de Cadastro:");
                    DateTime DataCadastro = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Login de Cadastro:");
                    string LoginCadastro = Console.ReadLine();
                    Cliente cliente = new Cliente(Nome, Cnh, DataCadastro, LoginCadastro);

                    clienteService.Salvar(cliente);
                }
                // EXCLUIR CLIENTE POR ID
                else if (opcao == 3)
                {
                    Listar.ClienteMostrarIdNome();
                    Console.Write("Informe o ID do cliente para excluir: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    clienteService.Remover(id);
                }
                // ATUALIZAR CLIENTE POR ID
                else if (opcao == 4)
                {
                    Listar.ClienteMostrarIdNome();
                    Console.Write("Informe o Id do cliente para atualizar: ");
                    int idCliente = Convert.ToInt32(Console.ReadLine());
                    
                    Console.WriteLine("=====================================");
                    Console.WriteLine("Informe os dados do Cliente:");

                    Console.WriteLine("Nome:");
                    string Nome = Console.ReadLine();
                    Console.WriteLine("CNH: ");
                    string Cnh = Console.ReadLine();
                    Console.WriteLine("Login de Cadastro:");
                    string LoginCadastro = Console.ReadLine();
                    Console.WriteLine("=====================================");

                    Cliente cliente = new Cliente(Nome, Cnh, LoginCadastro);

                    clienteService.Atualizar(idCliente, cliente);
                    Console.WriteLine("=====================================");
                    Console.WriteLine(" - Cliente atualizado com sucesso!");
                    Console.WriteLine("=====================================");
                }

                else if (opcao == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("**** Opção Invalida! - DIGITE UMA OPÇÃO VALIDA - ");
                }
                Listar.MostarMenu();
                Console.Write("Qual Opção Deseja? ");
                opcao = Convert.ToInt32(Console.ReadLine());
            }
        
        }
    }

}
