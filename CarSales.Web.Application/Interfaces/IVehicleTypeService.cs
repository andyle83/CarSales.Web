using CarSales.Web.Application.ViewModels;
using System.Collections.Generic;

namespace CarSales.Web.Application.Interfaces
{
    public interface IVehicleTypeService
    {
        public IEnumerable<VehicleDto> GetVehicles(int vehicleType);
    }
}