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

namespace JaveragesLibrary.Services.Features.Permisos
{
    public class PermisoService
    {
        private readonly PermisoRepository _permisoRepository;
        private readonly IMapper _mapper;
        private readonly JaveragesLibraryDbContext _dbContext;

        public PermisoService(JaveragesLibraryDbContext dbContext, PermisoRepository permisoRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _permisoRepository = permisoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Permiso>> GetAll(PermisoQueryFilter permisoQueryFilter)
        {
            return await _permisoRepository.GetAll(permisoQueryFilter);
        }

        public async Task<PermisoDTO> GetById(int id)
        {
            var permiso = await _permisoRepository.GetById(id);
            return _mapper.Map<PermisoDTO>(permiso);
        }

        public int GetNextId()
        {
            int nextId = (_dbContext.Permisos.Max(p => (int?)p.Id) ?? 0) + 1;
            return nextId;
        }

        public async Task Add(PermisoCreateDTO permiso)
        {
            var entity = _mapper.Map<Permiso>(permiso);
            _dbContext.Permisos.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(PermisoUpdateDTO permisoUpdate)
        {
            var existingPermiso = await _permisoRepository.GetById(permisoUpdate.Id);

            if (existingPermiso == null)
            {
                throw new InvalidOperationException("El permiso no se encontró.");
            }

            existingPermiso.Nombre = permisoUpdate.Nombre;
            existingPermiso.Descripcion = permisoUpdate.Descripcion;

            await _permisoRepository.Update(existingPermiso);
        }

        public async Task Delete(int id)
        {
            await _permisoRepository.Delete(id);
        }
    }
}
