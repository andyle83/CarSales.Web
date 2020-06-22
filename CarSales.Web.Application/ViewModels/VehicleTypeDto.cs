using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarSales.Web.Application.ViewModels
{
    public class VehicleTypeDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Code { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }
    }
}