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

namespace JaveragesLibrary.Services.Features.Clientes
{
    public class ClienteService
    {
        private readonly ClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly JaveragesLibraryDbContext _dbContext;

        public ClienteService(JaveragesLibraryDbContext dbContext, ClienteRepository clienteRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Cliente>> GetAll(ClienteQueryFilter clienteQueryFilter)
        {
            return await _clienteRepository.GetAll(clienteQueryFilter);
        }

        public async Task<ClienteDTO> GetById(int id)
        {
            var cliente = await _clienteRepository.GetById(id);
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public int GetNextId()
        {
            int nextId = (_dbContext.Clientes.Max(c => (int?)c.Id) ?? 0) + 1;
            return nextId;
        }

        public async Task Add(ClienteCreateDTO cliente)
        {
            var entity = _mapper.Map<Cliente>(cliente);
            _dbContext.Clientes.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(ClienteUpdateDTO clienteUpdate)
        {
            var existingCliente = await _clienteRepository.GetById(clienteUpdate.Id);

            if (existingCliente == null)
            {
                throw new InvalidOperationException("El cliente no se encontró.");
            }

            existingCliente.IdEmpleado_fk = clienteUpdate.IdEmpleado_fk;
            existingCliente.Nombre = clienteUpdate.Nombre;
            existingCliente.CorreoElectronico = clienteUpdate.CorreoElectronico;
            existingCliente.FechaNac = clienteUpdate.FechaNac;
            existingCliente.FechaCreacion = clienteUpdate.FechaCreacion;
            existingCliente.Telefono = clienteUpdate.Telefono;

            await _clienteRepository.Update(existingCliente);
        }

        public async Task Delete(int id)
        {
            await _clienteRepository.Delete(id);
        }
    }
}
