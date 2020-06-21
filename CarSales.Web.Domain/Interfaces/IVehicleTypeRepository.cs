using CarSales.Web.Domain.Models;
using CarSales.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSales.Web.Domain.Interfaces
{
    public interface IVehicleTypeRepository
    {
        public Task<IEnumerable<VehicleType>> GetVehicleTypesAsync();

        public Task<VehicleType> GetVehicleTypeAsync(int vehicleTypeId);

        public IEnumerable<Vehicle> GetVehicles(int vehicleTypeId);
    }
}