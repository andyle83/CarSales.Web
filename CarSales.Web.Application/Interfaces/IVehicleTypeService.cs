using CarSales.Web.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSales.Web.Application.Interfaces
{
    public interface IVehicleTypeService
    {
        public IEnumerable<VehicleDto> GetVehicles(int vehicleType);
    }
}