using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using Client.Dtos;
using Client.Models;

namespace Client.Service
{
    class SituacaoService
    {
        public void Cadastrar(int IdVeiculo, Situacao situacao)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var viewModel = new
            {
                IdEncontrar = IdVeiculo,
                Cadastrar = situacao
            };

            try
            {
                var json = JsonConvert.SerializeObject(viewModel);
                //monta a request para a api;
                response = httpClient.PostAsync($"https://localhost:44335/situacao/cadastrar", new StringContent(json, Encoding.UTF8, "application/json")).Result;

                var resultado = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(resultado);
                }

                //converte os dados recebidos e retorna eles como objetos do C#;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Atualizar(int idVeiculo, Situacao situacao)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var viewModel = new
            {
                IdEncontrar = idVeiculo,
                Atualizar = situacao
            };

            try
            {
                var json = JsonConvert.SerializeObject(viewModel);
                // MONTA A REQUEST PARA A API;
                response = httpClient.PutAsync($"https://localhost:44335/situacao/atualizar", new StringContent(json, Encoding.UTF8, "application/json")).Result;

                // CONVERTE OS DADOS RECEBIDOS E RETORNA ELES COMO OBJETOS DE C#;
                var resultado = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(resultado);
                }

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
