using CarSales.Web.Application.ViewModels;

namespace CarSales.Web.Application.Communication
{
    public class VehicleResponse : BaseResponse<VehicleDto>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="vehicleType">Saved vehicle</param>
        /// <returns>Response.</returns>
        public VehicleResponse(VehicleDto vehicle) : base(vehicle)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message</param>
        /// <returns>Response.</returns>
        public VehicleResponse(string message) : base(message)
        { }
    }
}