
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

namespace JaveragesLibrary.Services.Features.AsignarPermisos
{
    public class AsignarPermisoService
    {
        private readonly AsignarPermisoRepository _asignarPermisoRepository;
        private readonly IMapper _mapper;
        private readonly JaveragesLibraryDbContext _dbContext;

        public AsignarPermisoService(JaveragesLibraryDbContext dbContext, AsignarPermisoRepository asignarPermisoRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _asignarPermisoRepository = asignarPermisoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AsignarPermiso>> GetAll(AsignarPermisoQueryFilter asignarPermisoQueryFilter)
        {
            return await _asignarPermisoRepository.GetAll(asignarPermisoQueryFilter);
        }

        public async Task<AsignarPermisoDTO> GetById(int id)
        {
            var asignarPermiso = await _asignarPermisoRepository.GetById(id);
            return _mapper.Map<AsignarPermisoDTO>(asignarPermiso);
        }

        public int GetNextId()
        {
            int nextId = (_dbContext.AsignarPermisos.Max(ap => (int?)ap.Id) ?? 0) + 1;
            return nextId;
        }

        public async Task Add(AsignarPermisoCreateDTO asignarPermiso)
        {
            var entity = _mapper.Map<AsignarPermiso>(asignarPermiso);
            _dbContext.AsignarPermisos.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(AsignarPermisoUpdateDTO asignarPermisoUpdate)
        {
            var existingAsignarPermiso = await _asignarPermisoRepository.GetById(asignarPermisoUpdate.Id);

            if (existingAsignarPermiso == null)
            {
                throw new InvalidOperationException("La asignación de permiso no se encontró.");
            }

            existingAsignarPermiso.Id_rol = asignarPermisoUpdate.Id_Rol;
            existingAsignarPermiso.Id_permiso = asignarPermisoUpdate.Id_Permiso;

            await _asignarPermisoRepository.Update(existingAsignarPermiso);
        }

        public async Task Delete(int id)
        {
            await _asignarPermisoRepository.Delete(id);
        }
    }
}
