using System.ComponentModel.DataAnnotations;

namespace CarSales.Web.Application.ViewModels
{
    public class SaveVehicleTypeDto
    {
        [Required]
        [MaxLength(10)]
        public string Code { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}