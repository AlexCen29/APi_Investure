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

namespace JaveragesLibrary.Services.Features.Eventos
{
    public class EventoService
    {
        private readonly EventoRepository _eventoRepository;
        private readonly IMapper _mapper;
        private readonly JaveragesLibraryDbContext _dbContext;

        public EventoService(JaveragesLibraryDbContext dbContext, EventoRepository eventoRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _eventoRepository = eventoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Evento>> GetAll(EventoQueryFilter eventoQueryFilter) // Cambia Empleado a EventoQueryFilter
        {
            return await _eventoRepository.GetAll(eventoQueryFilter); // Cambia Empleado a EventoQueryFilter
        }

        public async Task<EventoDTO> GetById(int id) // Cambia Empleado a Evento
        {
            var evento = await _eventoRepository.GetById(id); // Cambia Empleado a Evento
            return _mapper.Map<EventoDTO>(evento); // Cambia Empleado a Evento
        }

        public int GetNextId()
        {
            int nextId = (_dbContext.Eventos.Max(e => (int?)e.Id) ?? 0) + 1; // Cambia Empleados a Eventos
            return nextId; // Cambia Empleados a Eventos
        }

        public async Task Add(EventoCreateDTO evento) // Cambia EmpleadoCreateDTO a EventoCreateDTO
        {
            var entity = _mapper.Map<Evento>(evento); // Cambia Empleado a Evento
            _dbContext.Eventos.Add(entity); // Cambia Empleados a Eventos
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(EventoUpdateDTO eventoUpdate) // Cambia EmpleadoUpdateDTO a EventoUpdateDTO
        {
            var existingEvento = await _eventoRepository.GetById(eventoUpdate.Id); // Cambia Empleado a Evento

            if (existingEvento == null)
            {
                throw new InvalidOperationException("El evento no se encontró.");
            }

            existingEvento.Tipo = eventoUpdate.Tipo; // Agrega las propiedades que desees actualizar
            existingEvento.Descripcion = eventoUpdate.Descripcion;
            existingEvento.FechaDeCreacion = eventoUpdate.FechaDeCreacion;
            existingEvento.FechaCita = eventoUpdate.FechaCita;

            await _eventoRepository.Update(existingEvento); // Cambia Empleado a Evento
        }

        public async Task Delete(int id) // Cambia Empleado a Evento
        {
            await _eventoRepository.Delete(id); // Cambia Empleado a Evento
        }
    }
}
