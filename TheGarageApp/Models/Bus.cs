using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGarageApp.Models
{
    public class Bus : Vehicle
    {
        public int NumberOfSeats { get; }
        public string FuelType { get; }

        public Bus(string registerNumber, string color, int wheelsNumber, int numberOfSeats, string fuelType)
           : base("Bus", registerNumber, color, wheelsNumber)
        {
            NumberOfSeats = numberOfSeats;
            FuelType = fuelType;
        }

        public override void Park() => Console.WriteLine($"The bus with Register Number {RegisterNumber} is parked.");
    }
}
