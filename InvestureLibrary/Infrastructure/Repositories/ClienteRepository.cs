
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JaveragesLibrary.Infrastructure.Data;
using InvestureLibrary.Domain.Entities;
using InvestureLibrary.Domain.Dtos;

namespace JaveragesLibrary.Infrastructure.Repositories
{
    public class ClienteRepository
    {
        private readonly JaveragesLibraryDbContext _dbContext;

        public ClienteRepository(JaveragesLibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Cliente>> GetAllClientesAsync()
        {
            return await _dbContext.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _dbContext.Clientes.FindAsync(id);
        }

        public async Task Add(Cliente nota)
        {
            await _dbContext.Clientes.AddAsync(nota);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateClienteAsync(int id, ClienteUpdateDTO cliente)
        {
            var existingCliente = await _dbContext.Clientes.FindAsync(id);

            if (existingCliente != null)
            {
                existingCliente.Nombre = cliente.Nombre;
                existingCliente.Email = cliente.Email;
                existingCliente.Telefono = cliente.Telefono;
                existingCliente.Empleado_id = cliente.Empleado_id;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteClienteAsync(int id)
        {
            var cliente = await _dbContext.Clientes.FindAsync(id);

            if (cliente != null)
            {
                _dbContext.Clientes.Remove(cliente);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

