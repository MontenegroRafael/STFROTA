using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Dtos
{
    class SituacaoDto
    {
        public int IdSituacao { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public string LoginCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

    }
}
