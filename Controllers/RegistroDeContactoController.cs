using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Services.Features.RegistroDeContactos;
using Microsoft.AspNetCore.Mvc;

namespace JaveragesLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistroDeContactoController : ControllerBase
    {
        private readonly RegistroDeContactoService _registroDeContactoService;
        private readonly IMapper _mapper;

        public RegistroDeContactoController(RegistroDeContactoService registroDeContactoService, IMapper mapper)
        {
            _registroDeContactoService = registroDeContactoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RegistroDeContactoQueryFilter filtro)
        {
            var registros = await _registroDeContactoService.GetAll(filtro);
            var registroDtos = _mapper.Map<IEnumerable<RegistroDeContactoDTO>>(registros);

            return Ok(registroDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var registro = await _registroDeContactoService.GetById(id);

            if (registro == null)
                return NotFound();

            var dto = _mapper.Map<RegistroDeContactoDTO>(registro);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RegistroDeContactoCreateDTO registro)
        {
            await _registroDeContactoService.Add(registro);

            // Después de agregar el registro, la entidad creada tendrá un ID asignado.
            // Puedes obtenerlo así:
            // Asumiendo que la entidad tiene una propiedad Id

            // Luego puedes devolver el ID en la respuesta.
            return Ok(registro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RegistroDeContactoUpdateDTO registroUpdate)
        {
            // Asigna el ID a registroUpdate
            registroUpdate.Id = id;

            await _registroDeContactoService.Update(registroUpdate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _registroDeContactoService.Delete(id);
            return NoContent();
        }
    }
}
