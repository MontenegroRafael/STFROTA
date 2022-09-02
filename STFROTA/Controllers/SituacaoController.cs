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
    public class SituacaoController : ControllerBase
    {
        [HttpPost]  // CADASTRAR SITUAÇÃO DO VEICULO POR ID
        public IActionResult Atualizar(AtualizarVeiculoModel veiculo)

             SituacaoAccessBanco repositorioSituacao = new SituacaoAccessBanco();

        {
            var vEncontrado = repositorioSituacao.Cadastrar(veiculo.IdEncontrar, veiculo.Atualizar);
            return Ok(vEncontrado);
        }
    }
}
