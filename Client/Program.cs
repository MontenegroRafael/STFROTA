using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Client;
using Client.Models;
using Client.Service;
using Newtonsoft.Json;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {

            //instanciar
            ClienteService clienteService = new ClienteService();

            Console.WriteLine("Digite a opção desejada");
            Console.WriteLine("[1] - Mostrar Lista de Cliente");
            Console.WriteLine("[2] - Cadastrar Cliente");
            Console.WriteLine("[3] - Excluir Cliente");
            Console.WriteLine("[4] - Atualizar Cliente");
            Console.WriteLine("[0] - Sair");
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
                // EXCLUIR CLIENTE POR NOME
                else if (opcao == 3)
                {
                    Console.Write("Informe o nome do cliente para excluir: ");
                    string nome = Console.ReadLine();
                    clienteService.Remover(nome);
                }

                else if (opcao == 4)
                {
                    Console.Write("Informe o Id do cliente para atualizar: ");
                    int idCliente = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Informe os dados do Cliente:");
                    Console.WriteLine("Nome:");
                    string Nome = Console.ReadLine();
                    Console.WriteLine("CNH: ");
                    string Cnh = Console.ReadLine();
                    Console.WriteLine("Data de Cadastro:");
                    DateTime DataAtualizacao = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Login de Cadastro:");
                    string LoginCadastro = Console.ReadLine();

                    Cliente cliente = new Cliente(Nome, Cnh, DataAtualizacao, LoginCadastro);

                    clienteService.Atualizar(idCliente, cliente);
                }

                else if (opcao == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("**** Opção Invalida! - DIGITE UMA OPÇÃO VALIDA - ");
                }
                Console.WriteLine("Digite a opção desejada");
                Console.WriteLine("[1] - Mostrar Lista de Cliente");
                Console.WriteLine("[2] - Cadastrar Cliente");
                Console.WriteLine("[3] - Excluir Cliente");
                Console.WriteLine("[4] - Atualizar Cliente");
                Console.WriteLine("[0] - Sair");
                opcao = Convert.ToInt32(Console.ReadLine());
            }
        
        }
    }

}
