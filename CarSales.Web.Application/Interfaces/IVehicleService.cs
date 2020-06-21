using CarSales.Web.Application.ViewModels;
using System.Threading.Tasks;

namespace CarSales.Web.Appplication.Interfaces
{
    public interface IVehicleService
    {
        public Task<VehicleDto> GetVehicle(int vehicleId);
    }
}