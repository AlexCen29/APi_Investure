using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Domain.Dtos;

namespace JaveragesLibrary.Infrastructure.Repositories
{
    public partial class EmpresaRepository
    {
        private readonly JaveragesLibraryDbContext _context;

        public EmpresaRepository(JaveragesLibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empresa>> GetAll(EmpresaQueryFilter empresaQueryFilter)
        {
            var query = _context.Empresas
                         .AsQueryable();

            if (empresaQueryFilter.Id > 0)
                query = query.Where(empresa => empresa.Id == empresaQueryFilter.Id);

            if (!string.IsNullOrEmpty(empresaQueryFilter.Nombre) && !string.IsNullOrWhiteSpace(empresaQueryFilter.Nombre))
                query = query.Where(empresa => empresa.Nombre == empresaQueryFilter.Nombre);

            if (!string.IsNullOrEmpty(empresaQueryFilter.Ubicacion) && !string.IsNullOrWhiteSpace(empresaQueryFilter.Ubicacion))
                query = query.Where(empresa => empresa.Ubicacion == empresaQueryFilter.Ubicacion);

            if (!string.IsNullOrEmpty(empresaQueryFilter.RFC) && !string.IsNullOrWhiteSpace(empresaQueryFilter.RFC))
                query = query.Where(empresa => empresa.RFC == empresaQueryFilter.RFC);

            var empresas = await query.ToListAsync();
            return empresas;
        }

        public async Task<Empresa> GetById(int id)
        {
            return await _context.Empresas.FirstOrDefaultAsync(empresa => empresa.Id == id)
                ?? new Empresa
                {
                    Nombre = string.Empty,
                    Ubicacion = string.Empty,
                    RFC = string.Empty
                };
        }

        public async Task Add(Empresa empresa)
        {
            await _context.Empresas.AddAsync(empresa);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Empresa updatedEmpresa)
        {
            try
            {
                var empresa = await _context.Empresas.FirstOrDefaultAsync(e => e.Id == updatedEmpresa.Id);

                if (empresa != null)
                {
                    empresa.Nombre = updatedEmpresa.Nombre;
                    empresa.Ubicacion = updatedEmpresa.Ubicacion;
                    empresa.RFC = updatedEmpresa.RFC;

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
            var empresa = await _context.Empresas.FirstOrDefaultAsync(empresa => empresa.Id == id);

            if (empresa != null)
            {
                _context.Empresas.Remove(empresa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
