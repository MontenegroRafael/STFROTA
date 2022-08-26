﻿using Microsoft.AspNetCore.Http;
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
    public class ClienteController : ControllerBase
    {
        //private static readonly List<Cliente> clientes = new List<Cliente>();

        ClienteAccessBanco repositorioCliente = new ClienteAccessBanco();
        private object _clientes;

        [HttpPost]
        public IActionResult Save(Cliente cliente)
        {
            if (cliente == null)
                return NoContent();

            repositorioCliente.SalvarCliente(cliente);

            return Ok("Adicionado com sucesso!");
        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            var clientes = repositorioCliente.BuscarTodos();

            if (clientes == null || !clientes.Any())
                return NotFound(new { mensage = $"Lista vazia." });

            return Ok(clientes);

        }
        [HttpPut]
        public IActionResult Atualizar(AtualizarClienteModel model)
        {
            //if (model == null)
            //    return NoContent();
            //if (model.Atualizar == null)
            //    return NoContent();
            //if (model.Encontrar == null)
            //    return NoContent();

            var cEncontrado = repositorioCliente.Atualizar(model.IdEncontrar, model.Atualizar);

            //if (cEncontrado == null)
            //    return NotFound("Não há nenhum registro com esse nome.");

            //cEncontrado.Nome = model.Atualizar.Nome;
            //cEncontrado.Cnh = model.Atualizar.Cnh;
            //cEncontrado.DataCadastro = model.Atualizar.DataCadastro;
            //cEncontrado.LoginCadastro = model.Atualizar.LoginCadastro;


            return Ok(cEncontrado);
        }

        //[HttpDelete]
        //public IActionResult Remover(DeletarClienteModel model)
        //{
        //    if (model.IsNullOrEmpty(nome))
        //        return NoContent();

        //    var cliente = repositorioCliente.DeletarPorNome(nome);

        //    if (cliente == null)
        //        return NotFound();

        //    clientes.Remover(cliente);
        //    return Ok("Removido com sucesso!");
        //}
    }
}
