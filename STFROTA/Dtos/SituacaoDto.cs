using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STFROTA.Models;

namespace STFROTA.Dtos
{
    public class SituacaoDto
    {
        public int IdSituacao { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public string LoginCadastro { get; set; }
        public Veiculo IdVeiculo { get; set; }
        public DateTime DataAtualizacao { get; set; }

    }
}
