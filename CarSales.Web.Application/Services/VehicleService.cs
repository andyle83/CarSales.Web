using AutoMapper;
using CarSales.Web.Application.ViewModels;
using CarSales.Web.Appplication.Interfaces;
using CarSales.Web.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CarSales.Web.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private ILogger<VehicleService> _logger;

        private IVehicleRepository _vehicleRepository;

        private IMapper _mapper;

        public VehicleService(ILogger<VehicleService> logger, IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _logger = logger;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<VehicleDto> GetVehicle(int vehicleId)
        {
            _logger.LogInformation($"Calling {nameof(GetVehicle)} of {nameof(VehicleService)} with id {vehicleId}");

            var vehicle = await _vehicleRepository.GetVehicleAsync(vehicleId);
            var result = _mapper.Map<VehicleDto>(vehicle);

            return result;
        }
    }
}