using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using STFROTA.Models;
using STFROTA.Repositories;
using STFROTA.ViewModels;
using Dapper;

namespace STFROTA.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AluguelController : ControllerBase
    {
        AluguelAccessBanco repositorioAluguel = new AluguelAccessBanco();

        [HttpPost]  // CADASTRAR ALUGUEL
        public IActionResult Save(Aluguel aluguel)
        {
            if (aluguel == null)
                return NoContent();

            repositorioAluguel.SalvarAluguel(aluguel);

            return Ok("Adicionado com sucesso!");
        }

        [HttpGet]  // MOSTRAR LISTA DE ALUGUEL
        public IActionResult BuscarTodos()
        {
            var aluguel = repositorioAluguel.BuscarTodos();

            if (aluguel == null || !aluguel.Any())
                return NotFound(new { mensage = $"Lista vazia." });

            return Ok(aluguel);

        }

    }
    
}
