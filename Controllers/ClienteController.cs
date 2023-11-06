using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Services.Features.Clientes; // Asegúrate de importar el servicio correcto
using Microsoft.AspNetCore.Mvc;

namespace JaveragesLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(ClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ClienteQueryFilter clienteQueryFilter)
        {
            var clientes = await _clienteService.GetAll(clienteQueryFilter);
            var clienteDtos = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);

            return Ok(clienteDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _clienteService.GetById(id);

            if (cliente.Id <= 0)
                return NotFound();

            var dto = _mapper.Map<ClienteDTO>(cliente);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ClienteCreateDTO cliente)
        {
            await _clienteService.Add(cliente);

            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ClienteUpdateDTO clienteUpdate)
        {
        
            clienteUpdate.Id = id;

            await _clienteService.Update(clienteUpdate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clienteService.Delete(id);
            return NoContent();
        }
    }
}
