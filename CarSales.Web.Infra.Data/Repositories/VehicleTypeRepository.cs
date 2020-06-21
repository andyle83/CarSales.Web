using CarSales.Web.Domain.Interfaces;
using CarSales.Web.Domain.Models;
using CarSales.Web.Infra.Data.Context;
using CarSales.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CarSales.Web.Infra.Data.Repositories
{
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        private VehicleDbContext _dbContext;

        public VehicleTypeRepository(VehicleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<VehicleType> GetVehicleTypes()
        {
            var result = _dbContext.VehicleTypes.Include(v => v.Vehicles);

            return result;
        }

        public VehicleType GetVehicleType(int vehicleTypeId)
        {
            var result = _dbContext.VehicleTypes.Where(t => t.Id == vehicleTypeId).FirstOrDefault();

            return result;
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