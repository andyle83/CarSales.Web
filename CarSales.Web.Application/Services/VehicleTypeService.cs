using AutoMapper;
using CarSales.Web.Application.Interfaces;
using CarSales.Web.Application.ViewModels;
using CarSales.Web.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<VehicleTypeDto>> GetVehicleTypesAsync()
        {
            _logger.LogInformation($"Calling {nameof(GetVehicleTypesAsync)} of {nameof(VehicleTypeService)}");

            var vehicleTypes = await _vehicleTypeRepository.GetVehicleTypesAsync();
            var result = _mapper.Map<IEnumerable<VehicleTypeDto>>(vehicleTypes);

            return result;
        }

        public async Task<VehicleTypeDto> GetVehicleTypeAsync(int vehicleTypeId)
        {
            _logger.LogInformation($"Calling {nameof(GetVehicleTypeAsync)} of {nameof(VehicleTypeService)} with id {vehicleTypeId}");

            var vehicleType = await _vehicleTypeRepository.GetVehicleTypeAsync(vehicleTypeId);
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