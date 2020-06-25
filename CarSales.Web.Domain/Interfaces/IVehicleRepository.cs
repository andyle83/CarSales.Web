using CarSales.Web.Models;
using System.Threading.Tasks;

namespace CarSales.Web.Domain.Interfaces
{
    public interface IVehicleRepository
    {
        public Task<Vehicle> GetVehicleAsync(long vehicleId);

        public Task AddVehicleAsync(Vehicle vehicle);

        public Task RemoveVehicleAsync(Vehicle vehicle);

        public Task UpdateVehicleAsync(Vehicle vehicle);
    }
}