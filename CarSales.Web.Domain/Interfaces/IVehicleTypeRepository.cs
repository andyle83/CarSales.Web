using CarSales.Web.Domain.Models;
using CarSales.Web.Models;
using System.Collections.Generic;

namespace CarSales.Web.Domain.Interfaces
{
    public interface IVehicleTypeRepository
    {
        public IEnumerable<VehicleType> GetVehicleTypes();

        public VehicleType GetVehicleType(int vehicleTypeId);

        public IEnumerable<Vehicle> GetVehicles(int vehicleTypeId);
    }
}