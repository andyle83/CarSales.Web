using CarSales.Web.Models;
using System.Threading.Tasks;

namespace CarSales.Web.Domain.Interfaces
{
    public interface IVehicleRepository
    {
        public Task<Vehicle> GetVehicleAsync(int vehicleId);
    }
}