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
        SituacaoAccessBanco repositorioSituacao = new SituacaoAccessBanco();

        [HttpPost]  // CADASTRAR SITUAÇÃO DO VEICULO POR ID
        public IActionResult Cadastrar(CadastrarSituacaoModel situacao)

             SituacaoAccessBanco repositorioSituacao = new SituacaoAccessBanco();

        {
            var vEncontrado = repositorioSituacao.Cadastrar(situacao.IdEncontrar, situacao.Cadastrar);
            return Ok(vEncontrado);
        }
    }
}
