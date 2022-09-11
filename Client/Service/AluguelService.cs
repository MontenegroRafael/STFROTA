using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using Client.Dtos;
using Client.Models;

namespace Client.Service
{
    class AluguelService
    {
        public void Salvar(Aluguel aluguel)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var json = JsonConvert.SerializeObject(aluguel);

            try
            {
                //monta a request para a api;
                response = httpClient.PostAsync("https://localhost:44335/aluguel/save", new StringContent(json, Encoding.UTF8, "application/json")).Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                //converte os dados recebidos e retorna eles como objetos do C#;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<AluguelDto> BuscarTodos()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //BUSCA TODOS OS CLIENTES DENTRO DA API;
            try
            {
                //MONTA A REQUEST PARA A API;
                response = httpClient.GetAsync("https://localhost:44335/aluguel/buscartodos").Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(resultado);
                    return new List<AluguelDto>();
                }
                //CONVERTE OS DADOS RECEBIDOS E RETORNA ELES COMO OBJETOS DO C#;
                var objetoDesserializado = JsonConvert.DeserializeObject<List<AluguelDto>>(resultado);

                return objetoDesserializado;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<AluguelDto>();
            }
        }

        public void Atualizar(int idAluguel, Aluguel aluguel)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var viewModel = new
            {
                IdEncontrar = idAluguel,
                Atualizar = aluguel
            };

            try
            {
                var json = JsonConvert.SerializeObject(viewModel);
                // MONTA A REQUEST PARA A API;
                response = httpClient.PutAsync($"https://localhost:44335/aluguel/atualizar", new StringContent(json, Encoding.UTF8, "application/json")).Result;

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

        public void Remover(int idAluguel)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            try
            {
                // MONTA A REQUEST PARA A API;
                response = httpClient.DeleteAsync($"https://localhost:44335/aluguel/remover?modelo={idAluguel}").Result;

                // CONVERTE OS DADOS RECEBIDOS E RETORNA ELES COMO OBJETOS DO C#;
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
