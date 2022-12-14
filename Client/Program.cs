/* - “Digno és tu, Senhor e Deus nosso, de receber a glória, a honra e o poder, 
      pois foste tu que criaste o universo; por tua vontade, ele não era e foi criado." 
   - Apocalipse 4:11 .*/

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
            VeiculoService veiculoService = new VeiculoService();
            SituacaoService situacaoService = new SituacaoService();
            AluguelService aluguelService = new AluguelService();
            ControleFrotaService controleFrotaService = new ControleFrotaService();

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
                        Console.WriteLine("Login_Cadastro: " + item.DataAtualizacao);
                        Console.WriteLine("=====================================");
                    }
                }

            // CLIENTE - CADASTRAR CLIENTE
                else if (opcao == 2)
                {
                    Console.WriteLine("Informe os dados do Cliente:");
                    Console.Write("Nome: ");
                    string Nome = Console.ReadLine();
                    Console.Write("CNH: ");
                    string Cnh = Console.ReadLine();
                    Console.Write("Login de Cadastro: ");
                    string LoginCadastro = Console.ReadLine();
                //  VALIDAÇÃO DO LOGIN
                    while (!Validacao.Validar.Login(LoginCadastro))
                    {
                        Console.WriteLine("=====================================");
                        Console.WriteLine("###### - LOGIN INVALIDO! - ######");
                        Console.WriteLine("Digite novamente.");
                        Console.Write("Login de Cadastro:");
                        LoginCadastro = Console.ReadLine();
                        Console.WriteLine("=====================================");
                    }
                    Cliente cliente = new Cliente(Nome, Cnh, LoginCadastro);

                    clienteService.Salvar(cliente);

                    Console.WriteLine("=====================================");
                    Console.WriteLine(" - Cliente CADASTRADO com sucesso!");
                    Console.WriteLine("=====================================");
                }

            // CLIENTE - EXCLUIR CLIENTE POR NOME
                else if (opcao == 3)
                {
                    Listar.ClienteMostrarIdNome();
                    Console.Write("Informe o NOME do cliente para excluir: ");
                    string nome = Console.ReadLine();

                    clienteService.Remover(nome);

                    Console.WriteLine("=====================================");
                    Console.WriteLine(" - Cliente DELETADO com sucesso!");
                    Console.WriteLine("=====================================");
                }

            // CLIENTE - ATUALIZAR CLIENTE POR ID
                else if (opcao == 4)
                {
                    Listar.ClienteMostrarIdNome();
                    Console.Write("Informe o Id do cliente para atualizar: ");
                    int idCliente = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("=====================================");
                    Console.WriteLine("Informe os dados do Cliente:");

                    Console.Write("Nome:");
                    string Nome = Console.ReadLine();
                    Console.Write("CNH: ");
                    string Cnh = Console.ReadLine();
                    Console.Write("Login de Cadastro:");
                    string LoginCadastro = Console.ReadLine();
                    Console.WriteLine("=====================================");
                //  VALIDAÇÃO DO LOGIN
                    while (!Validacao.Validar.Login(LoginCadastro))
                    {
                        Console.WriteLine("=====================================");
                        Console.WriteLine("###### - LOGIN INVALIDO! - ######");
                        Console.WriteLine("Digite novamente.");
                        Console.WriteLine("Login de Cadastro:");
                        LoginCadastro = Console.ReadLine();
                        Console.WriteLine("=====================================");
                    }
                    Cliente cliente = new Cliente(Nome, Cnh, LoginCadastro);

                    clienteService.Atualizar(idCliente, cliente);
                    Console.WriteLine("=====================================");
                    Console.WriteLine(" - Cliente ATUALIZADO com sucesso!");
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
                        Console.WriteLine("Login_Cadastro: " + item.DataAtualizacao);
                        Console.WriteLine("=====================================");
                    }
                }

            // VEICULO - CADASTRAR VEICULO
                else if (opcao == 6)
                {
                    Console.WriteLine("Informe os dados do Veiculo:");
                    Console.Write("Modelo: ");
                    string Modelo = Console.ReadLine();
                    Console.Write("Placa: ");
                    string Placa = Console.ReadLine();
                    Console.Write("Login de Cadastro: ");
                    string LoginCadastro = Console.ReadLine();

                //  VALIDAÇÃO DO LOGIN
                    while (!Validacao.Validar.Login(LoginCadastro))
                    {
                        Console.WriteLine("=====================================");
                        Console.WriteLine("###### - LOGIN INVALIDO! - ######");
                        Console.WriteLine("Digite novamente.");
                        Console.WriteLine("Login de Cadastro:");
                        LoginCadastro = Console.ReadLine();
                        Console.WriteLine("=====================================");
                    }
                    Veiculo veiculo = new Veiculo(Modelo, Placa, LoginCadastro);

                    veiculoService.Salvar(veiculo);

                    Console.WriteLine("=====================================");
                    Console.WriteLine(" - Veiculo CADASTRADO com sucesso!");
                    Console.WriteLine("=====================================");
                }

            // VEICULO - EXCLUIR VEICULO POR MODELO
                else if (opcao == 7)
                {
                    Listar.VeiculoMostrarIdModelo();
                    Console.Write("Informe o MODELO do veiculo para excluir: ");
                    string modelo = Console.ReadLine();

                    veiculoService.Remover(modelo);

                    Console.WriteLine("=====================================");
                    Console.WriteLine(" - Veiculo DELETADO com sucesso!");
                    Console.WriteLine("=====================================");
                }

            // VEICULO - ATUALIZAR VEICULO POR ID
                else if (opcao == 8)
                {
                    Listar.VeiculoMostrarIdModelo();
                    Console.Write("Informe o Id do veiculo para atualizar: ");
                    int idVeiculo = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("=====================================");
                    Console.WriteLine("Informe os dados do Veiculo:");

                    Console.Write("Modelo: ");
                    string Modelo = Console.ReadLine();
                    Console.Write("Placa: ");
                    string Placa = Console.ReadLine();
                    Console.Write("Login de Cadastro: ");
                    string LoginCadastro = Console.ReadLine();
                    Console.WriteLine("=====================================");

                //  VALIDAÇÃO DO LOGIN
                    while (!Validacao.Validar.Login(LoginCadastro))
                    {
                        Console.WriteLine("=====================================");
                        Console.WriteLine("###### - LOGIN INVALIDO! - ######");
                        Console.WriteLine("Digite novamente.");
                        Console.Write("Login de Cadastro: ");
                        LoginCadastro = Console.ReadLine();
                        Console.WriteLine("=====================================");
                    }
                    Veiculo veiculo = new Veiculo(Modelo, Placa, LoginCadastro);

                    veiculoService.Atualizar(idVeiculo, veiculo);

                    Console.WriteLine("=====================================");
                    Console.WriteLine(" - Veiculo ATUALIZADO com sucesso!");
                    Console.WriteLine("=====================================");
                }

            // ALUGUEL - MOSTRAR LISTA DE ALUGUEIS
                else if (opcao == 9)
                {
                    var resultado = aluguelService.BuscarTodos();
                    // MOSTRA OS DADOS NA TELA
                    foreach (var item in resultado)
                    {
                        Console.WriteLine("=====================================");
                        Console.WriteLine("Id Cliente: " + item.IdCliente);
                        Console.WriteLine("Id Veiculo: " + item.IdVeiculo);
                        Console.WriteLine("Data Início: " + item.DataInicio);
                        Console.WriteLine("Data Fim: " + item.DataFim);
                        Console.WriteLine("Data do Cadastro: " + item.DataCadastro);
                        Console.WriteLine("Login de Cadastro: " + item.LoginCadastro);
                        Console.WriteLine("Data de Atualizacao: " + item.DataAtualizacao);
                        Console.WriteLine("=====================================");
                    }
                }

            // ALUGUEL - CADASTRAR ALUGUEL
                else if (opcao == 10)
                {
                    Console.WriteLine("=====================================");
                    Console.WriteLine("   Informe os dados abaixo:    ");
                    Console.WriteLine("=====================================");
                    Listar.ClienteMostrarIdNome();
                    Console.Write(">>> Id do Cliente: ");
                    int IdCliente = Convert.ToInt32(Console.ReadLine());
                    Listar.VeiculoMostrarIdModeloSituacao();
                    Console.Write(">>> Id do Veiculo: ");
                    int IdVeiculo = Convert.ToInt32(Console.ReadLine());
                    Console.Write(">>> Início do Aluguel - DATA: ");
                    DateTime DataInicio = Convert.ToDateTime(Console.ReadLine());
                    Console.Write(">>> Fim do Aluguel - DATA: ");
                    DateTime DataFim = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Login de Cadastro: ");
                    string LoginCadastro = Console.ReadLine();

                //  VALIDAÇÃO DO LOGIN
                    while (!Validacao.Validar.Login(LoginCadastro))
                    {
                        Console.WriteLine("=====================================");
                        Console.WriteLine("###### - LOGIN INVALIDO! - ######");
                        Console.WriteLine("Digite novamente.");
                        Console.Write("Login de Cadastro: ");
                        LoginCadastro = Console.ReadLine();
                        Console.WriteLine("=====================================");
                    }
                    Aluguel aluguel = new Aluguel(IdCliente, IdVeiculo, DataInicio, DataFim, LoginCadastro);

                    aluguelService.Salvar(aluguel);

                    Console.WriteLine("=====================================");
                    Console.WriteLine(" - Aluguel CADASTRADO com sucesso!");
                    Console.WriteLine("=====================================");
                }

            // ALUGUEL - EXCLUIR ALUGUEL POR ID
                else if (opcao == 11)
                {
                    Listar.AluguelMostrarTodos();
                    Console.Write("Informe o ID do aluguel para excluir: ");
                    int idAluguel = Convert.ToInt32(Console.ReadLine());

                    aluguelService.Remover(idAluguel);

                    Console.WriteLine("=====================================");
                    Console.WriteLine(" - Aluguel DELETADO com sucesso!");
                    Console.WriteLine("=====================================");
                }

            // ALUGUEL - ATUALIZAR ALUGUEL POR ID
                else if (opcao == 12)
                {
                    Listar.AluguelMostrarTodos();
                    Console.Write("Informe o Id do aluguel para atualizar: ");
                    int idAluguel = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("=====================================");
                    Console.WriteLine("Informe os novos dados do Aluguel:");
                    Console.WriteLine("=====================================");
                    Listar.ClienteMostrarIdNome();
                    Console.Write(">>> Id do Cliente: ");
                    int IdCliente = Convert.ToInt32(Console.ReadLine());
                    Listar.VeiculoMostrarIdModeloSituacao();
                    Console.Write(">>> Id do Veiculo: ");
                    int IdVeiculo = Convert.ToInt32(Console.ReadLine());
                    Console.Write(">>> Início do Aluguel - DATA: ");
                    DateTime DataInicio = Convert.ToDateTime(Console.ReadLine());
                    Console.Write(">>> Fim do Aluguel - DATA: ");
                    DateTime DataFim = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Login de Cadastro: ");
                    string LoginCadastro = Console.ReadLine();

                //  VALIDAÇÃO DO LOGIN
                    while (!Validacao.Validar.Login(LoginCadastro))
                    {
                        Console.WriteLine("=====================================");
                        Console.WriteLine("###### - LOGIN INVALIDO! - ######");
                        Console.WriteLine("Digite novamente.");
                        Console.Write("Login de Cadastro: ");
                        LoginCadastro = Console.ReadLine();
                        Console.WriteLine("=====================================");
                    }
                    Aluguel aluguel = new Aluguel(IdCliente, IdVeiculo, DataInicio, DataFim, LoginCadastro);

                    aluguelService.Atualizar(idAluguel, aluguel);

                    Console.WriteLine("=====================================");
                    Console.WriteLine(" - Aluguel ATUALIZADO com sucesso!");
                    Console.WriteLine("=====================================");
                }

            // SITUAÇÃO - CADASTRAR SITUAÇÃO
                else if (opcao == 13)
                {
                    Listar.VeiculoMostrarIdModelo();
                    Console.Write(" Digite o ID do veiculo para cadastrar a SITUAÇÃO: ");
                    int IdVeiculo = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("=====================================");
                    Console.WriteLine("   Informe a Situação do Veiculo:    ");
                    Console.WriteLine("=====================================");
                    Console.WriteLine(" [ 1 ] - Disponivel:");
                    Console.WriteLine(" [ 2 ] - Alugado");
                    Console.WriteLine(" [ 3 ] - Em Manutenção");
                    Console.WriteLine(" [ 4 ] - Vendido");
                    Console.Write(">>> Situação: ");
                    int resposta = Convert.ToInt32(Console.ReadLine());
                    string Nome = "";
                    while (true)
                    {
                        if (resposta == 1)
                        {
                            Nome = "Disponivel";
                            break;
                        }
                        else if (resposta == 2)
                        {
                            Nome = "Alugado";
                            break;
                        }
                        else if (resposta == 3)
                        {
                            Nome = "Em Manutenção";
                            break;
                        }
                        else if (resposta == 4)
                        {
                            Nome = "Vendido";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("OPÇÃO INVALIDA!!! - Digite novamente.");
                        }
                    }
                    Console.Write("Login de Cadastro: ");
                    string LoginCadastro = Console.ReadLine();
                    Console.WriteLine("=====================================");

                //  VALIDAÇÃO DO LOGIN
                    while (!Validacao.Validar.Login(LoginCadastro))
                    {
                        Console.WriteLine("=====================================");
                        Console.WriteLine("###### - LOGIN INVALIDO! - ######");
                        Console.WriteLine("Digite novamente.");
                        Console.Write("Login de Cadastro: ");
                        LoginCadastro = Console.ReadLine();
                        Console.WriteLine("=====================================");
                    }
                    Situacao situacao = new Situacao(Nome, LoginCadastro);

                    situacaoService.Cadastrar(IdVeiculo, situacao);
                    Console.WriteLine("=====================================");
                    Console.WriteLine(" - Situação Atualizada com sucesso!");
                    Console.WriteLine("=====================================");

                }

            // SITUAÇÃO - ATUALIZAR SITUAÇÃO
                else if (opcao == 14)
                {
                    Listar.VeiculoMostrarIdModelo();
                    Console.Write(" Digite o ID do veiculo para atualizar a SITUAÇÃO: ");
                    int IdVeiculo = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("=====================================");
                    Console.WriteLine("   Informe a Situação do Veiculo:    ");
                    Console.WriteLine("=====================================");
                    Console.WriteLine(" [ 1 ] - Disponivel:");
                    Console.WriteLine(" [ 2 ] - Alugado");
                    Console.WriteLine(" [ 3 ] - Em Manutenção");
                    Console.WriteLine(" [ 4 ] - Vendido");
                    Console.Write(">>> Situação: ");
                    int resposta = Convert.ToInt32(Console.ReadLine());
                    string Nome = "";
                    while (true)
                    {
                        if (resposta == 1)
                        {
                            Nome = "Disponivel";
                            break;
                        }
                        else if (resposta == 2)
                        {
                            Nome = "Alugado";
                            break;
                        }
                        else if (resposta == 3)
                        {
                            Nome = "Em Manutenção";
                            break;
                        }
                        else if (resposta == 4)
                        {
                            Nome = "Vendido";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("OPÇÃO INVALIDA!!! - Digite novamente.");
                        }
                    }

                    Console.Write("Login de Cadastro: ");
                    string LoginCadastro = Console.ReadLine();
                    Console.WriteLine("=====================================");

                    Situacao situacao = new Situacao(Nome, LoginCadastro);

                    situacaoService.Atualizar(IdVeiculo, situacao);

                    Console.WriteLine("=====================================");
                    Console.WriteLine(" - Veiculo atualizado com sucesso!");
                    Console.WriteLine("=====================================");
                }

            // CONTROLE DE FROTA
                else if (opcao == 15)
                {
                    Listar.AluguelControle();

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
