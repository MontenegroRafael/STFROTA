using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Models
{
    public class Situacao
    {
        
        public int IdSituacao { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public string LoginCadastro { get; set; }
        public Veiculo IdVeiculo { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public Situacao(string nome, string loginCadastro)
        {
            Nome = nome;
            DataCadastro = DateTime.Now;
            LoginCadastro = loginCadastro;
            DataAtualizacao = DateTime.Now;
        }

    }

}
