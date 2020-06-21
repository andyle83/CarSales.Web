using CarSales.Web.Domain.Interfaces;
using CarSales.Web.Infra.Data.Context;
using CarSales.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarSales.Web.Infra.Data.Repositories
{
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        public VehicleDbContext _dbContext;

        public VehicleTypeRepository(VehicleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Vehicle> GetVehicles(int vehicleTypeId)
        {
            var type = _dbContext.VehicleTypes.Where(t => t.Id == vehicleTypeId).FirstOrDefault();

            if (type == null) return null;

            var vehicles = _dbContext.Entry(type)
                .Collection(t => t.Vehicles)
                .Query()
                .ToList();

            return vehicles;
        }
    }
}