using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Models
{
    public class Veiculo
    {
        public int IdVeiculo { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public DateTime DataCadastro { get; set; }
        public string LoginCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public Veiculo(string modelo, string placa, string loginCadastro)
        {
            Modelo = modelo;
            Placa = placa;
            DataCadastro = DateTime.Now;
            LoginCadastro = loginCadastro;
            DataAtualizacao = DateTime.Now;
        }

        public Veiculo()
        {
        }

        public Veiculo(int idVeiculo, string modelo)
        {
            IdVeiculo = idVeiculo;
            Modelo = modelo;
        }
    }
}
