using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSales.Web.Application.Interfaces;
using CarSales.Web.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarSales.Web.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleTypeController : ControllerBase
    {
        private readonly ILogger<VehicleTypeController> _logger;

        public IVehicleTypeService _vehicleTypeService;

        public VehicleTypeController(ILogger<VehicleTypeController> logger, IVehicleTypeService vehicleTypeService)
        {
            _logger = logger;
            _vehicleTypeService = vehicleTypeService;
        }

        /// <summary>
        /// Get list of vehicles in a specific type
        /// </summary>
        /// <param name="id">vehicle Type Id</param>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<VehicleDto>> Get(int id)
        {
            _logger.LogInformation($"Calling {nameof(Get)} of {nameof(VehicleTypeController)} with id {id}");

            var vehicles = _vehicleTypeService.GetVehicles(id);

            if (vehicles == null)
            {
                return NotFound();
            }

            return vehicles.ToList();
        }
    }
}