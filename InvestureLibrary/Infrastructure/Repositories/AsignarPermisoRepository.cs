
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
    public class AsignarPermisoRepository
    {
        private readonly JaveragesLibraryDbContext _context;

        public AsignarPermisoRepository(JaveragesLibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AsignarPermiso>> GetAll(AsignarPermisoQueryFilter asignarPermisoQueryFilter)
        {
            var query = _context.AsignarPermisos.AsQueryable();

            if (asignarPermisoQueryFilter.Id > 0)
                query = query.Where(asignarPermiso => asignarPermiso.Id == asignarPermisoQueryFilter.Id);

            if (asignarPermisoQueryFilter.Id_Rol > 0)
                query = query.Where(asignarPermiso => asignarPermiso.Id_rol == asignarPermisoQueryFilter.Id_Rol);

            if (asignarPermisoQueryFilter.Id_Permiso > 0)
                query = query.Where(asignarPermiso => asignarPermiso.Id_permiso == asignarPermisoQueryFilter.Id_Permiso);

            // Agrega más condiciones si es necesario para otros campos

            var asignarPermisos = await query.ToListAsync();
            return asignarPermisos;
        }

        public async Task<AsignarPermiso> GetById(int id)
        {
            return await _context.AsignarPermisos.FirstOrDefaultAsync(asignarPermiso => asignarPermiso.Id == id)
                ?? new AsignarPermiso
                {
                    Id_rol = 0,
                    Id_permiso = 0
                };
        }

        public async Task Add(AsignarPermiso asignarPermiso)
        {
            await _context.AsignarPermisos.AddAsync(asignarPermiso);
            await _context.SaveChangesAsync();
        }

        public async Task Update(AsignarPermiso updatedAsignarPermiso)
        {
            try
            {
                var asignarPermiso = await _context.AsignarPermisos.FirstOrDefaultAsync(ap => ap.Id == updatedAsignarPermiso.Id);

                if (asignarPermiso != null)
                {
                    asignarPermiso.Id_rol = updatedAsignarPermiso.Id_rol;
                    asignarPermiso.Id_permiso = updatedAsignarPermiso.Id_permiso;

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
            var asignarPermiso = await _context.AsignarPermisos.FirstOrDefaultAsync(asignarPermiso => asignarPermiso.Id == id);

            if (asignarPermiso != null)
            {
                _context.AsignarPermisos.Remove(asignarPermiso);
                await _context.SaveChangesAsync();
            }
        }
    }
}
