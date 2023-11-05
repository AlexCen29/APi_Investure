using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Services.Features.Notas; // Asegúrate de usar el servicio correcto para Notas
using JaveragesLibrary.Infrastructure.Data;

namespace InvestureLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotaController : ControllerBase // Cambiado el nombre del controlador a NotaController
    {
        private readonly NotaService _notaService; // Asegúrate de tener el servicio correcto para Notas
        private readonly IMapper _mapper;

        public NotaController(NotaService notaService, IMapper mapper)
        {
            this._notaService = notaService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] NotaQueryFilter notaQueryFilterQueryFilter)
        {
            var notas = await _notaService.GetAll(notaQueryFilterQueryFilter);
            var notaDtos = _mapper.Map<IEnumerable<NotaDTO>>(notas);

            return Ok(notaDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var nota = await _notaService.GetById(id);

            if (nota.Id <= 0)
                return NotFound();

            var dto = _mapper.Map<NotaDTO>(nota);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(NotaCreateDTO nota)
        {
            await _notaService.Add(nota);

            return Ok(nota);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, NotaUpdateDTO notaUpdate)
        {
            // Asigna el ID a notaUpdate
            notaUpdate.Id = id;

            await _notaService.Update(notaUpdate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _notaService.Delete(id);
            return NoContent();
        }
    }
}
