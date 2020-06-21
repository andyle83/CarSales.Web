using System.Collections.Generic;

namespace CarSales.Web.Application.ViewModels
{
    public class QueryResultDto<T>
    {
        public int TotalItems { get; set; } = 0;
        public List<T> Items { get; set; } = new List<T>();
    }
}