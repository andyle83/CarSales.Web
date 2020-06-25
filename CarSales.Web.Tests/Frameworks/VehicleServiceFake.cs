using CarSales.Web.Application.Communication;
using CarSales.Web.Application.ViewModels;
using CarSales.Web.Appplication.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSales.Web.Tests.Frameworks
{
    public class VehicleServiceFake : IVehicleService
    {
        // fake data store
        private List<VehicleResponse> _vehicleSample = new List<VehicleResponse>();

        private List<int> validVehicleTypeId = new List<int> { 1, 2 };

        public VehicleServiceFake()
        {
            _vehicleSample.Add(new VehicleResponse(new VehicleDto
            {
                Id = 1,
                Description = "description",
                Doors = 2,
                Wheels = 4,
                Model = "Vios",
                Make = "Toyota",
                TypeId = 1,
            }));

            _vehicleSample.Add(new VehicleResponse(new VehicleDto
            {
                Id = 2,
                Description = "description",
                Doors = 5,
                Wheels = 4,
                Model = "Civic",
                Make = "Honda",
                TypeId = 1,
            }));
        }

        public Task<VehicleResponse> AddVehicleAsync(SaveVehicleDto saveVehicleDto)
        {
            VehicleResponse result;

            long vehicleId = _vehicleSample.Select(vehicle => vehicle.Resource.Id).Max() + 1;

            if (saveVehicleDto.TypeId > 0 && validVehicleTypeId.IndexOf(saveVehicleDto.TypeId) >= 0)
            {
                VehicleDto vehicle = new VehicleDto
                {
                    Id = vehicleId,
                    Description = saveVehicleDto.Description,
                    Doors = saveVehicleDto.Doors,
                    Wheels = saveVehicleDto.Wheels,
                    Make = saveVehicleDto.Make,
                    Model = saveVehicleDto.Model
                };

                result = new VehicleResponse(vehicle);
                _vehicleSample.Add(result);
            }
            else
            {
                result = new VehicleResponse("Invalid vehicle data");
            }

            return Task.FromResult(result);
        }

        public Task<VehicleResponse> GetVehicleAsync(long vehicleId)
        {
            VehicleResponse result = _vehicleSample.FirstOrDefault(vehicle => vehicle.Resource.Id == vehicleId);

            return Task.FromResult(result);
        }

        public Task<VehicleResponse> RemoveVehicleAsync(long vehicleId)
        {
            VehicleResponse result = _vehicleSample.FirstOrDefault(vehicle => vehicle.Resource.Id == vehicleId);

            _vehicleSample.Remove(result);

            return Task.FromResult(result);
        }

        public Task<VehicleResponse> UpdateVehicleAsync(long vehicleId, SaveVehicleDto vehicleDto)
        {
            VehicleResponse result = _vehicleSample.FirstOrDefault(vehicle => vehicle.Resource.Id == vehicleId);

            result.Resource.Doors = vehicleDto.Doors;
            result.Resource.Wheels = vehicleDto.Wheels;
            result.Resource.Make = vehicleDto.Make;
            result.Resource.Model = vehicleDto.Model;
            result.Resource.Description = vehicleDto.Description;

            return Task.FromResult(result);
        }
    }
}