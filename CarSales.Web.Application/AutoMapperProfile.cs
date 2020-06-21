using AutoMapper;
using CarSales.Web.Application.ViewModels;
using CarSales.Web.Models;

namespace CarSales.Web.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Vehicle, VehicleDto>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Name));
        }
    }
}