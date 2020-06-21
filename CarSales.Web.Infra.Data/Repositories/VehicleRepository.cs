using CarSales.Web.Domain.Interfaces;
using CarSales.Web.Infra.Data.Context;
using CarSales.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CarSales.Web.Infra.Data.Repositories
{
    public class VehicleRepository : BaseRepository, IVehicleRepository
    {
        public VehicleRepository(VehicleDbContext context) : base(context)
        {
        }

        public async Task<Vehicle> GetVehicleAsync(int vehicleId)
        {
            var vehicle = await _context.Vehicles
                            .Where(vehicle => vehicle.Id == vehicleId)
                            .Include(t => t.Type)
                            .FirstOrDefaultAsync();

            return vehicle;
        }
    }
}