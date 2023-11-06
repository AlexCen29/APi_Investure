using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Infrastructure.Data;
using JaveragesLibrary.Domain.Entities;

namespace JaveragesLibrary.Infrastructure.Repositories
{
    public class ClienteRepository
    {
        private readonly JaveragesLibraryDbContext _context;

        public ClienteRepository(JaveragesLibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAll(ClienteQueryFilter clienteQueryFilter)
        {
            var query = _context.Clientes.AsQueryable();

            if (clienteQueryFilter.Id > 0)
                query = query.Where(cliente => cliente.Id == clienteQueryFilter.Id);

            // Agrega más condiciones si es necesario para otros campos

            var clientes = await query.ToListAsync();
            return clientes;
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _context.Clientes.FirstOrDefaultAsync(cliente => cliente.Id == id)
                ?? new Cliente
                {
                    // Puedes inicializar las propiedades por defecto aquí
                };
        }

        public async Task Add(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Cliente updatedCliente)
        {
            try
            {
                var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == updatedCliente.Id);

                if (cliente != null)
                {
                    cliente.IdEmpleado_fk = updatedCliente.IdEmpleado_fk;
                    cliente.Nombre = updatedCliente.Nombre;
                    cliente.CorreoElectronico = updatedCliente.CorreoElectronico;
                    cliente.FechaNac = updatedCliente.FechaNac;
                    cliente.FechaCreacion = updatedCliente.FechaCreacion;
                    cliente.Telefono = updatedCliente.Telefono;

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción según tus necesidades
            }
        }

        public async Task Delete(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(cliente => cliente.Id == id);

            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
