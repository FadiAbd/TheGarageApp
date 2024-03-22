using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGarageApp.Models
{
    public class Car : Vehicle
    {
        public int CylinderVolume { get; }
        public string FuelType { get; }

        public Car(string registerNumber, string color, int wheelsNumber, int cylinderVolume, string fuelType)
            : base("Car", registerNumber, color, wheelsNumber)
        {
            CylinderVolume = cylinderVolume;
            FuelType = fuelType;
        }

        public override void Park() => Console.WriteLine($"The car with Register Number {RegisterNumber} is parked.");
    }
}
