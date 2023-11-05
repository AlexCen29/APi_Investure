using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using JaveragesLibrary.Domain.Dtos.QueryFilters;

namespace JaveragesLibrary.Infrastructure.Repositories
{
    public partial class NotaRepository
    {
        private readonly JaveragesLibraryDbContext _context;

        public NotaRepository(JaveragesLibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Nota>> GetAll(NotaQueryFilter notaQueryFilter)
        {
            var query = _context.Notas
                         .AsQueryable();

            if (notaQueryFilter.Id > 0)
                query = query.Where(nota => nota.Id == notaQueryFilter.Id);

            if (!string.IsNullOrEmpty(notaQueryFilter.Contenido) && !string.IsNullOrWhiteSpace(notaQueryFilter.Contenido))
                query = query.Where(nota => nota.Contenido == notaQueryFilter.Contenido);

            // Agrega condiciones para otros campos de filtro según sea necesario

            var notas = await query.ToListAsync();
            return notas;
        }

        public async Task<Nota> GetById(int id)
        {
            return await _context.Notas.FirstOrDefaultAsync(nota => nota.Id == id)
                ?? new Nota
                {
                    Contenido = string.Empty,
                    // Agrega otras propiedades por defecto según corresponda
                };
        }

        public async Task Add(Nota nota)
        {
            await _context.Notas.AddAsync(nota);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Nota updatedNota)
        {
            try
            {
                var nota = await _context.Notas.FirstOrDefaultAsync(n => n.Id == updatedNota.Id);

                if (nota != null)
                {
                    nota.Contenido = updatedNota.Contenido;
                    // Actualiza otras propiedades según corresponda

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
            var nota = await _context.Notas.FirstOrDefaultAsync(nota => nota.Id == id);

            if (nota != null)
            {
                _context.Notas.Remove(nota);
                await _context.SaveChangesAsync();
            }
        }
    }
}
