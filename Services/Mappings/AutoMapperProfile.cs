using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InvestureLibrary.Domain.Dtos;
using InvestureLibrary.Domain.Entities;
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



            CreateMap<InversionUpdateDTO, Inversion>();
            CreateMap<ClienteDTO, Cliente>();
            CreateMap<EmpresaUpdateDTO, Empresa>();
            CreateMap<Propiedad, PropiedadDTO>().ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.Direccion))
            .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo));
            CreateMap<PropiedadCreateDTO, Propiedad>(); 

            CreateMap<Casa, CasaDTO>().ReverseMap();//esta mamada que we?
            CreateMap<Terreno, TerrenoDTO>().ReverseMap();
            CreateMap<Villa, VillaDTO>().ReverseMap();
            CreateMap<NotaUpdateDTO, Nota>(); //perame voy a compilar el codigo
        }
    }
}