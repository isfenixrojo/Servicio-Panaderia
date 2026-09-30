using API.Panaderia.Dominio.DTOs;
using API.Panaderia.Dominio.Modelos;
using AutoMapper;

namespace API.Panaderia.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<Pan, ViewPanDTO>().ReverseMap();
            CreateMap<Pan, CreatePanDTO>().ReverseMap();
            CreateMap<Pan, UpdatePanDTO>().ReverseMap();
        }
    }
}
