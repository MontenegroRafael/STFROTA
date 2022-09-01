using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Dtos
{
    public class ClienteDto
    {
       

        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cnh { get; set; }
        public DateTime DataCadastro { get; set; }
        public string LoginCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public ClienteDto()
        {
        }

        public ClienteDto(int idCliente, string nome)
        {
            IdCliente = idCliente;
            Nome = nome;
        }
    }
}
