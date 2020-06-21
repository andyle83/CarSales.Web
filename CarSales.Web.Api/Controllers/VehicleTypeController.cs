using CarSales.Web.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CarSales.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class VehicleTypeController : ControllerBase
    {
        private readonly ILogger<VehicleTypeController> _logger;

        private IVehicleTypeService _vehicleTypeService;

        public VehicleTypeController(ILogger<VehicleTypeController> logger, IVehicleTypeService vehicleTypeService)
        {
            _logger = logger;
            _vehicleTypeService = vehicleTypeService;
        }

        /// <summary>
        /// List of vehicle types
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetVehicleTypes()
        {
            _logger.LogInformation($"Calling {nameof(GetVehicleTypes)} of {nameof(VehicleTypeController)}");

            var vehicleTypes = await _vehicleTypeService.GetVehicleTypesAsync();

            if (vehicleTypes == null)
            {
                return NotFound();
            }

            return Ok(vehicleTypes);
        }

        /// <summary>
        /// Get details of a vehicle type
        /// </summary>
        /// <param name="id">Vehicle Type Id</param>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetVehicleTypeAsync(int id)
        {
            _logger.LogInformation($"Calling {nameof(GetVehicleTypeAsync)} of {nameof(VehicleTypeController)} with id {id}");

            var vehicleType = await _vehicleTypeService.GetVehicleTypeAsync(id);

            if (vehicleType == null)
            {
                return NotFound();
            }

            return Ok(vehicleType);
        }

        /// <summary>
        /// List of vehicles in a specific type
        /// </summary>
        /// <param name="id">Vehicle Type Id</param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}/Vehicle/")]
        public IActionResult GetVehiclesByType(int id)
        {
            _logger.LogInformation($"Calling {nameof(GetVehiclesByType)} of {nameof(VehicleTypeController)} with id {id}");

            var vehicles = _vehicleTypeService.GetVehicles(id);

            if (vehicles == null)
            {
                return NotFound();
            }

            return Ok(vehicles);
        }
    }
}