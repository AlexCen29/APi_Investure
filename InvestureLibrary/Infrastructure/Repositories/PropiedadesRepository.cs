using System;
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
    // Interface del Repositorio de Propiedades
public interface IPropiedadRepository
{
    Task<PropiedadDTO> GetPropiedadByIdAsync(int id);
    Task<List<PropiedadDTO>> GetAllPropiedadesAsync();
    Task CreatePropiedadAsync(Propiedad propiedad);
    Task UpdatePropiedadAsync(PropiedadDTO propiedad);
    Task DeletePropiedadAsync(int id);
}

// Implementación del Repositorio de Propiedades
public class PropiedadRepository : IPropiedadRepository
{
    private readonly JaveragesLibraryDbContext _context; // Reemplaza con tu DbContext

    public PropiedadRepository(JaveragesLibraryDbContext context)
    {
        _context = context;
    }

    public async Task<PropiedadDTO> GetPropiedadByIdAsync(int id)
    {
        return await _context.Propiedades
            .Where(p => p.Id == id)
            .Select(p => new PropiedadDTO
            {
                Id = p.Id,
                Direccion = p.Direccion,
                Descripcion = p.Descripcion,
                Tipo = p.Tipo,
               
            })
            .FirstOrDefaultAsync();
    }

    public async Task<List<PropiedadDTO>> GetAllPropiedadesAsync()
    {
        return await _context.Propiedades
            .Select(p => new PropiedadDTO
            {
                Id = p.Id,
                Direccion = p.Direccion,
                Descripcion = p.Descripcion,
                Tipo = p.Tipo,
                
            })
            .ToListAsync();
    }

    public async Task CreatePropiedadAsync(Propiedad propiedad)
    {
        var nuevaPropiedad = new Propiedad
        {
            Direccion = propiedad.Direccion,
            Descripcion = propiedad.Descripcion,
            Tipo = propiedad.Tipo,
            
        };

        _context.Propiedades.Add(nuevaPropiedad);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePropiedadAsync(PropiedadDTO propiedad)
    {
        var propiedadExistente = await _context.Propiedades.FindAsync(propiedad.Id);

        if (propiedadExistente != null)
        {
            propiedadExistente.Direccion = propiedad.Direccion;
            propiedadExistente.Descripcion = propiedad.Descripcion;
            propiedadExistente.Tipo = propiedad.Tipo;
            

            await _context.SaveChangesAsync();
        }
    }

    public async Task DeletePropiedadAsync(int id)
    {
        var propiedadExistente = await _context.Propiedades.FindAsync(id);

        if (propiedadExistente != null)
        {
            _context.Propiedades.Remove(propiedadExistente);
            await _context.SaveChangesAsync();
        }
    }
}

}
