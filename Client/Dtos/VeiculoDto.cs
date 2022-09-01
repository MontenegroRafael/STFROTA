using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Dtos
{
    public class VeiculoDto
    {
        public int IdVeiculo { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public DateTime DataCadastro { get; set; }
        public string LoginCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public VeiculoDto()
        {
        }

        public VeiculoDto(int idVeiculo, string modelo, string placa)
        {
            IdVeiculo = idVeiculo;
            Modelo = modelo;
            Placa = placa;
        }
    }
}
