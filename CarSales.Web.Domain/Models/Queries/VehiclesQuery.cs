namespace CarSales.Web.Domain.Models.Queries
{
    public class VehiclesQuery : Query
    {
        public int? VehicleTypeId { get; set; }

        public VehiclesQuery(int? vehicleTypeId, int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            VehicleTypeId = vehicleTypeId;
        }
    }
}