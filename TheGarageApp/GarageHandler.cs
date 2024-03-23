using TheGarageApp.Models;
using TheGarageApp.Services;

namespace TheGarageApp
{
    public class GarageHandler
    {
        private Garage<IVehicle> garage;
        private IUI uI;
        public GarageHandler(Garage<IVehicle> garage, IUI ui)
        {
            this.garage = garage;
            this.uI = ui;
        }
        public void Start()
        {
            uI.Start();
        }

    }
}