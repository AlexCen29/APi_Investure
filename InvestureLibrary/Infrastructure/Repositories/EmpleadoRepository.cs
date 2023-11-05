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
    public class EmpleadoRepository
    {
        private readonly JaveragesLibraryDbContext _context;

        public EmpleadoRepository(JaveragesLibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empleado>> GetAll(EmpleadoQueryFilter empleadoQueryFilter)
        {
            var query = _context.Empleados.AsQueryable();

            if (empleadoQueryFilter.Id > 0)
                query = query.Where(empleado => empleado.Id == empleadoQueryFilter.Id);

            // Agrega más condiciones si es necesario para otros campos

            var empleados = await query.ToListAsync();
            return empleados;
        }

        public async Task<Empleado> GetById(int id)
        {
            return await _context.Empleados.FirstOrDefaultAsync(empleado => empleado.Id == id)
                ?? new Empleado
                {
                    // Puedes inicializar las propiedades por defecto aquí
                };
        }

        public async Task Add(Empleado empleado)
        {
            await _context.Empleados.AddAsync(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Empleado updatedEmpleado)
        {
            try
            {
                var empleado = await _context.Empleados.FirstOrDefaultAsync(e => e.Id == updatedEmpleado.Id);

                if (empleado != null)
                {
                    empleado.Nombre = updatedEmpleado.Nombre;
                    empleado.ApellMater = updatedEmpleado.ApellMater;
                    empleado.ApellPater = updatedEmpleado.ApellPater;
                    empleado.Curp = updatedEmpleado.Curp;
                    empleado.Sexo = updatedEmpleado.Sexo;
                    empleado.Direccion = updatedEmpleado.Direccion;
                    empleado.Rol_fk = updatedEmpleado.Rol_fk;
                    empleado.Correo_electronico = updatedEmpleado.Correo_electronico;
                    empleado.FechaNac = updatedEmpleado.FechaNac;
                    empleado.FechaContratacion = updatedEmpleado.FechaContratacion;
                    empleado.Estatus = updatedEmpleado.Estatus;

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
            var empleado = await _context.Empleados.FirstOrDefaultAsync(empleado => empleado.Id == id);

            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                await _context.SaveChangesAsync();
            }
        }
    }
}
