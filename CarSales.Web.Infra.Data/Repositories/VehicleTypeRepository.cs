using CarSales.Web.Domain.Interfaces;
using CarSales.Web.Domain.Models;
using CarSales.Web.Domain.Models.Queries;
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
                            .AsNoTracking()
                            .ToListAsync();

            return result;
        }

        public async Task<VehicleType> GetVehicleTypeAsync(int vehicleTypeId)
        {
            var result = await _context.VehicleTypes
                            .Where(t => t.Id == vehicleTypeId)
                            .Include(v => v.Vehicles)
                            .AsNoTracking()
                            .FirstOrDefaultAsync();

            return result;
        }

        public async Task<QueryResult<Vehicle>> GetVehiclesAsync(VehiclesQuery query)
        {
            IQueryable<Vehicle> queryable = _context.Vehicles;

            if (query.VehicleTypeId.HasValue && query.VehicleTypeId > 0)
            {
                queryable = queryable.Where(t => t.TypeId == query.VehicleTypeId);
            }

            int totalItems = await queryable.CountAsync();

            List<Vehicle> vehicles = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
                                        .Take(query.ItemsPerPage)
                                        .AsNoTracking()
                                        .ToListAsync();

            return new QueryResult<Vehicle>
            {
                Items = vehicles,
                TotalItems = totalItems
            };
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

        public async Task AddVehicleTypeAsync(VehicleType vehicleType)
        {
            await _context.VehicleTypes.AddAsync(vehicleType);
            await _context.SaveChangesAsync();
        }
    }
}