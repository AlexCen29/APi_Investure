using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Infrastructure.Data;
using JaveragesLibrary.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JaveragesLibrary.Services.Features.SeguimientoDeTareas
{
    public class SeguimientoDeTareaService
    {
        private readonly SeguimientoDeTareaRepository _tareaRepository;
        private readonly IMapper _mapper;
        private readonly JaveragesLibraryDbContext _dbContext;

        public SeguimientoDeTareaService(JaveragesLibraryDbContext dbContext, SeguimientoDeTareaRepository tareaRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _tareaRepository = tareaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SeguimientoDeTarea>> GetAll(SeguimientoDeTareaQueryFilter tareaQueryFilter)
        {
            return await _tareaRepository.GetAll(tareaQueryFilter);
        }

        public async Task<SeguimientoDeTareaDTO> GetById(int id)
        {
            var tarea = await _tareaRepository.GetById(id);
            return _mapper.Map<SeguimientoDeTareaDTO>(tarea);
        }

        public int GetNextId()
        {
            int nextId = (_dbContext.SeguimientoDeTareas.Max(t => (int?)t.Id) ?? 0) + 1;
            return nextId;
        }

        public async Task Add(SeguimientoDeTareaCreateDTO tarea)
        {
            var entity = _mapper.Map<SeguimientoDeTarea>(tarea);
            _dbContext.SeguimientoDeTareas.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(SeguimientoDeTareaUpdateDTO tareaUpdate)
        {
            var existingTarea = await _tareaRepository.GetById(tareaUpdate.Id);

            if (existingTarea == null)
            {
                throw new InvalidOperationException("La tarea no se encontró.");
            }

            existingTarea.IdEmpleado_fk = tareaUpdate.IdEmpleado_fk;
            existingTarea.Tarea = tareaUpdate.Tarea;
            existingTarea.FechaInicio = tareaUpdate.FechaInicio;
            existingTarea.FechaFin = tareaUpdate.FechaFin;
            existingTarea.Completada = tareaUpdate.Completada;

            await _tareaRepository.Update(existingTarea);
        }

        public async Task Delete(int id)
        {
            await _tareaRepository.Delete(id);
        }
    }
}
