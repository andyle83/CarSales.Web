using AutoMapper;
using CarSales.Web.Application.ViewModels;
using CarSales.Web.Domain.Models;
using CarSales.Web.Domain.Models.Queries;
using CarSales.Web.Models;

namespace CarSales.Web.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Vehicle, VehicleDto>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Name));

            CreateMap<QueryResult<Vehicle>, QueryResultDto<VehicleDto>>();
            CreateMap<VehiclesQueryDto, VehiclesQuery>();

            CreateMap<VehicleType, VehicleTypeDto>();
            CreateMap<SaveVehicleTypeDto, VehicleType>();
        }
    }
}