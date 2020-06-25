using CarSales.Web.Api.Controllers;
using CarSales.Web.Application.Communication;
using CarSales.Web.Application.ViewModels;
using CarSales.Web.Appplication.Interfaces;
using CarSales.Web.Tests.Frameworks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CarSales.Web.Tests.Controllers
{
    public class VehicleControllerTest
    {
        private readonly VehicleController _vehicleController;

        private readonly Mock<ILogger<VehicleController>> _loggerMock;
        private readonly IVehicleService _vehicleServiceFake;

        public VehicleControllerTest()
        {
            _vehicleServiceFake = new VehicleServiceFake();
            _loggerMock = new Mock<ILogger<VehicleController>>();

            _vehicleController = new VehicleController(_loggerMock.Object, _vehicleServiceFake);
        }

        [Fact]
        public void GetVehicleAsync_When_Get_Called_ReturnOkResult()
        {
            // Arrange
            int vehicleId = 1;

            // Act
            var okResult = _vehicleController.GetVehicleAsync(vehicleId).GetAwaiter().GetResult();

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetVehicleAsync_When_Get_Caled_ReturnNotFoundResult()
        {
            // Arrange
            int vehicleId = 100;

            // Act
            var notFoundResult = _vehicleController.GetVehicleAsync(vehicleId).GetAwaiter().GetResult();

            // Assert
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }

        [Fact]
        public void AddVehicleAsync_When_Get_Called_ReturnOkResult()
        {
            // Arrange
            var saveVehicle = new SaveVehicleDto
            {
                Doors = 1,
                Wheels = 2,
                Description = "Sample Vehicle Data",
                Model = "Corolla",
                Make = "Toyota",
                TypeId = 1,
            };

            // Act
            var okResult = _vehicleController.AddVehicleAsync(saveVehicle).GetAwaiter().GetResult();

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void AddVehicleAsync_When_Get_Called_ReturnBadRequest()
        {
            // Arrange
            var saveVehicle = new SaveVehicleDto
            {
                Doors = 1,
                Wheels = 2,
                Description = "Sample Vehicle Data",
                Model = "Corolla",
                Make = "Toyota",
                TypeId = 100,
            };

            // Act
            var okResult = _vehicleController.AddVehicleAsync(saveVehicle).GetAwaiter().GetResult();

            // Assert
            Assert.IsType<BadRequestObjectResult>(okResult);
        }
    }
}