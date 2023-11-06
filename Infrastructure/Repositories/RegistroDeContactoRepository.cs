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
    public class RegistroDeContactoRepository
    {
        private readonly JaveragesLibraryDbContext _context;

        public RegistroDeContactoRepository(JaveragesLibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RegistroDeContacto>> GetAll(RegistroDeContactoQueryFilter filtro)
        {
            var query = _context.RegistroDeContacto.AsQueryable();

            if (filtro.Id > 0)
                query = query.Where(contacto => contacto.Id == filtro.Id);

            if (filtro.IdEmpleado_fk > 0)
                query = query.Where(contacto => contacto.IdEmpleado_fk == filtro.IdEmpleado_fk);

            if (filtro.IdCliente_fk > 0)
                query = query.Where(contacto => contacto.IdCliente_fk == filtro.IdCliente_fk);

            if (!string.IsNullOrEmpty(filtro.TipoContacto))
                query = query.Where(contacto => contacto.TipoContacto == filtro.TipoContacto);

            if (!string.IsNullOrEmpty(filtro.Descripcion))
                query = query.Where(contacto => contacto.Descripcion == filtro.Descripcion);

            var contactos = await query.ToListAsync();
            return contactos;
        }

        public async Task<RegistroDeContacto> GetById(int id)
        {
            return await _context.RegistroDeContacto.FirstOrDefaultAsync(contacto => contacto.Id == id)
                ?? new RegistroDeContacto
                {
                    // Puedes inicializar las propiedades por defecto aquí
                };
        }

        public async Task Add(RegistroDeContacto contacto)
        {
            await _context.RegistroDeContacto.AddAsync(contacto);
            await _context.SaveChangesAsync();
        }

        public async Task Update(RegistroDeContacto updatedContacto)
        {
            try
            {
                var contacto = await _context.RegistroDeContacto.FirstOrDefaultAsync(c => c.Id == updatedContacto.Id);

                if (contacto != null)
                {
                    contacto.IdEmpleado_fk = updatedContacto.IdEmpleado_fk;
                    contacto.IdCliente_fk = updatedContacto.IdCliente_fk;
                    contacto.TipoContacto = updatedContacto.TipoContacto;
                    contacto.Descripcion = updatedContacto.Descripcion;
                    contacto.FechaContacto = updatedContacto.FechaContacto;
                    contacto.Estado = updatedContacto.Estado;
                    contacto.Canal = updatedContacto.Canal;
                    contacto.FechaHoraInicio = updatedContacto.FechaHoraInicio;
                    contacto.FechaHoraFin = updatedContacto.FechaHoraFin;

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                //Algun dia se hara, yo no, que hueva
            }
        }

        public async Task Delete(int id)
        {
            var contacto = await _context.RegistroDeContacto.FirstOrDefaultAsync(contacto => contacto.Id == id);

            if (contacto != null)
            {
                _context.RegistroDeContacto.Remove(contacto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
