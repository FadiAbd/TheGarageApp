using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TheGarageApp.Services;

namespace TheGarageApp.Models
{
    public class Vehicle : IVehicle
    {
        private string type;
        private string registerNumber;
        private string color;
        private int wheelsNumber;

        public string Type
        {
            get => type;
            protected set => type = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string RegisterNumber
        {
            get => registerNumber;
            protected set
            {
                if (!IsValidRegisterNumber(value))
                {
                    Console.WriteLine("Error: Invalid register number format.");
                }
                registerNumber = value.ToUpper();
            }
        }

        public string Color
        {
            get => color;
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine($"Error: Color cannot be null or empty.");
                }
                color = value;
            }
        }

        public int WheelsNumber
        {
            get => wheelsNumber;
            protected set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Error: Wheels number must be positive.");
                }
                wheelsNumber = value;
            }
        }

        protected Vehicle(string type, string registerNumber, string color, int wheelsNumber)
        {
            Type = type;
            RegisterNumber = registerNumber;
            Color = color;
            WheelsNumber = wheelsNumber;
        }

        private bool IsValidRegisterNumber(string value)
        {
            // Add your validation logic here
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            if (!Regex.IsMatch(value, @"^[a-zA-Z]{3}\d{3}$"))
            {
                return false;
            }
            return true;
        }

        public virtual void Park() => Console.WriteLine();
        public void AddVehicle() => Console.WriteLine();
        public void RemoveVehicle() => Console.WriteLine();
    }
}
