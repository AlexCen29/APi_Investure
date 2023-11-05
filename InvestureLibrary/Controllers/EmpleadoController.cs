using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Services.Features.Empleados;
using Microsoft.AspNetCore.Mvc;

namespace JaveragesLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly EmpleadoService _empleadoService;
        private readonly IMapper _mapper;

        public EmpleadoController(EmpleadoService empleadoService, IMapper mapper)
        {
            _empleadoService = empleadoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] EmpleadoQueryFilter empleadoQueryFilter)
        {
            var empleados = await _empleadoService.GetAll(empleadoQueryFilter);
            var empleadoDtos = _mapper.Map<IEnumerable<EmpleadoDTO>>(empleados);

            return Ok(empleadoDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var empleado = await _empleadoService.GetById(id);

            if (empleado.Id <= 0)
                return NotFound();

            var dto = _mapper.Map<EmpleadoDTO>(empleado);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmpleadoCreateDTO empleado)
        {
            await _empleadoService.Add(empleado);

            // Después de agregar el empleado, la entidad creada tendrá un ID asignado.
            // Puedes obtenerlo así:
            // Asumiendo que la entidad tiene una propiedad Id

            // Luego puedes devolver el ID en la respuesta.
            return Ok(empleado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EmpleadoUpdateDTO empleadoUpdate)
        {
            // Asigna el ID a empleadoUpdate
            empleadoUpdate.Id = id;

            await _empleadoService.Update(empleadoUpdate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _empleadoService.Delete(id);
            return NoContent();
        }
    }
}
