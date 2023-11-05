using AutoMapper;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Entities;
using InvestureLibrary.Domain.Dtos;
using InvestureLibrary.Domain.Entities;

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


        CreateMap<InversionCreateDTO, Inversion>()
            .AfterMap((src, dest) =>
            {
                dest.FechaInicio = DateTime.Now;
            });
        CreateMap<EmpresaCreateDTO, Empresa>();
        CreateMap<Propiedad, PropiedadDTO>().ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.Direccion))
            .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo));
            CreateMap<PropiedadCreateDTO, Propiedad>(); 
        CreateMap<Propiedad, PropiedadDTO>(); 

            CreateMap<Casa, CasaDTO>().ReverseMap();
        CreateMap<Terreno, TerrenoDTO>().ReverseMap();
        CreateMap<Villa, VillaDTO>().ReverseMap();
        CreateMap<NotaCreateDTO, Nota>();
        CreateMap<ClienteCreateDTO, Cliente>();
    }
}

}
