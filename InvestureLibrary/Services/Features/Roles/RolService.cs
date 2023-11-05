using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Infrastructure.Data;
using JaveragesLibrary.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JaveragesLibrary.Services.Features.Roles
{
    public class RolService
    {
        private readonly RolRepository _rolRepository;
        private readonly IMapper _mapper;
        private readonly JaveragesLibraryDbContext _dbContext;

        public RolService(JaveragesLibraryDbContext dbContext, RolRepository rolRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _rolRepository = rolRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Rol>> GetAll(RolQueryFilter rolQueryFilter)
        {
            return await _rolRepository.GetAll(rolQueryFilter);
        }

        public async Task<RolDTO> GetById(int id)
        {
            var rol = await _rolRepository.GetById(id);
            return _mapper.Map<RolDTO>(rol);
        }

        public int GetNextId()
        {
            int nextId = (_dbContext.Roles.Max(r => (int?)r.Id) ?? 0) + 1;
            return nextId;
        }

        public async Task Add(RolCreateDTO rol)
        {
            var entity = _mapper.Map<Rol>(rol);
            _dbContext.Roles.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(RolUpdateDTO rolUpdate)
        {
            var existingRol = await _rolRepository.GetById(rolUpdate.Id);

            if (existingRol == null)
            {
                throw new InvalidOperationException("El rol no se encontró.");
            }

            existingRol.Nombre = rolUpdate.Nombre;
            existingRol.Descripcion = rolUpdate.Descripcion;

            await _rolRepository.Update(existingRol);
        }

        public async Task Delete(int id)
        {
            await _rolRepository.Delete(id);
        }
    }
}
