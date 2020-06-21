using CarSales.Web.Application.Interfaces;
using CarSales.Web.Application.ViewModels;
using CarSales.Web.Appplication.Interfaces;
using CarSales.Web.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSales.Web.Application.Services
{
    public class VehicleTypeService : IVehicleTypeService
    {
        public ILogger<VehicleTypeService> _logger;

        public IVehicleTypeRepository _vehicleTypeRepository;

        public VehicleTypeService(ILogger<VehicleTypeService> logger, IVehicleTypeRepository vehicleTypeRepository)
        {
            _logger = logger;
            _vehicleTypeRepository = vehicleTypeRepository;
        }

        public IEnumerable<VehicleDto> GetVehicles(int vehicleTypeId)
        {
            _logger.LogInformation($"Calling {nameof(GetVehicles)} of {nameof(VehicleTypeService)} with id {vehicleTypeId}");

            List<VehicleDto> result = new List<VehicleDto>();

            var vehicles = _vehicleTypeRepository.GetVehicles(vehicleTypeId);

            // TODO: Should handle this convert in a mapper
            if (vehicles == null) return null;

            foreach (var v in vehicles)
            {
                result.Add(new VehicleDto()
                {
                    Id = v.Id,
                    Description = v.Description,
                    Doors = v.Doors,
                    Wheels = v.Wheels,
                    Make = v.Make,
                    Type = v.Type.Name
                });
            }

            return result;
        }
    }
}