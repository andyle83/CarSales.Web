using System;
using System.Collections.Generic;
using System.Text;

namespace CarSales.Web.Application.ViewModels
{
    public class VehicleTypeDetailsDto : VehicleTypeDto
    {
        public IEnumerable<VehicleDto> Vehicles { get; set; }
    }
}