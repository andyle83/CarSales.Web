using CarSales.Web.Domain.Models;
using System.Collections.Generic;

namespace CarSales.Web.Models
{
    public class Vehicle
    {
        public long Id { get; set; }

        public int Doors { get; set; }

        public int Wheels { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }

        public int TypeId { get; set; }

        public VehicleType Type { get; set; }

        public Registration Registration { get; set; }

        public List<VehicleAttribute> Attributes { get; set; }
    }
}