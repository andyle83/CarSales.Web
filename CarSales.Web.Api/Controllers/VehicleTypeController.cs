using CarSales.Web.Application.Interfaces;
using CarSales.Web.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace CarSales.Web.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
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
        /// Get list of vehicle types
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<VehicleTypeDto>> GetVehicleTypes()
        {
            _logger.LogInformation($"Calling {nameof(GetVehicleTypes)} of {nameof(VehicleTypeController)}");

            var vehicleTypes = _vehicleTypeService.GetVehicleTypes();

            if (vehicleTypes == null)
            {
                return NotFound();
            }

            return vehicleTypes.ToList();
        }

        /// <summary>
        /// Get details of a vehicle type
        /// </summary>
        /// <param name="id">Vehicle Type Id</param>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VehicleTypeDto> GetVehicleType(int id)
        {
            _logger.LogInformation($"Calling {nameof(GetVehicleTypes)} of {nameof(VehicleTypeController)} with id {id}");

            var vehicleType = _vehicleTypeService.GetVehicleType(id);

            if (vehicleType == null)
            {
                return NotFound();
            }

            return vehicleType;
        }

        /// <summary>
        /// Get list of vehicles in a specific type
        /// </summary>
        /// <param name="id">Vehicle Type Id</param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}/Vehicle/")]
        public ActionResult<IEnumerable<VehicleDto>> GetVehiclesByType(int id)
        {
            _logger.LogInformation($"Calling {nameof(GetVehiclesByType)} of {nameof(VehicleTypeController)} with id {id}");

            var vehicles = _vehicleTypeService.GetVehicles(id);

            if (vehicles == null)
            {
                return NotFound();
            }

            return vehicles.ToList();
        }
    }
}