using CarSales.Web.Application.ViewModels;
using System.Collections.Generic;

namespace CarSales.Web.Appplication.Interfaces
{
    public interface IVehicleService
    {
        public VehicleDto GetVehicle(int vehicleId);
    }
}