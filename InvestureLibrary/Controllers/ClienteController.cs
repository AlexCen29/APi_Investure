using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InvestureLibrary.Domain.Entities;
using InvestureLibrary.Services.Features.Clientes;
using InvestureLibrary.Domain.Dtos;

namespace InvestureLibrary.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetAllClientes()
        {
            var clientes = await _clienteService.GetAllClientesAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetClienteById(int id)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ClienteCreateDTO nota)
        {
            await _clienteService.Add(nota);

            return Ok(nota);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, [FromBody] ClienteUpdateDTO cliente)
        {
            await _clienteService.UpdateClienteAsync(id, cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            await _clienteService.DeleteClienteAsync(id);
            return NoContent();
        }
    }
}