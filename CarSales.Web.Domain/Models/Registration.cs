using System;

namespace CarSales.Web.Domain.Models
{
    public class Registration
    {
        public int Id { get; set; }

        public string State { get; set; }

        public string Number { get; set; }

        public DateTime? ExpiredUtc { get; set; }

        public DateTime? RegisteredUtc { get; set; }
    }
}