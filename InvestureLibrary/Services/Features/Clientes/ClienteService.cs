using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestureLibrary.Domain.Dtos;
using InvestureLibrary.Domain.Entities;
using JaveragesLibrary.Infrastructure.Repositories;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Infrastructure.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace InvestureLibrary.Services.Features.Clientes
{
    public class ClienteService
    {
        private readonly ClienteRepository _clienteRepository;
        private readonly JaveragesLibraryDbContext _dbContext;
        private readonly IMapper _mapper;


        public ClienteService(ClienteRepository clienteRepository, JaveragesLibraryDbContext dbContext, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<List<Cliente>> GetAllClientesAsync()
        {
            return await _clienteRepository.GetAllClientesAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _clienteRepository.GetClienteByIdAsync(id);
        }
        public int GetNextId()
        {
            int nextId = (_dbContext.Clientes.Max(e => (int?)e.Id) ?? 0) + 1;
            return nextId;
        }

        public async Task Add(ClienteCreateDTO cliente)
        {
            var entity = _mapper.Map<Cliente>(cliente);
            _dbContext.Clientes.Add(entity);
            await _dbContext.SaveChangesAsync();
        }


        public async Task UpdateClienteAsync(int id, ClienteUpdateDTO cliente)
        {
            await _clienteRepository.UpdateClienteAsync(id, cliente);
        }

        public async Task DeleteClienteAsync(int id)
        {
            await _clienteRepository.DeleteClienteAsync(id);
        }
    }
}
