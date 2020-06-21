using CarSales.Web.Infra.Data.Context;

namespace CarSales.Web.Infra.Data.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly VehicleDbContext _context;

        public BaseRepository(VehicleDbContext context)
        {
            _context = context;
        }
    }
}