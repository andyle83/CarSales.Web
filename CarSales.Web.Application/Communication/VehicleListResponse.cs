using CarSales.Web.Application.ViewModels;
using System.Collections.Generic;

namespace CarSales.Web.Application.Communication
{
    public class VehicleListResponse : BaseResponse<IEnumerable<VehicleDto>>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="vehicles">Vehicle List.</param>
        /// <returns>Response.</returns>
        public VehicleListResponse(IEnumerable<VehicleDto> vehicles) : base(vehicles)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public VehicleListResponse(string message) : base(message)
        { }
    }
}