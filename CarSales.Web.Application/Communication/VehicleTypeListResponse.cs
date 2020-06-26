using CarSales.Web.Application.ViewModels;
using System.Collections.Generic;

namespace CarSales.Web.Application.Communication
{
    public class VehicleTypeListResponse : BaseResponse<IEnumerable<VehicleTypeDto>>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="vehicles">Vehicle List.</param>
        /// <returns>Response.</returns>
        public VehicleTypeListResponse(IEnumerable<VehicleTypeDto> vehicleTypes) : base(vehicleTypes)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public VehicleTypeListResponse(string message) : base(message)
        { }
    }
}