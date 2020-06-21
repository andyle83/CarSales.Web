using CarSales.Web.Application.ViewModels;
using CarSales.Web.Domain.Models;
using System.Collections.Generic;

namespace CarSales.Web.Application.Interfaces
{
    public interface IVehicleTypeService
    {
        public IEnumerable<VehicleTypeDto> GetVehicleTypes();

        public VehicleTypeDto GetVehicleType(int vehicleTypeId);

        public IEnumerable<VehicleDto> GetVehicles(int vehicleTypeId);
    }
}