using CarSales.Web.Application.Services;
using CarSales.Web.Appplication.Interfaces;
using CarSales.Web.Domain.Interfaces;
using CarSales.Web.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CarSales.Web.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //CarSales.Web.Api
            services.AddScoped<IVehicleService, VehicleService>();

            //CarSales.Web.Domain | CarSales.Web.Infra
            services.AddScoped<IVehicleRepository, VehicleRepository>();
        }
    }
}