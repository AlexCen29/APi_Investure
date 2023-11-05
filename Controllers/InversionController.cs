using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Services.Features.Inversiones;
using Microsoft.AspNetCore.Mvc;
using JaveragesLibrary.Infrastructure.Data;

namespace InvestureLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class InversionController : ControllerBase
    {
        private readonly InversionService _inversionesService;
        private readonly IMapper _mapper;

        public InversionController(InversionService inversionesService, IMapper mapper)
        {
            this._inversionesService = inversionesService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] InversionQueryFilter mangaQueryFilter)
        {
            var mangas = await _inversionesService.GetAll(mangaQueryFilter);
            var mangaDtos = _mapper.Map<IEnumerable<InversionDTO>>(mangas);

            return Ok(mangaDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var inversion = await _inversionesService.GetById(id);

            if (inversion.Id <= 0)
                return NotFound();

            var dto = _mapper.Map<InversionDTO>(inversion);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(InversionCreateDTO inversion)
        {
            await _inversionesService.Add(inversion);

            // Después de agregar la inversión, la entidad creada tendrá un ID asignado.
            // Puedes obtenerlo así:
            /// Asumiendo que la entidad tiene una propiedad Id

            // Luego uedes devolver el ID en la respuesta.
            return Ok(inversion);
        }

        [HttpPut("{id}")]
public async Task<IActionResult> Update(int id, InversionUpdateDTO inversionUpdate)
{
    // Asigna el ID a inversionUpdate
    inversionUpdate.Id = id;

    await _inversionesService.Update(inversionUpdate);
    
    return NoContent();
}



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _inversionesService.Delete(id);
            return NoContent();
        }
    }
}