// InversionService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Infrastructure.Data;
using JaveragesLibrary.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;


namespace JaveragesLibrary.Services.Features.Inversiones
{
    public class InversionService
    {
        private readonly InversionRepository _inversionesRepository;
        private readonly IMapper _mapper;
        private readonly JaveragesLibraryDbContext _dbContext;

        public InversionService(JaveragesLibraryDbContext dbContext, InversionRepository inversionesRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _inversionesRepository = inversionesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Inversion>> GetAll(InversionQueryFilter mangaQueryFilter)
        {
            return await _inversionesRepository.GetAll(mangaQueryFilter);
        }



        public async Task<InversionDTO> GetById(int id)
        {
            var inversion = await _inversionesRepository.GetById(id);
            return _mapper.Map<InversionDTO>(inversion);
        }



        // Constructor e inicialización del DbContext

        public int GetNextId()
        {
            int nextId = (_dbContext.Inversion.Max(i => (int?)i.Id) ?? 0) + 1;

            return nextId;
        }

        public async Task Add(InversionCreateDTO inversion)
        {
            var entity = new Inversion
            {
                Id = GetNextId(),
                Tipo = inversion.Tipo,
                Monto = inversion.Monto,
                FechaInicio = inversion.FechaInicio,
                FechaFin = inversion.FechaFin,
                RendimientoEsperado = inversion.RendimientoEsperado,
                RendimientoActual = inversion.RendimientoActual,
                Estado = inversion.Estado
            };

            await _dbContext.Inversion.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

        }







        public async Task Update(InversionUpdateDTO inversionUpdate)
{
    // Primero, verifica si la inversión que deseas actualizar existe en la base de datos
    var existingInversion = await _inversionesRepository.GetById(inversionUpdate.Id);

    if (existingInversion == null)
    {
       throw new InvalidOperationException("La inversión no se encontró.");

    }

    // Actualiza las propiedades de la inversión existente con los datos de inversionUpdate
    existingInversion.Tipo = inversionUpdate.Tipo;
    existingInversion.Monto = inversionUpdate.Monto;
    existingInversion.FechaInicio = inversionUpdate.FechaInicio;
    existingInversion.FechaFin = inversionUpdate.FechaFin;
    existingInversion.RendimientoEsperado = inversionUpdate.RendimientoEsperado;
    existingInversion.RendimientoActual = inversionUpdate.RendimientoActual;
    

    // Luego, llama al método de repositorio para actualizar la inversión en la base de datos
    await _inversionesRepository.Update(existingInversion);
}



        public async Task Delete(int id)
        {
            await _inversionesRepository.Delete(id);
        }

        internal Task Update(InversionDTO existingInversion)
        {
            throw new NotImplementedException();
        }
    }
}
