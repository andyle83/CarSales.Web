using CarSales.Web.Models;
using System.Collections.Generic;

namespace CarSales.Web.Application.ViewModels
{
    public class VehicleViewModel
    {
        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}