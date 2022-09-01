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
    public class VeiculoController : ControllerBase
    {

        VeiculoAccessBanco repositorioVeiculo = new VeiculoAccessBanco();
        //private object _veiculos;


        [HttpPost]  // CADASTRAR VEICULO
        public IActionResult Save(Veiculo veiculo)
        {
            if (veiculo == null)
                return NoContent();

            repositorioVeiculo.SalvarVeiculo(veiculo);

            return Ok("Adicionado com sucesso!");
        }

        [HttpGet]  // MOSTRAR LISTA DE VEICULOS
        public IActionResult BuscarTodos()
        {
            var veiculo = repositorioVeiculo.BuscarTodos();

            if (veiculo == null || !veiculo.Any())
                return NotFound(new { mensage = $"Lista vazia." });

            return Ok(veiculo);

        }

        [HttpPut]  // ATUALIZAR VEICULO POR ID
        public IActionResult Atualizar(AtualizarVeiculoModel veiculo)
        {
            var cEncontrado = repositorioVeiculo.Atualizar(veiculo.IdEncontrar, veiculo.Atualizar);
            return Ok(cEncontrado);
        }

        [HttpDelete]  // DELETAR VEICULO POR NOME
        public IActionResult Remover(string nome)
        {
            var cEncontrado = repositorioVeiculo.BuscarPorNome(nome);

            if (cEncontrado == null)
                return NotFound("Não há nenhum registro com esse nome.");

            repositorioVeiculo.Remover(cEncontrado);

            return Ok();
        }
    }
}
