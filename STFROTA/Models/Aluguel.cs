using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STFROTA.Models
{
    public class Aluguel
    {
        public DateTime DataInicio  { get; set; }
        public DateTime DataFim { get; set; }
        public string Cnh { get; set; }
        public DateTime DataCadastro { get; set; }
        public string LoginCadastro { get; set; }
    }
}

