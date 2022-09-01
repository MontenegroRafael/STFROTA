﻿using System;
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
            VeiculoService veiculoService = new VeiculoService();

            Listar.MostarMenu();
            Console.Write("Qual Opção Deseja? ");
            int opcao = Convert.ToInt32(Console.ReadLine());

            while (true)
            {
            // CLIENTE - MOSTRAR LISTA DE CLIENTES
                if (opcao == 1)
                {
                    var resultado = clienteService.BuscarTodos();
                // MOSTRA OS DADOS NA TELA
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

            // CLIENTE - CADASTRAR CLIENTE
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

            // CLIENTE - EXCLUIR CLIENTE POR NOME
                else if (opcao == 3)
                {
                    Listar.ClienteMostrarIdNome();
                    Console.Write("Informe o NOME do cliente para excluir: ");
                    string nome = Console.ReadLine();

                    clienteService.Remover(nome);
                }

            // CLIENTE - ATUALIZAR CLIENTE POR ID
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

            // VEICULO - MOSTRAR LISTA DE VEICULOS
                else if (opcao == 5)
                {
                    var resultado = veiculoService.BuscarTodos();
                // MOSTRA OS DADOS NA TELA
                    foreach (var item in resultado)
                    {
                        Console.WriteLine("=====================================");
                        Console.WriteLine("Id: " + item.IdVeiculo);
                        Console.WriteLine("Modelo: " + item.Modelo);
                        Console.WriteLine("Placa: " + item.Placa);
                        Console.WriteLine("Data_Cadastro: " + item.DataCadastro);
                        Console.WriteLine("Login_Cadastro: " + item.LoginCadastro);
                        Console.WriteLine("=====================================");
                    }
                }

            // VEICULO - CADASTRAR VEICULO
                else if (opcao == 6)
                {
                    Console.WriteLine("Informe os dados do Veiculo:");
                    Console.WriteLine("Modelo:");
                    string Modelo = Console.ReadLine();
                    Console.WriteLine("Placa: ");
                    string Placa = Console.ReadLine();
                    Console.WriteLine("Data de Cadastro:");
                    DateTime DataCadastro = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Login de Cadastro:");
                    string LoginCadastro = Console.ReadLine();
                    Veiculo veiculo = new Veiculo(Modelo, Placa, DataCadastro, LoginCadastro);

                    veiculoService.Salvar(veiculo);
                }

            // VEICULO - EXCLUIR VEICULO POR MODELO
                else if (opcao == 7)
                {
                    Listar.VeiculoMostrarIdModelo();
                    Console.Write("Informe o MODELO do veiculo para excluir: ");
                    string modelo = Console.ReadLine();

                    veiculoService.Remover(modelo);
                }
            // SAIR DO PROGRAMA
                else if (opcao == 0)
                {
                    break;
                }

            // OPÇÃO INVALIDA
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
