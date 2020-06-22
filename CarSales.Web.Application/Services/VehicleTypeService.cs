using AutoMapper;
using CarSales.Web.Application.Communication;
using CarSales.Web.Application.Interfaces;
using CarSales.Web.Application.ViewModels;
using CarSales.Web.Domain.Interfaces;
using CarSales.Web.Domain.Models;
using CarSales.Web.Domain.Models.Queries;
using CarSales.Web.Models;
using Microsoft.Extensions.Logging;
using System;
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

        public async Task<VehicleTypeDetailsDto> GetVehicleTypeAsync(int vehicleTypeId)
        {
            _logger.LogInformation($"Calling {nameof(GetVehicleTypeAsync)} of {nameof(VehicleTypeService)} with id {vehicleTypeId}");

            var vehicleType = await _vehicleTypeRepository.GetVehicleTypeAsync(vehicleTypeId);
            var result = _mapper.Map<VehicleType, VehicleTypeDetailsDto>(vehicleType);

            return result;
        }

        public async Task<QueryResultDto<VehicleDto>> GetVehiclesAsync(VehiclesQueryDto query)
        {
            _logger.LogInformation($"Calling {nameof(GetVehiclesAsync)} of {nameof(VehicleTypeService)} with id {query.VehicleTypeId}");

            var vehiclesQuery = _mapper.Map<VehiclesQueryDto, VehiclesQuery>(query);
            var vehicles = await _vehicleTypeRepository.GetVehiclesAsync(vehiclesQuery);

            var result = _mapper.Map<QueryResult<Vehicle>, QueryResultDto<VehicleDto>>(vehicles);

            return result;
        }

        public IEnumerable<VehicleDto> GetVehicles(int vehicleTypeId)
        {
            _logger.LogInformation($"Calling {nameof(GetVehicles)} of {nameof(VehicleTypeService)} with id {vehicleTypeId}");

            var vehicles = _vehicleTypeRepository.GetVehicles(vehicleTypeId);
            var result = _mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleDto>>(vehicles);

            return result;
        }

        public async Task<VehicleTypeResponse> AddVehicleTypeAsync(SaveVehicleTypeDto saveVehicleTypeDto)
        {
            _logger.LogInformation($"Calling {nameof(AddVehicleTypeAsync)} of {nameof(VehicleTypeService)} with code {saveVehicleTypeDto.Code}");

            try
            {
                var vehicleType = _mapper.Map<SaveVehicleTypeDto, VehicleType>(saveVehicleTypeDto);

                // TODO: Need to throw an error if code is existed
                await _vehicleTypeRepository.AddVehicleTypeAsync(vehicleType);

                var result = _mapper.Map<VehicleType, VehicleTypeDetailsDto>(vehicleType);

                return new VehicleTypeResponse(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An issue occurred when saving the vehicle type with code {saveVehicleTypeDto.Code} with error message {ex.Message}");

                return new VehicleTypeResponse($"An error occurred when saving the vehicle type: {ex.Message}");
            }
        }
    }
}