using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STFROTA.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnh { get; set; }
        public DateTime DataCadastro { get; set; }
        public string LoginCadastro { get; set; }
    }
}
