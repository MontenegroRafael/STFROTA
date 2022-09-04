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
    }
}
