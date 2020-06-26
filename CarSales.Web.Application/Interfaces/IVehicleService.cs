using CarSales.Web.Application.Communication;
using CarSales.Web.Application.ViewModels;
using System.Threading.Tasks;

namespace CarSales.Web.Appplication.Interfaces
{
    public interface IVehicleService
    {
        public Task<VehicleResponse> GetVehicleAsync(long vehicleId);

        public Task<VehicleResponse> AddVehicleAsync(SaveVehicleDto saveVehicleDto);

        public Task<VehicleResponse> RemoveVehicleAsync(long vehicleId);

        public Task<VehicleResponse> UpdateVehicleAsync(long vehicleId, SaveVehicleDto saveVehicleDto);
    }
}