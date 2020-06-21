using AutoMapper;
using CarSales.Web.Application.Interfaces;
using CarSales.Web.Application.ViewModels;
using CarSales.Web.Domain.Interfaces;
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

        public IEnumerable<VehicleDto> GetVehicles(int vehicleTypeId)
        {
            _logger.LogInformation($"Calling {nameof(GetVehicles)} of {nameof(VehicleTypeService)} with id {vehicleTypeId}");

            var vehicles = _vehicleTypeRepository.GetVehicles(vehicleTypeId);

            return _mapper.Map<IEnumerable<VehicleDto>>(vehicles);
        }
    }
}