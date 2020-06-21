using CarSales.Web.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSales.Web.Application.Interfaces
{
    public interface IVehicleTypeService
    {
        public Task<IEnumerable<VehicleTypeDto>> GetVehicleTypesAsync();

        public Task<VehicleTypeDto> GetVehicleTypeAsync(int vehicleTypeId);

        public IEnumerable<VehicleDto> GetVehicles(int vehicleTypeId);
    }
}