using System;
using System.Collections.Generic;
using System.Text;

namespace CarSales.Web.Domain.Models
{
    public class VehicleAttribute
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        public int Units { get; set; }
    }
}