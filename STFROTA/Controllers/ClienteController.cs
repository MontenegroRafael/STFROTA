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


namespace STFROTA.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteAccessBanco _clienteRepository;

        public ClienteController()
        {
            _clienteRepository = new ClienteAccessBanco();
        }

        [HttpPost]
        public IActionResult Salvar(SalvarCliente salvarCliente)
        {
            if (salvarCliente == null)
                return Ok("Não foram informados dados");

            if (salvarCliente.Cliente == null)
                return Ok("Dados da pessoa não informados.");

            var resultado = _clienteRepository.SalvarCliente(salvarCliente.Cliente);

            if (resultado) return Ok("Cliente cadastrado com sucesso.");

            return Ok("Houve um problema ao salvar. Cliente não cadastrado.");
        }
        [HttpPost]
        public IActionResult BuscarPorNome(string nome)
        {
            var resultado = _clienteRepository.BuscarPorNome(nome);

            if (resultado == null || !resultado.Any())
                return NotFound("Nenhum registro encontrado com o nome informado.");

            return Ok(resultado);
        }

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            var resultado = _clienteRepository.BuscarTodos();

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }
    }
}
