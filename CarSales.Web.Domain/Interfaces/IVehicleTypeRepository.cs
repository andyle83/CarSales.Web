using CarSales.Web.Models;
using System.Collections.Generic;

namespace CarSales.Web.Domain.Interfaces
{
    public interface IVehicleTypeRepository
    {
        public IEnumerable<Vehicle> GetVehicles(int vehicleTypeId);
    }
}