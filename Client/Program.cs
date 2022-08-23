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
            Console.WriteLine("[1] - Mostrar Todos os Cliente");
            Console.WriteLine("[2] - Cadastrar Cliente");
            Console.WriteLine("[3] - Excluir Cliente");
            Console.WriteLine("[4] - Atualizar Cliente");
            Console.WriteLine("[0] - Sair");
            int opcao = Convert.ToInt32(Console.ReadLine());

            while (opcao != 0)
            {
                if (opcao == 1)
                {
                    var resultado = clienteService.BuscarTodos();
                    //mostra os dados na tela
                    foreach (var item in resultado)
                    {
                        Console.WriteLine("=====================================");
                        Console.WriteLine("Nome: " + item.Nome);
                        Console.WriteLine("CNH: " + item.Cnh);
                        Console.WriteLine("Data_Cadastro: " + item.DataCadastro);
                        Console.WriteLine("Login_Cadastro: " + item.LoginCadastro);
                        Console.WriteLine("=====================================");
                    }
                }


                if (opcao == 2)
                {
                    Console.WriteLine("Informe os dados do cliente:");

                    var cliente = new Cliente()
                    {

                        Nome = Console.ReadLine(),
                        Cnh = Console.ReadLine(),
                        DataCadastro = Convert.ToDateTime(Console.ReadLine()),
                        LoginCadastro = Console.ReadLine()
                    };

                    clienteService.Salvar(cliente);
                }


                if (opcao == 3)
                {
                    Console.WriteLine("Informe o nome do cliente para excluir:");
                    string nome = Console.ReadLine();
                    clienteService.Remover(nome);
                }


                if (opcao == 4)
                {
                    Console.WriteLine("Informe o nome do cliente para atualizar:");
                    string nome = Console.ReadLine();

                    Console.WriteLine("Informe os novos dados do cliente:");

                    var cliente = new Cliente()
                    {
                        Nome = Console.ReadLine(),
                        Cnh = Console.ReadLine(),
                        DataCadastro = Convert.ToDateTime(Console.ReadLine()),
                        LoginCadastro = Console.ReadLine()
                    };

                    clienteService.Atualizar(nome, cliente);
                }

                if (opcao == 0)
                {
                    break;
                }
                Console.WriteLine("Digite a opção desejada");
                Console.WriteLine("[1] - Mostrar Todos os Cliente");
                Console.WriteLine("[2] - Cadastrar Cliente");
                Console.WriteLine("[3] - Excluir Cliente");
                Console.WriteLine("[4] - Atualizar Cliente");
                Console.WriteLine("[0] - Sair");
                opcao = Convert.ToInt32(Console.ReadLine());
            }
        }
    }

}
