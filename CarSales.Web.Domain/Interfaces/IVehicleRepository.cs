using CarSales.Web.Models;
using System.Collections.Generic;

namespace CarSales.Web.Domain.Interfaces
{
    public interface IVehicleRepository
    {
        public Vehicle GetVehicle(int vehicleId);
    }
}