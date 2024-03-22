using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGarageApp.Models
{
    public class Boat : Vehicle
    {
        public int NumberOfEngines { get; }
        public string FuelType { get; }
        public double Length { get; }

        public Boat(string registerNumber, string color, int wheelsNumber, int numberOfEngines, string fuelType, double length)
            : base("Boat", registerNumber, color, wheelsNumber)
        {
            NumberOfEngines = numberOfEngines;
            FuelType = fuelType;
            Length = length;
        }

        public override void Park() => Console.WriteLine($"The boat with Register Number {RegisterNumber} is parked.");
    }
}
