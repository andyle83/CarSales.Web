using CarSales.Web.Application.ViewModels;
using CarSales.Web.Appplication.Interfaces;
using CarSales.Web.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace CarSales.Web.Application.Services
{
    public class VehicleService : IVehicleService
    {
        public ILogger<VehicleService> _logger;

        public IVehicleRepository _vehicleRepository;

        public VehicleService(ILogger<VehicleService> logger, IVehicleRepository vehicleRepository)
        {
            _logger = logger;
            _vehicleRepository = vehicleRepository;
        }

        public VehicleViewModel GetVehicles()
        {
            _logger.LogInformation($"Calling {nameof(GetVehicles)} of {nameof(VehicleService)}");

            return new VehicleViewModel()
            {
                Vehicles = _vehicleRepository.GetVehicles()
            };
        }
    }
}