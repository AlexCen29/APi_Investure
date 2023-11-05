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

namespace JaveragesLibrary.Services.Features.Empleados
{
    public class EmpleadoService
    {
        private readonly EmpleadoRepository _empleadoRepository;
        private readonly IMapper _mapper;
        private readonly JaveragesLibraryDbContext _dbContext;

        public EmpleadoService(JaveragesLibraryDbContext dbContext, EmpleadoRepository empleadoRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _empleadoRepository = empleadoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Empleado>> GetAll(EmpleadoQueryFilter empleadoQueryFilter)
        {
            return await _empleadoRepository.GetAll(empleadoQueryFilter);
        }

        public async Task<EmpleadoDTO> GetById(int id)
        {
            var empleado = await _empleadoRepository.GetById(id);
            return _mapper.Map<EmpleadoDTO>(empleado);
        }

        public int GetNextId()
        {
            int nextId = (_dbContext.Empleados.Max(e => (int?)e.Id) ?? 0) + 1;
            return nextId;
        }

        public async Task Add(EmpleadoCreateDTO empleado)
        {
            var entity = _mapper.Map<Empleado>(empleado);
            _dbContext.Empleados.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(EmpleadoUpdateDTO empleadoUpdate)
        {
            var existingEmpleado = await _empleadoRepository.GetById(empleadoUpdate.Id);

            if (existingEmpleado == null)
            {
                throw new InvalidOperationException("El empleado no se encontró.");
            }

            existingEmpleado.Nombre = empleadoUpdate.Nombre;
            existingEmpleado.ApellMater = empleadoUpdate.ApellMater;
            existingEmpleado.ApellPater = empleadoUpdate.ApellPater;
            existingEmpleado.Curp = empleadoUpdate.Curp;
            existingEmpleado.Sexo = empleadoUpdate.Sexo;
            existingEmpleado.Direccion = empleadoUpdate.Direccion;
            existingEmpleado.Rol_fk = empleadoUpdate.Rol_fk;
            existingEmpleado.Correo_electronico = empleadoUpdate.Correo_Electronico;//
            existingEmpleado.FechaNac = empleadoUpdate.FechaNac;
            existingEmpleado.FechaContratacion = empleadoUpdate.FechaContratacion;
            existingEmpleado.Estatus = empleadoUpdate.Estatus;

            await _empleadoRepository.Update(existingEmpleado);
        }

        public async Task Delete(int id)
        {
            await _empleadoRepository.Delete(id);
        }
    }
}
