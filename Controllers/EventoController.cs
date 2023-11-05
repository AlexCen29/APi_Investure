using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Services.Features.Eventos; // Asegúrate de importar el servicio correcto
using Microsoft.AspNetCore.Mvc;

namespace JaveragesLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly EventoService _eventoService; // Asegúrate de inyectar el servicio correcto
        private readonly IMapper _mapper;

        public EventoController(EventoService eventoService, IMapper mapper)
        {
            _eventoService = eventoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] EventoQueryFilter eventoQueryFilter)
        {
            var eventos = await _eventoService.GetAll(eventoQueryFilter);
            var eventoDtos = _mapper.Map<IEnumerable<EventoDTO>>(eventos);

            return Ok(eventoDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var evento = await _eventoService.GetById(id);

            if (evento.Id <= 0)
                return NotFound();

            var dto = _mapper.Map<EventoDTO>(evento);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventoCreateDTO evento)
        {
            await _eventoService.Add(evento);

            // Después de agregar el evento, la entidad creada tendrá un ID asignado.
            // Puedes obtenerlo así:
            // Asumiendo que la entidad tiene una propiedad Id

            // Luego puedes devolver el ID en la respuesta.
            return Ok(evento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EventoUpdateDTO eventoUpdate)
        {
            // Asigna el ID a eventoUpdate
            eventoUpdate.Id = id;

            await _eventoService.Update(eventoUpdate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _eventoService.Delete(id);
            return NoContent();
        }
    }
}
