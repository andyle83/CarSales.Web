using CarSales.Web.Domain.Interfaces;
using CarSales.Web.Infra.Data.Context;
using CarSales.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CarSales.Web.Infra.Data.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private VehicleDbContext _dbContext;

        public VehicleRepository(VehicleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Vehicle GetVehicle(int vehicleId)
        {
            return _dbContext.Vehicles
                .Where(vehicle => vehicle.Id == vehicleId)
                .Include(t => t.Type)
                .FirstOrDefault();
        }
    }
}