using CarSales.Web.Models;

namespace CarSales.Web.Domain.Interfaces
{
    public interface IVehicleRepository
    {
        public Vehicle GetVehicle(int vehicleId);
    }
}