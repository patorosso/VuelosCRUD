using AutoMapper;
using VuelosCRUD.Dtos;
using VuelosCRUD.Models;

namespace VuelosCRUD
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Vuelo, VueloDto>();
            CreateMap<VueloDto, Vuelo>();
            CreateMap<Aerolinea, AerolineaDto>();
            CreateMap<AerolineaDto, Aerolinea>();
        }
    }
}