using CarSales.Web.Application.ViewModels;
using CarSales.Web.Appplication.Interfaces;
using CarSales.Web.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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

        public VehicleDto GetVehicle(int vehicleId)
        {
            _logger.LogInformation($"Calling {nameof(GetVehicle)} of {nameof(VehicleService)} with id {vehicleId}");

            var vehicle = _vehicleRepository.GetVehicle(vehicleId);

            // TODO: Should handle this convert in a mapper
            if (vehicle == null) return null;

            return new VehicleDto()
            {
                Id = vehicle.Id,
                Doors = vehicle.Doors,
                Wheels = vehicle.Wheels,
                Type = vehicle.Type.Name
            };
        }
    }
}