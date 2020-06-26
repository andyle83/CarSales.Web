using System.Collections.Generic;

namespace CarSales.Web.Application.ViewModels
{
    public class VehicleTypeDetailsDto : VehicleTypeDto
    {
        public IEnumerable<VehicleDto> Vehicles { get; set; }
    }
}