using CarSales.Web.Application.Communication;
using CarSales.Web.Application.Interfaces;
using CarSales.Web.Application.ViewModels;
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
        /// List of vehicle types.
        /// </summary>
        /// <returns>Response for the request.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(VehicleTypeListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetVehicleTypes()
        {
            _logger.LogInformation($"Calling {nameof(GetVehicleTypes)} of {nameof(VehicleTypeController)}");

            var vehicleTypes = await _vehicleTypeService.GetVehicleTypesAsync();

            if (vehicleTypes == null)
            {
                return NotFound(new ErrorResponse("Not found any vehicle types."));
            }

            return Ok(vehicleTypes);
        }

        /// <summary>
        /// Get details of a vehicle type.
        /// </summary>
        /// <param name="id">Vehicle Type identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VehicleTypeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetVehicleTypeAsync(int id)
        {
            _logger.LogInformation($"Calling {nameof(GetVehicleTypeAsync)} of {nameof(VehicleTypeController)} with id {id}");

            var vehicleType = await _vehicleTypeService.GetVehicleTypeAsync(id);

            if (vehicleType?.Resource == null)
            {
                return NotFound(new ErrorResponse("Vehicle Type is not found."));
            }

            return Ok(vehicleType);
        }

        /// <summary>
        /// Add new vehicle type.
        /// </summary>
        /// <param name="resource">Vehicle Type details data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(VehicleTypeResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddVehicleTypeAsync([FromBody] SaveVehicleTypeDto resource)
        {
            _logger.LogInformation($"Calling {nameof(AddVehicleTypeAsync)} of {nameof(VehicleTypeController)} with code {resource.Code}");

            var result = await _vehicleTypeService.AddVehicleTypeAsync(resource);

            if (!result.Success)
            {
                return BadRequest(new ErrorResponse(result.Message));
            }

            return Ok(result);
        }

        /// <summary>
        /// List of all vehicles in a specific type with id.
        /// </summary>
        /// <param name="id">Vehicle Type identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(VehicleListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [Route("{id}/Vehicle/")]
        public async Task<IActionResult> GetVehiclesByType(int id)
        {
            _logger.LogInformation($"Calling {nameof(GetVehiclesByType)} of {nameof(VehicleTypeController)} with id {id}");

            var result = await _vehicleTypeService.GetVehicles(id);

            if (result?.Resource == null)
            {
                return NotFound(new ErrorResponse("Not found any vehicles."));
            }

            return Ok(result);
        }

        /// <summary>
        /// Query vehicle list.
        /// </summary>
        /// <param name="query">Vehicle Type Query.</param>
        /// <returns>Response for the request.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(QueryResultDto<VehicleDto>), StatusCodes.Status200OK)]
        [Route("GetVehicles")]
        public async Task<QueryResultDto<VehicleDto>> QueryVehiclesAsync([FromQuery] VehiclesQueryDto query)
        {
            _logger.LogInformation($"Calling {nameof(QueryVehiclesAsync)} of {nameof(VehicleTypeController)} with id {query.VehicleTypeId}");

            var vehicles = await _vehicleTypeService.GetVehiclesAsync(query);

            if (vehicles == null)
            {
                return null;
            }

            return vehicles;
        }
    }
}