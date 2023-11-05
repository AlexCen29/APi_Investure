using AutoMapper;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Entities;
using InvestureLibrary.Domain.Dtos;
using InvestureLibrary.Domain.Entities;

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

            CreateMap<Inversion, InversionDTO>();
            CreateMap<Empresa, EmpresaDTO>();
            CreateMap<Empleado, NotaDTO>();
         
            CreateMap<Propiedad, PropiedadDTO>().ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.Direccion))
            .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo));

            CreateMap<Casa, CasaDTO>().ReverseMap();
            CreateMap<Terreno, TerrenoDTO>().ReverseMap();
            CreateMap<Villa, VillaDTO>().ReverseMap();
            CreateMap<Nota, NotaDTO>();
            CreateMap<ClienteDTO, Cliente>();

        }
    }
}

