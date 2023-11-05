using AutoMapper;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Services.Features.AsignarPermisos;
using Microsoft.AspNetCore.Mvc;

namespace JaveragesLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsignarPermisoController : ControllerBase
    {
        private readonly AsignarPermisoService _asignarPermisoService;
        private readonly IMapper _mapper;

        public AsignarPermisoController(AsignarPermisoService asignarPermisoService, IMapper mapper)
        {
            _asignarPermisoService = asignarPermisoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] AsignarPermisoQueryFilter asignarPermisoQueryFilter)
        {
            var asignarPermisos = await _asignarPermisoService.GetAll(asignarPermisoQueryFilter);
            var asignarPermisoDtos = _mapper.Map<IEnumerable<AsignarPermisoDTO>>(asignarPermisos);

            return Ok(asignarPermisoDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var asignarPermiso = await _asignarPermisoService.GetById(id);

            if (asignarPermiso.Id <= 0)
                return NotFound();

            var dto = _mapper.Map<AsignarPermisoDTO>(asignarPermiso);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AsignarPermisoCreateDTO asignarPermiso)
        {
            await _asignarPermisoService.Add(asignarPermiso);

            // Después de agregar el permiso, la entidad creada tendrá un ID asignado.
            // Puedes obtenerlo así:
            // Asumiendo que la entidad tiene una propiedad Id

            // Luego puedes devolver el ID en la respuesta.
            return Ok(asignarPermiso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AsignarPermisoUpdateDTO asignarPermisoUpdate)
        {
            // Asigna el ID a permisoUpdate
            asignarPermisoUpdate.Id = id;

            await _asignarPermisoService.Update(asignarPermisoUpdate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _asignarPermisoService.Delete(id);
            return NoContent();
        }
    }
}
