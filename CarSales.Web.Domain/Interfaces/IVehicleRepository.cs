using CarSales.Web.Models;
using System.Collections.Generic;

namespace CarSales.Web.Domain.Interfaces
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> GetVehicles();
    }
}