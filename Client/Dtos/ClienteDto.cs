using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Dtos
{
    class ClienteDto
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cnh { get; set; }
        public DateTime DataCadastro { get; set; }
        public string LoginCadastro { get; set; }
    }
}
