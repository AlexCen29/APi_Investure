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
    public class SeguimientoDeTareaRepository
    {
        private readonly JaveragesLibraryDbContext _context;

        public SeguimientoDeTareaRepository(JaveragesLibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SeguimientoDeTarea>> GetAll(SeguimientoDeTareaQueryFilter seguimientoDeTareaQueryFilter)
        {
            var query = _context.SeguimientoDeTareas.AsQueryable();

            if (seguimientoDeTareaQueryFilter.Id > 0)
                query = query.Where(tarea => tarea.Id == seguimientoDeTareaQueryFilter.Id);

            // Agrega más condiciones si es necesario para otros campos

            var tareas = await query.ToListAsync();
            return tareas;
        }

        public async Task<SeguimientoDeTarea> GetById(int id)
        {
            return await _context.SeguimientoDeTareas.FirstOrDefaultAsync(tarea => tarea.Id == id)
                ?? new SeguimientoDeTarea
                {
                    // Puedes inicializar las propiedades por defecto aquí
                };
        }

        public async Task Add(SeguimientoDeTarea tarea)
        {
            _context.SeguimientoDeTareas.Add(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task Update(SeguimientoDeTarea updatedTarea)
        {
            try
            {
                var tarea = await _context.SeguimientoDeTareas.FirstOrDefaultAsync(t => t.Id == updatedTarea.Id);

                if (tarea != null)
                {
                    tarea.IdEmpleado_fk = updatedTarea.IdEmpleado_fk;
                    tarea.Tarea = updatedTarea.Tarea;
                    tarea.FechaInicio = updatedTarea.FechaInicio;
                    tarea.FechaFin = updatedTarea.FechaFin;
                    tarea.Completada = updatedTarea.Completada;

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción según tus necesidades
            }
        }

        public async Task Delete(int id)
        {
            var tarea = await _context.SeguimientoDeTareas.FirstOrDefaultAsync(tarea => tarea.Id == id);

            if (tarea != null)
            {
                _context.SeguimientoDeTareas.Remove(tarea);
                await _context.SaveChangesAsync();
            }
        }
    }
}
