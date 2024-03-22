using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGarageApp.Models
{
    public class AirPlane : Vehicle
    {
        public int NumberOfEngines { get; set; }
       
        public int CylinderVolume { get; }
        public string FuelType { get; }

        public AirPlane(string registerNumber, string color, int wheelsNumber, int numberOfEngines, int cylinderVolume, string fuelType)
            : base("Airplane", registerNumber, color, wheelsNumber)
        {
            NumberOfEngines = numberOfEngines;
            CylinderVolume = cylinderVolume;
            FuelType = fuelType;
        }

        public override void Park() => Console.WriteLine($"Airplane with Register Number {RegisterNumber} is parked.");
    }
}
