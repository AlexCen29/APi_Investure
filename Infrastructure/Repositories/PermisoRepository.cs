using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JaveragesLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Infrastructure.Data;

namespace JaveragesLibrary.Infrastructure.Repositories
{
    public class PermisoRepository
    {
        private readonly JaveragesLibraryDbContext _context;

        public PermisoRepository(JaveragesLibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Permiso>> GetAll(PermisoQueryFilter permisoQueryFilter)
        {
            var query = _context.Permisos.AsQueryable();

            if (permisoQueryFilter.Id > 0)
                query = query.Where(permiso => permiso.Id == permisoQueryFilter.Id);

            if (!string.IsNullOrEmpty(permisoQueryFilter.Nombre) && !string.IsNullOrWhiteSpace(permisoQueryFilter.Nombre))
                query = query.Where(permiso => permiso.Nombre == permisoQueryFilter.Nombre);

            // Añade más condiciones si es necesario para otros campos

            var permisos = await query.ToListAsync();
            return permisos;
        }

        public async Task<Permiso> GetById(int id)
        {
            return await _context.Permisos.FirstOrDefaultAsync(permiso => permiso.Id == id)
                ?? new Permiso
                {
                    Nombre = string.Empty,
                    Descripcion = string.Empty
                };
        }

        public async Task Add(Permiso permiso)
        {
            await _context.Permisos.AddAsync(permiso);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Permiso updatedPermiso)
        {
            try
            {
                var permiso = await _context.Permisos.FirstOrDefaultAsync(p => p.Id == updatedPermiso.Id);

                if (permiso != null)
                {
                    permiso.Nombre = updatedPermiso.Nombre;
                    permiso.Descripcion = updatedPermiso.Descripcion;

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
            var permiso = await _context.Permisos.FirstOrDefaultAsync(permiso => permiso.Id == id);

            if (permiso != null)
            {
                _context.Permisos.Remove(permiso);
                await _context.SaveChangesAsync();
            }
        }
    }
}
