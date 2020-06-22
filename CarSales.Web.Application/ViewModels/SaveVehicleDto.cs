using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace CarSales.Web.Application.ViewModels
{
    public class SaveVehicleDto
    {
        [Required]
        [Range(2, 10)]
        public int Doors { get; set; }

        [Required]
        [Range(1, 20)]
        public int Wheels { get; set; }

        [Required]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        public string Description { get; set; }

        [Required]
        [Min(1)]
        public int TypeId { get; set; }
    }
}