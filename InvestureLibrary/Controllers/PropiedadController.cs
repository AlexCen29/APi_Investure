using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Services.Features.Empleados; // Asegúrate de usar el servicio correcto para Empleados
using Microsoft.AspNetCore.Mvc;
using JaveragesLibrary.Services.Features.Propiedades;
using JaveragesLibrary.Infrastructure.Data;


namespace InvestureLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropiedadController : ControllerBase
    {
        private readonly IPropiedadService _service;
        private readonly IMapper _mapper;

        public PropiedadController(IPropiedadService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PropiedadDTO>> GetPropiedad(int id)
        {
            var propiedad = await _service.GetPropiedadByIdAsync(id);

            if (propiedad == null)
            {
                return NotFound();
            }

            return _mapper.Map<PropiedadDTO>(propiedad);
        }
       [HttpPost]
public async Task<ActionResult> CreatePropiedad([FromBody] PropiedadCreateDTO createDTO)
{
    if (createDTO == null)
    {
        return BadRequest("El DTO de la propiedad no puede ser nulo.");
    }

    var propiedad = _mapper.Map<Propiedad>(createDTO); // Convertir el DTO a una instancia de Propiedad

    await _service.CreatePropiedadAsync(propiedad);

    return Ok();
}


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePropiedad(int id, [FromBody] PropiedadUpdateDTO updateDTO)
        {
            if (updateDTO == null || id != updateDTO.Id)
            {
                return BadRequest("Los datos de la propiedad no son válidos.");
            }

            var existingPropiedad = await _service.GetPropiedadByIdAsync(id);

            if (existingPropiedad == null)
            {
                return NotFound("Propiedad no encontrada.");
            }

            var propiedad = _mapper.Map<PropiedadDTO>(updateDTO);
            propiedad.Id = id;

            await _service.UpdatePropiedadAsync(propiedad);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePropiedad(int id)
        {
            var existingPropiedad = await _service.GetPropiedadByIdAsync(id);

            if (existingPropiedad == null)
            {
                return NotFound("Propiedad no encontrada.");
            }

            await _service.DeletePropiedadAsync(id);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Propiedad>>> GetAllPropiedades()
        {
            var propiedades = await _service.GetAllPropiedadesAsync();
            return _mapper.Map<List<Propiedad>>(propiedades);
        }
    }

}