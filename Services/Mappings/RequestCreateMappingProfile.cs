using AutoMapper;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Entities;

namespace JaveragesLibrary.Services.Mappings
{
    public class RequestCreateMappingProfile : Profile
{
    public RequestCreateMappingProfile()
    {
        CreateMap<PermisoCreateDTO, Permiso>();
        CreateMap<RolCreateDTO, Rol>();
        CreateMap<AsignarPermisoCreateDTO, AsignarPermiso>();
        CreateMap<EmpleadoCreateDTO, Empleado>();
        CreateMap<EventoCreateDTO, Evento>();
        CreateMap<ClienteCreateDTO, Cliente>();
        CreateMap<RegistroDeContactoCreateDTO, RegistroDeContacto>();
        
        
    }
}

}
