using CarSales.Web.Application.ViewModels;
using CarSales.Web.Appplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarSales.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly ILogger<VehicleController> _logger;

        public IVehicleService _vehicleService;

        public VehicleController(ILogger<VehicleController> logger, IVehicleService vehicleService)
        {
            _logger = logger;
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public VehicleViewModel Get()
        {
            _logger.LogInformation($"Calling {nameof(Get)} of {nameof(VehicleController)} ");

            return _vehicleService.GetVehicles();
        }
    }
}