using CarSales.Web.Application.Communication;
using CarSales.Web.Application.ViewModels;
using System.Threading.Tasks;

namespace CarSales.Web.Appplication.Interfaces
{
    public interface IVehicleService
    {
        public Task<VehicleDto> GetVehicleAsync(int vehicleId);

        public Task<VehicleResponse> AddVehicleAsync(SaveVehicleDto vehicleTypeDto);

        public Task<VehicleResponse> RemoveVehicleAsync(int vehicleId);

        public Task<VehicleResponse> UpdateVehicleAsync(int vehicleId, SaveVehicleDto vehicleDto);
    }
}