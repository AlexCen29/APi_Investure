using AutoMapper;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Entities;

namespace JaveragesLibrary.Services.Mappings
{
    public class ResponseMappingProfile : Profile
    {
        public ResponseMappingProfile()
        {
            CreateMap<Permiso, PermisoDTO>();
            CreateMap<Rol, RolDTO>();
            CreateMap<AsignarPermiso, AsignarPermisoDTO>();
            CreateMap<Empleado, EmpleadoDTO>();
            CreateMap<Evento, EventoDTO>();
            CreateMap<Cliente, ClienteDTO>();
        }
    }
}

