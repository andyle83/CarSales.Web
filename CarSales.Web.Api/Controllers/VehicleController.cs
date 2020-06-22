using CarSales.Web.Application.Communication;
using CarSales.Web.Application.ViewModels;
using CarSales.Web.Appplication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CarSales.Web.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly ILogger<VehicleController> _logger;

        private IVehicleService _vehicleService;

        public VehicleController(ILogger<VehicleController> logger, IVehicleService vehicleService)
        {
            _logger = logger;
            _vehicleService = vehicleService;
        }

        /// <summary>
        /// Get details of a vehicle.
        /// </summary>
        /// <param name="id">Vehicle identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VehicleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetVehicleAsync(int id)
        {
            _logger.LogInformation($"Calling {nameof(GetVehicleAsync)} of {nameof(VehicleController)} with id {id}");

            var vehicle = await _vehicleService.GetVehicleAsync(id);

            if (vehicle == null)
            {
                return NotFound(new ErrorResponse("Vehicle is not found."));
            }

            return Ok(new VehicleResponse(vehicle));
        }

        /// <summary>
        /// Add new vehicle.
        /// </summary>
        /// <param name="resource">Vehicle details data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(VehicleResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddVehicleAsync([FromBody] SaveVehicleDto resource)
        {
            _logger.LogInformation($"Calling {nameof(AddVehicleAsync)} of {nameof(VehicleController)}");

            var result = await _vehicleService.AddVehicleAsync(resource);

            if (!result.Success)
            {
                return BadRequest(new ErrorResponse(result.Message));
            }

            return Ok(result.Resource);
        }

        /// <summary>
        /// Delete a vehicle.
        /// </summary>
        /// <param name="id">Vehicle identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(VehicleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveVehicleAsync(int id)
        {
            _logger.LogInformation($"Calling {nameof(RemoveVehicleAsync)} of {nameof(VehicleController)} with id {id}");

            var result = await _vehicleService.RemoveVehicleAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResponse(result.Message));
            }

            return Ok(result.Resource);
        }

        /// <summary>
        /// Updates an existing vehicle according to an identifier.
        /// </summary>
        /// <param name="id">Vehicle identifier.</param>
        /// <param name="resource">Vehicle details data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(VehicleResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] SaveVehicleDto resource)
        {
            var result = await _vehicleService.UpdateVehicleAsync(id, resource);

            if (!result.Success)
            {
                return BadRequest(new ErrorResponse(result.Message));
            }

            return Ok(result.Resource);
        }
    }
}