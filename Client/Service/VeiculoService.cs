using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using Client.Dtos;
using Client.Models;

namespace Client.Service
{
    class VeiculoService
    {
        public List<VeiculoDto> BuscarTodos()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

        // BUSCA TODOS OS VEICULOS DENTRO DA API;
            try
            {
            // MONTA A REQUEST PARA A API;
                response = httpClient.GetAsync("https://localhost:44335/Veiculo/buscartodos").Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(resultado);
                    return new List<VeiculoDto>();
                }
            // CONVERTE OS DADOS RECEBIDOS E RETORNA ELES COMO OBJETOS DO C#;
                var objetoDesserializado = JsonConvert.DeserializeObject<List<VeiculoDto>>(resultado);

                return objetoDesserializado;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<VeiculoDto>();
            }
        }
        public void Salvar(Veiculo veiculo)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var json = JsonConvert.SerializeObject(veiculo);

            try
            {
            // MONTA A REQUEST PARA A API;
                response = httpClient.PostAsync("https://localhost:44335/veiculo/save", new StringContent(json, Encoding.UTF8, "application/json")).Result;
                response.EnsureSuccessStatusCode();

            // CONVERTE OS DADOS RECEBIDOS E RETORNA ELES COMO OBJETOS DE C#;
                var resultado = response.Content.ReadAsStringAsync().Result;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Remover(string modelo)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            try
            {
            // MONTA A REQUEST PARA A API;
                response = httpClient.DeleteAsync($"https://localhost:44335/veiculo/remover?modelo={modelo}").Result;

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


        public void Atualizar(int idVeiculo, Veiculo veiculo)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var viewModel = new
            {
                IdEncontrar = idVeiculo,
                Atualizar = veiculo
            };

            try
            {
                var json = JsonConvert.SerializeObject(viewModel);
            // MONTA A REQUEST PARA A API;
                response = httpClient.PutAsync($"https://localhost:44335/veiculo/atualizar", new StringContent(json, Encoding.UTF8, "application/json")).Result;

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
