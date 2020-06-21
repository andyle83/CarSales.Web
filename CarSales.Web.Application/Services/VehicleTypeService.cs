using AutoMapper;
using CarSales.Web.Application.Interfaces;
using CarSales.Web.Application.ViewModels;
using CarSales.Web.Domain.Interfaces;
using CarSales.Web.Domain.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CarSales.Web.Application.Services
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private ILogger<VehicleTypeService> _logger;

        private IVehicleTypeRepository _vehicleTypeRepository;

        private IMapper _mapper;

        public VehicleTypeService(ILogger<VehicleTypeService> logger, IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
        {
            _logger = logger;
            _vehicleTypeRepository = vehicleTypeRepository;
            _mapper = mapper;
        }

        public IEnumerable<VehicleTypeDto> GetVehicleTypes()
        {
            _logger.LogInformation($"Calling {nameof(GetVehicleTypes)} of {nameof(VehicleTypeService)}");

            var vehicleTypes = _vehicleTypeRepository.GetVehicleTypes();
            var result = _mapper.Map<IEnumerable<VehicleTypeDto>>(vehicleTypes);

            return result;
        }

        public VehicleTypeDto GetVehicleType(int vehicleTypeId)
        {
            _logger.LogInformation($"Calling {nameof(GetVehicleType)} of {nameof(VehicleTypeService)} with id {vehicleTypeId}");

            var vehicleType = _vehicleTypeRepository.GetVehicleType(vehicleTypeId);
            var result = _mapper.Map<VehicleTypeDto>(vehicleType);

            return result;
        }

        public IEnumerable<VehicleDto> GetVehicles(int vehicleTypeId)
        {
            _logger.LogInformation($"Calling {nameof(GetVehicles)} of {nameof(VehicleTypeService)} with id {vehicleTypeId}");

            var vehicles = _vehicleTypeRepository.GetVehicles(vehicleTypeId);
            var result = _mapper.Map<IEnumerable<VehicleDto>>(vehicles);

            return result;
        }
    }
}