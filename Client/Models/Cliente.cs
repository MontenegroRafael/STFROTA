using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Models
{
    class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cnh { get; set; }
        public DateTime DataCadastro { get; set; }
        public string LoginCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public Cliente()
        {
        }

        public Cliente(string nome, string cnh, DateTime dataCadastro, string loginCadastro)
        {
            Nome = nome;
            Cnh = cnh;
            DataCadastro = dataCadastro;
            LoginCadastro = loginCadastro;
            DataAtualizacao = DateTime.Now;
        }

        public Cliente(int idCliente, string nome)
        {
            IdCliente = idCliente;
            Nome = nome;
        }

        public Cliente(string nome, string cnh, string loginCadastro)
        {
            Nome = nome;
            Cnh = cnh;
            LoginCadastro = loginCadastro;
            DataAtualizacao = DateTime.Now;
        }
    }
}

