using AutoMapper;
using CarSales.Web.Application.Communication;
using CarSales.Web.Application.ViewModels;
using CarSales.Web.Appplication.Interfaces;
using CarSales.Web.Domain.Interfaces;
using CarSales.Web.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CarSales.Web.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private ILogger<VehicleService> _logger;

        private IVehicleRepository _vehicleRepository;
        private IVehicleTypeRepository _vehicleTypeRepository;

        private IMapper _mapper;

        public VehicleService(ILogger<VehicleService> logger, IVehicleRepository vehicleRepository, IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
        {
            _logger = logger;
            _vehicleRepository = vehicleRepository;
            _vehicleTypeRepository = vehicleTypeRepository;
            _mapper = mapper;
        }

        public async Task<VehicleResponse> GetVehicleAsync(int vehicleId)
        {
            _logger.LogInformation($"Calling {nameof(GetVehicleAsync)} of {nameof(VehicleService)} with id {vehicleId}");

            var vehicle = await _vehicleRepository.GetVehicleAsync(vehicleId);
            var result = _mapper.Map<VehicleDto>(vehicle);

            return new VehicleResponse(result);
        }

        public async Task<VehicleResponse> AddVehicleAsync(SaveVehicleDto saveVehicleDto)
        {
            _logger.LogInformation($"Calling {nameof(AddVehicleAsync)} of {nameof(VehicleService)}");

            try
            {
                var vehicle = _mapper.Map<SaveVehicleDto, Vehicle>(saveVehicleDto);

                var vehicleType = await _vehicleTypeRepository.GetVehicleTypeAsync(saveVehicleDto.TypeId);

                if (vehicleType == null)
                {
                    return new VehicleResponse($"The vehicle type is not existed");
                }

                await _vehicleRepository.AddVehicleAsync(vehicle);

                var result = _mapper.Map<Vehicle, VehicleDto>(vehicle);
                result.Type = vehicleType.Name;

                return new VehicleResponse(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An issue occurred when saving a new vehicle with error message {ex.Message}");

                return new VehicleResponse($"An error occurred when saving a new vehicle: {ex.Message}");
            }
        }

        public async Task<VehicleResponse> RemoveVehicleAsync(int vehicleId)
        {
            _logger.LogInformation($"Calling {nameof(RemoveVehicleAsync)} of {nameof(VehicleService)} with id {vehicleId}");

            var existingVehicle = await _vehicleRepository.GetVehicleAsync(vehicleId);

            if (existingVehicle == null)
                return new VehicleResponse("Vehicle is not found.");

            try
            {
                await _vehicleRepository.RemoveVehicleAsync(existingVehicle);

                var result = _mapper.Map<Vehicle, VehicleDto>(existingVehicle);

                return new VehicleResponse(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An issue occured when deleting the vehicle id {vehicleId} with error message {ex.Message}");

                return new VehicleResponse($"An error occurred when deleting the vehicle: {ex.Message}");
            }
        }

        public async Task<VehicleResponse> UpdateVehicleAsync(int vehicleId, SaveVehicleDto saveVehicleDto)
        {
            _logger.LogInformation($"Calling {nameof(UpdateVehicleAsync)} of {nameof(VehicleService)} with id {vehicleId}");

            var existingVehicle = await _vehicleRepository.GetVehicleAsync(vehicleId);

            if (existingVehicle == null)
                return new VehicleResponse("Vehicle is not found.");

            var existingVehicleType = await _vehicleTypeRepository.GetVehicleTypeAsync(saveVehicleDto.TypeId);

            if (existingVehicleType == null)
                return new VehicleResponse("Invalid vehicle type.");

            existingVehicle.Doors = saveVehicleDto.Doors;
            existingVehicle.Wheels = saveVehicleDto.Wheels;
            existingVehicle.Model = saveVehicleDto.Model;
            existingVehicle.Make = saveVehicleDto.Make;
            existingVehicle.TypeId = saveVehicleDto.TypeId;

            try
            {
                await _vehicleRepository.UpdateVehicleAsync(existingVehicle);

                var result = _mapper.Map<Vehicle, VehicleDto>(existingVehicle);

                return new VehicleResponse(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An issue occurred when update the vehicle {vehicleId} with error message {ex.Message}");

                return new VehicleResponse($"An error occurred when updating the vehicle: {ex.Message}");
            }
        }
    }
}