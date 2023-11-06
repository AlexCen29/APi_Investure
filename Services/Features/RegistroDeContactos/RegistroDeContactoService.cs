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

namespace JaveragesLibrary.Services.Features.RegistroDeContactos
{
    public class RegistroDeContactoService
    {
        private readonly RegistroDeContactoRepository _registroDeContactoRepository;
        private readonly IMapper _mapper;
        private readonly JaveragesLibraryDbContext _dbContext;

        public RegistroDeContactoService(JaveragesLibraryDbContext dbContext, RegistroDeContactoRepository registroDeContactoRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _registroDeContactoRepository = registroDeContactoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RegistroDeContacto>> GetAll(RegistroDeContactoQueryFilter filtro)
        {
            return await _registroDeContactoRepository.GetAll(filtro);
        }

        public async Task<RegistroDeContactoDTO> GetById(int id)
        {
            var contacto = await _registroDeContactoRepository.GetById(id);
            return _mapper.Map<RegistroDeContactoDTO>(contacto);
        }

        public int GetNextId()
        {
            int nextId = (_dbContext.RegistroDeContacto.Max(c => (int?)c.Id) ?? 0) + 1;
            return nextId;
        }

        public async Task Add(RegistroDeContactoCreateDTO contacto)
        {
            var entity = _mapper.Map<RegistroDeContacto>(contacto);
            _dbContext.RegistroDeContacto.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(RegistroDeContactoUpdateDTO contactoUpdate)
        {
            var existingContacto = await _registroDeContactoRepository.GetById(contactoUpdate.Id);

            if (existingContacto == null)
            {
                throw new InvalidOperationException("El contacto no se encontró.");
            }

            existingContacto.IdEmpleado_fk = contactoUpdate.IdEmpleado_fk;
            existingContacto.IdCliente_fk = contactoUpdate.IdCliente_fk;
            existingContacto.TipoContacto = contactoUpdate.TipoContacto;
            existingContacto.Descripcion = contactoUpdate.Descripcion;
            existingContacto.FechaContacto = contactoUpdate.FechaContacto;
            existingContacto.Estado = contactoUpdate.Estado;
            existingContacto.Canal = contactoUpdate.Canal;
            existingContacto.FechaHoraInicio = contactoUpdate.FechaHoraInicio;
            existingContacto.FechaHoraFin = contactoUpdate.FechaHoraFin;

            await _registroDeContactoRepository.Update(existingContacto);
        }

        public async Task Delete(int id)
        {
            await _registroDeContactoRepository.Delete(id);
        }
    }
}
