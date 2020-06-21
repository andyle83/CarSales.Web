using CarSales.Web.Application.ViewModels;

namespace CarSales.Web.Appplication.Interfaces
{
    public interface IVehicleService
    {
        public VehicleDto GetVehicle(int vehicleId);
    }
}