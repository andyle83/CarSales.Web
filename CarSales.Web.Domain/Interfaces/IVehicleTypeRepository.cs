using CarSales.Web.Domain.Models;
using CarSales.Web.Domain.Models.Queries;
using CarSales.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSales.Web.Domain.Interfaces
{
    public interface IVehicleTypeRepository
    {
        public Task<IEnumerable<VehicleType>> GetVehicleTypesAsync();

        public Task AddVehicleTypeAsync(VehicleType vehicleType);

        public Task<VehicleType> GetVehicleTypeAsync(int vehicleTypeId);

        public Task<QueryResult<Vehicle>> GetVehiclesAsync(VehiclesQuery query);

        public IEnumerable<Vehicle> GetVehicles(int vehicleTypeId);
    }
}