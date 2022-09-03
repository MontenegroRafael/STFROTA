using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STFROTA.Models
{
    public class Aluguel
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

    }
}

