using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Services.Features.SeguimientoDeTareas;
using Microsoft.AspNetCore.Mvc;

namespace JaveragesLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguimientoDeTareaController : ControllerBase
    {
        private readonly SeguimientoDeTareaService _seguimientoDeTareaService;
        private readonly IMapper _mapper;

        public SeguimientoDeTareaController(SeguimientoDeTareaService seguimientoDeTareaService, IMapper mapper)
        {
            _seguimientoDeTareaService = seguimientoDeTareaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] SeguimientoDeTareaQueryFilter seguimientoDeTareaQueryFilter)
        {
            var seguimientoDeTareas = await _seguimientoDeTareaService.GetAll(seguimientoDeTareaQueryFilter);
            var seguimientoDeTareaDtos = _mapper.Map<IEnumerable<SeguimientoDeTareaDTO>>(seguimientoDeTareas);

            return Ok(seguimientoDeTareaDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var seguimientoDeTarea = await _seguimientoDeTareaService.GetById(id);

            if (seguimientoDeTarea.Id <= 0)
                return NotFound();

            var dto = _mapper.Map<SeguimientoDeTareaDTO>(seguimientoDeTarea);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SeguimientoDeTareaCreateDTO seguimientoDeTarea)
        {
            await _seguimientoDeTareaService.Add(seguimientoDeTarea);

            return Ok(seguimientoDeTarea);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SeguimientoDeTareaUpdateDTO seguimientoDeTareaUpdate)
        {
            seguimientoDeTareaUpdate.Id = id;

            await _seguimientoDeTareaService.Update(seguimientoDeTareaUpdate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _seguimientoDeTareaService.Delete(id);
            return NoContent();
        }
    }
}
