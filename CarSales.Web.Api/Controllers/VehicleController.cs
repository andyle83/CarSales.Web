﻿using CarSales.Web.Application.ViewModels;
using CarSales.Web.Appplication.Interfaces;
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
        /// Get details of a vehicle
        /// </summary>
        /// <param name="id">Vehicle Id</param>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VehicleDto> GetVehicle(int id)
        {
            _logger.LogInformation($"Calling {nameof(GetVehicle)} of {nameof(VehicleController)} with id {id}");

            var vehicle = _vehicleService.GetVehicle(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return vehicle;
        }
    }
}