using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSales.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private static readonly string[] Makes = new[]
        {
            "Toyota", "Volkswagen Group", "Hyundai / Kia", "General Motors", "Ford", "Nissan", "Honda", "FCA", "Renault", "Group PSA"
        };

        private static readonly string[] Models = new[]
        {
            "Toyota Hilux", "Ford Ranger", "Hyundai i30", "Hyundai Tucson", "Toyota Corolla"
        };

        private readonly ILogger<VehicleController> _logger;

        public VehicleController(ILogger<VehicleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Vehicle> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 10).Select(index => new Vehicle
            {
                VehicleId = index,
                Doors = 4,
                Wheels = 4,
                Model = Models[rng.Next(Models.Length)],
                Make = Makes[rng.Next(Makes.Length)]
            })
            .ToArray();
        }
    }
}