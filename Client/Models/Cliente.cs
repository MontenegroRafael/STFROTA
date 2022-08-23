using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Models
{
    class Cliente
    {
        public string Nome { get; set; }
        public string Cnh { get; set; }
        public DateTime DataCadastro { get; set; }
        public string LoginCadastro { get; set; }

        public Cliente()
        {
        }
    }
}

