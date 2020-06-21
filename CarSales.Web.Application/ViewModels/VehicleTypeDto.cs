using System.Collections.Generic;

namespace CarSales.Web.Application.ViewModels
{
    public class VehicleTypeDto
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public virtual ICollection<VehicleDto> Vehicles { get; set; }
    }
}