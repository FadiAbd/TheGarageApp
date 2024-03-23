using TheGarageApp.Models;
using TheGarageApp.Services;

namespace TheGarageTests
{
    public class GarageTests
    {
        [Fact]
        public void AddVehicle_Should_AddVehicleToGarage()
        {
            // Arrange
            var garage = new Garage<IVehicle>(10);
            var car = new Car("ABC123", "Red", 4, 2000, "Gasoline");

            // Act
            garage.AddVehicle(car);

            // Assert
            Assert.Contains(car, garage.Vehicles);
        }

        [Fact]
        public void RemoveVehicle_Should_RemoveVehicleFromGarage()
        {
            // Arrange
            var garage = new Garage<IVehicle>(10);
            var car = new Car("ABC123", "Red", 4, 2000, "Gasoline");
            garage.AddVehicle(car);

            // Act
            garage.RemoveVehicle(car);

            // Assert
            Assert.DoesNotContain(car, garage.Vehicles);
        }
    }
}
