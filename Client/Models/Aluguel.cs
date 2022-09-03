using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Models
{
    class Aluguel
    {
        public int IdAluguel { get; set; }
        public int IdCliente { get; set; }
        public int IdVeiculo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public DateTime DataCadastro { get; set; }
        public string LoginCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public Aluguel()
        {

        }

        public Aluguel(int idCliente, int idVeiculo, DateTime dataInicio, DateTime dataFim, string loginCadastro)
        {
            IdCliente = idCliente;
            IdVeiculo = idVeiculo;
            DataInicio = dataInicio;
            DataFim = dataFim;
            DataCadastro = DateTime.Now;
            LoginCadastro = loginCadastro;
            
        }
    }
}
