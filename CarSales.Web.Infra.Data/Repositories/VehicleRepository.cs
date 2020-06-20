using CarSales.Web.Domain.Interfaces;
using CarSales.Web.Infra.Data.Context;
using CarSales.Web.Models;
using System.Collections.Generic;

namespace CarSales.Web.Infra.Data.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        public VehicleDbContext _dbContext;

        public VehicleRepository(VehicleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            return _dbContext.Vehicles;
        }
    }
}