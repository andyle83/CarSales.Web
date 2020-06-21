using CarSales.Web.Domain.Interfaces;
using CarSales.Web.Domain.Models;
using CarSales.Web.Infra.Data.Context;
using CarSales.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSales.Web.Infra.Data.Repositories
{
    public class VehicleTypeRepository : BaseRepository, IVehicleTypeRepository
    {
        public VehicleTypeRepository(VehicleDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<VehicleType>> GetVehicleTypesAsync()
        {
            var result = await _context.VehicleTypes
                            .Include(v => v.Vehicles)
                            .AsNoTracking()
                            .ToListAsync();

            return result;
        }

        public async Task<VehicleType> GetVehicleTypeAsync(int vehicleTypeId)
        {
            var result = await _context.VehicleTypes
                            .Where(t => t.Id == vehicleTypeId)
                            .FirstOrDefaultAsync();

            return result;
        }

        public IEnumerable<Vehicle> GetVehicles(int vehicleTypeId)
        {
            var type = _context.VehicleTypes
                        .Where(t => t.Id == vehicleTypeId)
                        .FirstOrDefault();

            if (type == null) return null;

            var vehicles = _context.Entry(type)
                            .Collection(t => t.Vehicles)
                            .Query()
                            .ToList();

            return vehicles;
        }
    }
}