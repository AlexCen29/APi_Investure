
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Services.Features.Permisos;
using Microsoft.AspNetCore.Mvc;

namespace InvestureLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermisoController : ControllerBase
    {
        private readonly PermisoService _permisoService;
        private readonly IMapper _mapper;

        public PermisoController(PermisoService permisoService, IMapper mapper)
        {
            _permisoService = permisoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PermisoQueryFilter permisoQueryFilter)
        {
            var permisos = await _permisoService.GetAll(permisoQueryFilter);
            var permisoDtos = _mapper.Map<IEnumerable<PermisoDTO>>(permisos);

            return Ok(permisoDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var permiso = await _permisoService.GetById(id);

            if (permiso.Id <= 0)
                return NotFound();

            var dto = _mapper.Map<PermisoDTO>(permiso);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PermisoCreateDTO permiso)
        {
            await _permisoService.Add(permiso);

            // Después de agregar el permiso, la entidad creada tendrá un ID asignado.
            // Puedes obtenerlo así:
            // Asumiendo que la entidad tiene una propiedad Id

            // Luego puedes devolver el ID en la respuesta.
            return Ok(permiso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PermisoUpdateDTO permisoUpdate)
        {
            // Asigna el ID a permisoUpdate
            permisoUpdate.Id = id;

            await _permisoService.Update(permisoUpdate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _permisoService.Delete(id);
            return NoContent();
        }
    }
}
