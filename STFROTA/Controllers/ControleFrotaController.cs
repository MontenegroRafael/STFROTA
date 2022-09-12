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
    public class ControleFrotaController : ControllerBase
    {
        ControleFrotaAccessBanco repositorioControleFrota = new ControleFrotaAccessBanco();

        //[HttpGet]  // MOSTRAR LISTA DE CLIENTES
        //public IActionResult BuscarTodos()
        //{
        //    var controle = repositorioControleFrota.BuscarTodos();

        //    if (controle == null || !controle.Any())
        //        return NotFound(new { mensage = $"Lista vazia." });

        //    return Ok(clientes);

        //}
    }
}
