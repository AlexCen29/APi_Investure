using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Services.Features.Empresas; // Asegúrate de usar el servicio correcto para Empresas
using Microsoft.AspNetCore.Mvc;
using JaveragesLibrary.Infrastructure.Data;

namespace InvestureLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly EmpresaService _empresaService; // Asegúrate de tener el servicio correcto para Empresas
        private readonly IMapper _mapper;

        public EmpresaController(EmpresaService empresaService, IMapper mapper)
        {
            this._empresaService = empresaService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] EmpresaQueryFilter empresaQueryFilter)
        {
            var empresas = await _empresaService.GetAll(empresaQueryFilter);
            var empresaDtos = _mapper.Map<IEnumerable<EmpresaDTO>>(empresas);

            return Ok(empresaDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var empresa = await _empresaService.GetById(id);

            if (empresa.Id <= 0)
                return NotFound();

            var dto = _mapper.Map<EmpresaDTO>(empresa);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmpresaCreateDTO empresa)
        {
            await _empresaService.Add(empresa);

            // Después de agregar la empresa, la entidad creada tendrá un ID asignado.
            // Puedes obtenerlo así:
            /// Asumiendo que la entidad tiene una propiedad Id

            // Luego puedes devolver el ID en la respuesta.
            return Ok(empresa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EmpresaUpdateDTO empresaUpdate)
        {
            // Asigna el ID a empresaUpdate
            empresaUpdate.Id = id;

            await _empresaService.Update(empresaUpdate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _empresaService.Delete(id);
            return NoContent();
        }
    }
}
