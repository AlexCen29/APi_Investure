using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JaveragesLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Infrastructure.Data;

namespace JaveragesLibrary.Infrastructure.Repositories
{
    public class RolRepository
    {
        private readonly JaveragesLibraryDbContext _context;

        public RolRepository(JaveragesLibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rol>> GetAll(RolQueryFilter rolQueryFilter)
        {
            var query = _context.Roles.AsQueryable();

            if (rolQueryFilter.Id > 0)
                query = query.Where(rol => rol.Id == rolQueryFilter.Id);

            if (!string.IsNullOrEmpty(rolQueryFilter.Nombre) && !string.IsNullOrWhiteSpace(rolQueryFilter.Nombre))
                query = query.Where(rol => rol.Nombre == rolQueryFilter.Nombre);

            // Añade más condiciones si es necesario para otros campos

            var roles = await query.ToListAsync();
            return roles;
        }

        public async Task<Rol> GetById(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(rol => rol.Id == id)
                ?? new Rol
                {
                    Nombre = string.Empty,
                    Descripcion = string.Empty
                };
        }

        public async Task Add(Rol rol)
        {
            await _context.Roles.AddAsync(rol);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Rol updatedRol)
        {
            try
            {
                var rol = await _context.Roles.FirstOrDefaultAsync(r => r.Id == updatedRol.Id);

                if (rol != null)
                {
                    rol.Nombre = updatedRol.Nombre;
                    rol.Descripcion = updatedRol.Descripcion;

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
            var rol = await _context.Roles.FirstOrDefaultAsync(rol => rol.Id == id);

            if (rol != null)
            {
                _context.Roles.Remove(rol);
                await _context.SaveChangesAsync();
            }
        }
    }
}
