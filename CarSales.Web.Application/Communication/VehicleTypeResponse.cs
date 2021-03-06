﻿using CarSales.Web.Application.ViewModels;

namespace CarSales.Web.Application.Communication
{
    public class VehicleTypeResponse : BaseResponse<VehicleTypeDetailsDto>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="vehicleType">Saved vehicle type.</param>
        /// <returns>Response.</returns>
        public VehicleTypeResponse(VehicleTypeDetailsDto vehicleType) : base(vehicleType)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public VehicleTypeResponse(string message) : base(message)
        { }
    }
}