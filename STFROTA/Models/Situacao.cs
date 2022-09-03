using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STFROTA.Models
{
    public class Situacao
    {
        public int IdSituacao { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public string LoginCadastro { get; set; }
        public Veiculo IdVeiculo { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public Situacao()
        {
        }
    }
}
