using System;
using System.Collections.Generic;
using System.Text;

namespace CarSales.Web.Application.ViewModels
{
    public class VehicleDto
    {
        public int Id { get; set; }

        public int Doors { get; set; }

        public int Wheels { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }
    }
}