using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Infrastructure.Data;
using JaveragesLibrary.Infrastructure.Repositories;

namespace InvestureLibrary.Services.Features.Inversiones
{
    public class UserService
    {
        private readonly InversionRepository _inversionesRepository;
        private readonly IMapper _mapper;
        private readonly JaveragesLibraryDbContext _dbContext;

        public UserService(JaveragesLibraryDbContext dbContext, InversionRepository inversionesRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _inversionesRepository = inversionesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Inversion>> GetAll(InversionQueryFilter inversionQueryFilter)
        {
            return await _inversionesRepository.GetAll(inversionQueryFilter);
        }

        public async Task<InversionDTO> GetById(int id)
        {
            var inversion = await _inversionesRepository.GetById(id);
            return _mapper.Map<InversionDTO>(inversion);
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

        private int GetNextId()
        {
            int nextId = (_dbContext.Inversion.Max(i => (int?)i.Id) ?? 0) + 1;
            return nextId;
        }

        public async Task Update(InversionUpdateDTO inversionUpdate)
        {
            var entity = _mapper.Map<Inversion>(inversionUpdate);
            await _inversionesRepository.Update(entity);
        }

        public async Task Delete(int id)
        {
            await _inversionesRepository.Delete(id);
        }
    }
}
