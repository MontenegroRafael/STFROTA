using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Dtos
{
    class AluguelDto
    {
        
        public int IdAluguel { get; set; }
        public int IdCliente { get; set; }
        public int IdVeiculo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public DateTime DataCadastro { get; set; }
        public string LoginCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public AluguelDto(int idCliente, int idVeiculo, DateTime dataInicio, DateTime dataFim, DateTime dataCadastro, string loginCadastro, DateTime dataAtualizacao)
        {
            IdCliente = idCliente;
            IdVeiculo = idVeiculo;
            DataInicio = dataInicio;
            DataFim = dataFim;
            DataCadastro = dataCadastro;
            LoginCadastro = loginCadastro;
            DataAtualizacao = dataAtualizacao;
        }

    }
}
