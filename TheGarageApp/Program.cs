using TheGarageApp.Models;
using TheGarageApp.Services;

namespace TheGarageApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var garage = new Garage<IVehicle>(10);
            var ui = new UI(garage);
            var garageHandler = new GarageHandler(garage, ui);
            var manager = new Manager(ui, garageHandler);

            manager.Start();
        }
    }
}
