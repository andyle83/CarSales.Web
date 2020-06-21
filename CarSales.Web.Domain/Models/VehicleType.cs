using CarSales.Web.Models;
using System.Collections.Generic;

namespace CarSales.Web.Domain.Models
{
    public class VehicleType
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}