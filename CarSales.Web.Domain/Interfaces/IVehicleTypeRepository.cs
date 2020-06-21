using CarSales.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSales.Web.Domain.Interfaces
{
    public interface IVehicleTypeRepository
    {
        public IEnumerable<Vehicle> GetVehicles(int vehicleTypeId);
    }
}