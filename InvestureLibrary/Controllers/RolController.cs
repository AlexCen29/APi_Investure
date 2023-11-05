
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InvestureLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Services.Features.Roles;
using Microsoft.AspNetCore.Mvc;

namespace JaveragesLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly RolService _rolService;
        private readonly IMapper _mapper;

        public RolController(RolService rolService, IMapper mapper)
        {
            _rolService = rolService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RolQueryFilter rolQueryFilter)
        {
            var roles = await _rolService.GetAll(rolQueryFilter);
            var rolDtos = _mapper.Map<IEnumerable<RolDTO>>(roles);

            return Ok(rolDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rol = await _rolService.GetById(id);

            if (rol.Id <= 0)
                return NotFound();

            var dto = _mapper.Map<RolDTO>(rol);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RolCreateDTO rol)
        {
            await _rolService.Add(rol);

            // Después de agregar el permiso, la entidad creada tendrá un ID asignado.
            // Puedes obtenerlo así:
            // Asumiendo que la entidad tiene una propiedad Id

            // Luego puedes devolver el ID en la respuesta.
            return Ok(rol);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RolUpdateDTO rolUpdate)
        {
            // Asigna el ID a permisoUpdate
            rolUpdate.Id = id;

            await _rolService.Update(rolUpdate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _rolService.Delete(id);
            return NoContent();
        }
    }
}
