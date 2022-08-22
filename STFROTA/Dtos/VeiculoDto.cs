﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STFROTA.Dtos
{
    public class VeiculoDto
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public DateTime DataCadastro { get; set; }
        public string LoginCadastro { get; set; }
    }
}
