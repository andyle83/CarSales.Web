using CarSales.Web.Application.Communication;
using CarSales.Web.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSales.Web.Application.Interfaces
{
    public interface IVehicleTypeService
    {
        public Task<IEnumerable<VehicleTypeDto>> GetVehicleTypesAsync();

        public Task<VehicleTypeResponse> AddVehicleTypeAsync(SaveVehicleTypeDto vehicleTypeDto);

        public Task<VehicleTypeDto> GetVehicleTypeAsync(int vehicleTypeId);

        public Task<QueryResultDto<VehicleDto>> GetVehiclesAsync(VehiclesQueryDto query);

        public IEnumerable<VehicleDto> GetVehicles(int vehicleTypeId);
    }
}