using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Infrastructure.Data;
using JaveragesLibrary.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JaveragesLibrary.Services.Features.Propiedades
{
    // Interface del Servicio de Propiedades
    public interface IPropiedadService
    {
        Task<PropiedadDTO> GetPropiedadByIdAsync(int id);
        Task<List<PropiedadDTO>> GetAllPropiedadesAsync();
        Task CreatePropiedadAsync(Propiedad propiedad);
        Task UpdatePropiedadAsync(PropiedadDTO propiedad);
        Task DeletePropiedadAsync(int id);
    }

    // Implementación del Servicio de Propiedades
    public class PropiedadService : IPropiedadService
    {
        private readonly IPropiedadRepository _repository;

        public PropiedadService(IPropiedadRepository repository)
        {
            _repository = repository;
        }

        public async Task<PropiedadDTO> GetPropiedadByIdAsync(int id)
        {
            return await _repository.GetPropiedadByIdAsync(id);
        }

        public async Task<List<PropiedadDTO>> GetAllPropiedadesAsync()
        {
            return await _repository.GetAllPropiedadesAsync();
        }

        public async Task CreatePropiedadAsync(Propiedad propiedad)
        {
            await _repository.CreatePropiedadAsync(propiedad);
        }

        public async Task UpdatePropiedadAsync(PropiedadDTO propiedad)
        {
            await _repository.UpdatePropiedadAsync(propiedad);
        }

        public async Task DeletePropiedadAsync(int id)
        {
            await _repository.DeletePropiedadAsync(id);
        }
    }

}
