// InversionRepository.cs
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
    public partial class InversionRepository
    {
        private readonly JaveragesLibraryDbContext _context;

        public InversionRepository(JaveragesLibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inversion>> GetAll(InversionQueryFilter inversionQueryFilter)
        {
            var query = _context.Inversion
                         .AsQueryable();

            if (inversionQueryFilter.Id > 0)
                query = query.Where(inversion => inversion.Id == inversionQueryFilter.Id);







            if (!string.IsNullOrEmpty(inversionQueryFilter.Tipo) && !string.IsNullOrWhiteSpace(inversionQueryFilter.Tipo))
                query = query.Where(inversion => inversion.Tipo == inversionQueryFilter.Tipo);


            if (inversionQueryFilter.StartFechaInicio > DateTime.MinValue)
                query = query.Where(inversion => inversion.FechaInicio >= inversionQueryFilter.StartFechaInicio);

            if (inversionQueryFilter.EndFechaInicio > DateTime.MinValue)
                query = query.Where(inversion => inversion.FechaInicio <= inversionQueryFilter.EndFechaInicio);

            if (inversionQueryFilter.StartFechaFin > DateTime.MinValue)
                query = query.Where(inversion => inversion.FechaFin >= inversionQueryFilter.StartFechaFin);

            if (inversionQueryFilter.EndFechaFin > DateTime.MinValue)
                query = query.Where(inversion => inversion.FechaFin <= inversionQueryFilter.EndFechaFin);

            if (inversionQueryFilter.MinRendimientoEsperado > 0)
                query = query.Where(inversion => inversion.RendimientoEsperado >= inversionQueryFilter.MinRendimientoEsperado);

            if (inversionQueryFilter.MaxRendimientoEsperado > 0)
                query = query.Where(inversion => inversion.RendimientoEsperado <= inversionQueryFilter.MaxRendimientoEsperado);

            if (inversionQueryFilter.MinRendimientoActual > 0)
                query = query.Where(inversion => inversion.RendimientoActual >= inversionQueryFilter.MinRendimientoActual);

            if (inversionQueryFilter.MaxRendimientoActual > 0)
                query = query.Where(inversion => inversion.RendimientoActual <= inversionQueryFilter.MaxRendimientoActual);

            if (!string.IsNullOrEmpty(inversionQueryFilter.Estado) && !string.IsNullOrWhiteSpace(inversionQueryFilter.Estado))
                query = query.Where(inversion => inversion.Estado == inversionQueryFilter.Estado);

            var inversiones = await query.ToListAsync();
            return inversiones;
        }

        public async Task<Inversion> GetById(int id)
        {
            return await _context.Inversion.FirstOrDefaultAsync(inversion => inversion.Id == id)
                ?? new Inversion
                {
                    Tipo = string.Empty,
                    Monto = 0.0,
                    FechaInicio = DateTime.MinValue,
                    FechaFin = DateTime.MinValue,
                    RendimientoEsperado = 0.0,
                    RendimientoActual = 0.0,
                    Estado = string.Empty
                };
        }

        public async Task Add(Inversion inversion)
        {
            await _context.AddAsync(inversion);
            await _context.SaveChangesAsync();
        }


        public async Task Update(Inversion updatedInversion)
        {
            try
            {
                var inversion = await _context.Inversion.FirstOrDefaultAsync(i => i.Id == updatedInversion.Id);

                if (inversion != null)
                {
                    inversion.Tipo = updatedInversion.Tipo;
                    inversion.Monto = updatedInversion.Monto;
                    inversion.FechaInicio = updatedInversion.FechaInicio;
                    inversion.FechaFin = updatedInversion.FechaFin;
                    inversion.RendimientoEsperado = updatedInversion.RendimientoEsperado;
                    inversion.RendimientoActual = updatedInversion.RendimientoActual;
                    inversion.Estado = updatedInversion.Estado;

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
            
            }
        }



        public async Task Delete(int id)
        {
            var inversion = await _context.Inversion.FirstOrDefaultAsync(inversion => inversion.Id == id);

            if (inversion != null)
            {
                _context.Inversion.Remove(inversion);
                await _context.SaveChangesAsync();
            }
        }
    }
}
