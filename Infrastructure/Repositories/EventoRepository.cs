using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Infrastructure.Data;
using JaveragesLibrary.Domain.Entities;

namespace JaveragesLibrary.Infrastructure.Repositories
{
    public class EventoRepository
    {
        private readonly JaveragesLibraryDbContext _context;

        public EventoRepository(JaveragesLibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evento>> GetAll(EventoQueryFilter eventoQueryFilter) // Cambia Empleado a Evento
        {
            var query = _context.Eventos.AsQueryable(); // Cambia Empleados a Eventos

            if (eventoQueryFilter.Id > 0)
                query = query.Where(evento => evento.Id == eventoQueryFilter.Id); // Cambia Empleado a Evento

            // Agrega más condiciones si es necesario para otros campos

            var eventos = await query.ToListAsync(); // Cambia Empleados a Eventos
            return eventos; // Cambia Empleados a Eventos
        }

        public async Task<Evento> GetById(int id) // Cambia Empleado a Evento
        {
            return await _context.Eventos.FirstOrDefaultAsync(evento => evento.Id == id) // Cambia Empleado a Evento
                ?? new Evento
                {
                    // Puedes inicializar las propiedades por defecto aquí
                };
        }

        public async Task Add(Evento evento) // Cambia Empleado a Evento
        {
            await _context.Eventos.AddAsync(evento); // Cambia Empleados a Eventos
            await _context.SaveChangesAsync();
        }

        public async Task Update(Evento updatedEvento) // Cambia Empleado a Evento
        {
            try
            {
                var evento = await _context.Eventos.FirstOrDefaultAsync(e => e.Id == updatedEvento.Id); // Cambia Empleado a Evento

                if (evento != null)
                {
                    evento.Tipo = updatedEvento.Tipo; // Agrega las propiedades que desees actualizar
                    evento.Descripcion = updatedEvento.Descripcion;
                    evento.FechaDeCreacion = updatedEvento.FechaDeCreacion;
                    evento.FechaCita = updatedEvento.FechaCita;

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción según tus necesidades
            }
        }

        public async Task Delete(int id) // Cambia Empleado a Evento
        {
            var evento = await _context.Eventos.FirstOrDefaultAsync(evento => evento.Id == id); // Cambia Empleado a Evento

            if (evento != null)
            {
                _context.Eventos.Remove(evento); // Cambia Empleados a Eventos
                await _context.SaveChangesAsync();
            }
        }
    }
}
