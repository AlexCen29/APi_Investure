using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Entities;
namespace InvestureLibrary.Services.Mappings
{

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<PermisoUpdateDTO, Permiso>();
            CreateMap<RolUpdateDTO, Rol>();
            CreateMap<AsignarPermisoUpdateDTO, AsignarPermiso>();
            CreateMap<EmpleadoUpdateDTO, Empleado>();
            CreateMap<EventoUpdateDTO, Evento>();
            CreateMap<ClienteUpdateDTO, Cliente>();
            CreateMap<RegistroDeContactoUpdateDTO, RegistroDeContacto>();
            CreateMap<SeguimientoDeTareaUpdateDTO, SeguimientoDeTarea>();
        }
    }
}