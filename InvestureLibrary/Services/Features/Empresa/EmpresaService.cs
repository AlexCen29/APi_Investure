using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Infrastructure.Data;
using JaveragesLibrary.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JaveragesLibrary.Services.Features.Empresas
{
    public class EmpresaService
    {
        private readonly EmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;
        private readonly JaveragesLibraryDbContext _dbContext;

        public EmpresaService(JaveragesLibraryDbContext dbContext, EmpresaRepository empresaRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Empresa>> GetAll(EmpresaQueryFilter empresaQueryFilter)
        {
            return await _empresaRepository.GetAll(empresaQueryFilter);
        }

        public async Task<EmpresaDTO> GetById(int id)
        {
            var empresa = await _empresaRepository.GetById(id);
            return _mapper.Map<EmpresaDTO>(empresa);
        }

        public int GetNextId()
        {
            int nextId = (_dbContext.Empresas.Max(e => (int?)e.Id) ?? 0) + 1;
            return nextId;
        }

        public async Task Add(EmpresaCreateDTO empresa)
        {
            var entity = _mapper.Map<Empresa>(empresa);
            _dbContext.Empresas.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(EmpresaUpdateDTO empresaUpdate)
        {
            var existingEmpresa = await _empresaRepository.GetById(empresaUpdate.Id);

            if (existingEmpresa == null)
            {
                throw new InvalidOperationException("La empresa no se encontró.");
            }

            existingEmpresa.Nombre = empresaUpdate.Nombre;
            existingEmpresa.Ubicacion = empresaUpdate.Ubicacion;
            existingEmpresa.RFC = empresaUpdate.RFC;

            await _empresaRepository.Update(existingEmpresa);
        }

        public async Task Delete(int id)
        {
            await _empresaRepository.Delete(id);
        }
    }
}
