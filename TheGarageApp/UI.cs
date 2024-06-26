﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGarageApp.Models;
using TheGarageApp.Services;

namespace TheGarageApp
{
    public class UI : IUI
    {
        private readonly Garage<IVehicle> garage;

        public UI(Garage<IVehicle> garage)
        {
            this.garage = garage;
        }

        public void Start()
        {

            while (true)
            {
                
                Console.WriteLine("1. Add a vehicle");
                Console.WriteLine("2. Remove a vehicle");
                Console.WriteLine("3. List all vehicles in the garage");
                Console.WriteLine("4. Search for a vehicle");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddVehicle();
                        break;
                    case "2":
                        RemoveVehicle();
                        break;
                    case "3":
                        ListVehicles();
                        break;
                    case "4":
                        SearchVehicle();
                        break;
                    case "5":
                        Console.WriteLine("Exiting the application...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }


        private void AddVehicle()
        {
            Console.WriteLine("Choose the type of vehicle to add:");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Bus");
            Console.WriteLine("3. Airplane");
            Console.WriteLine("4. Boat");
            Console.WriteLine("5. Motorcycle");
            Console.Write("Enter your choice: ");

            string vehicleType = Console.ReadLine();
            Console.WriteLine();

            switch (vehicleType)
            {
                case "1":
                    AddVehicle(CreateCar());
                    break;
                case "2":
                    AddVehicle(CreateBus());
                    break;
                case "3":
                    AddVehicle(CreateAirplane());
                    break;
                case "4":
                    AddVehicle(CreateBoat());
                    break;
                case "5":
                    AddVehicle(CreateMotorcycle());
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        }

        private void AddVehicle(IVehicle vehicleToAdd)
        {
            if (vehicleToAdd != null)
            {
                garage.AddVehicle(vehicleToAdd);
                Console.WriteLine($"Added {vehicleToAdd.Type} with Register Number {vehicleToAdd.RegisterNumber} to the garage.");
            }
            else
            {
                Console.WriteLine("Vehicle creation failed. Please ensure correct input format.");
            }
        }

        private void SearchVehicle()
        {
            Console.WriteLine("Search for a vehicle by entering search criteria:");
            

            Console.Write("Enter Register Number (leave blank to skip): ");
            string registerNumber = Console.ReadLine();

            Console.Write("Enter Color (leave blank to skip): ");
            string color = Console.ReadLine();

            Console.Write("Enter Wheels Number (leave blank to skip): ");
            string wheelsNumberStr = Console.ReadLine();
            int? wheelsNumber = string.IsNullOrWhiteSpace(wheelsNumberStr) ? (int?)null : int.Parse(wheelsNumberStr);

            Console.Write("Enter Type (leave blank to skip): ");
            string type = Console.ReadLine();

            var filteredVehicles = garage.Vehicles.Where(v =>
                (string.IsNullOrWhiteSpace(registerNumber) || v.RegisterNumber.Equals(registerNumber, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(color) || v.Color.Equals(color, StringComparison.OrdinalIgnoreCase)) &&
                (!wheelsNumber.HasValue || v.WheelsNumber == wheelsNumber.Value) &&
                (string.IsNullOrWhiteSpace(type) || v.Type.Equals(type, StringComparison.OrdinalIgnoreCase)));

            if (filteredVehicles.Any())
            {
                Console.WriteLine($"Found {filteredVehicles.Count()} vehicles matching the search criteria:");
                Console.WriteLine("----------------------------------------------------");
                foreach (var vehicle in filteredVehicles)
                {
                    DisplayVehicleDetails(vehicle);
                }
            }
            else
            {
                Console.WriteLine("No vehicles found matching the search criteria.");
            }
        }

        private void DisplayVehicleDetails(IVehicle vehicle)
        {
            switch (vehicle)
            {
                case Car car:
                    Console.WriteLine($"Type: {car.Type} , Register number: {car.RegisterNumber}");
                    break;
                case Bus bus:
                    Console.WriteLine($"Type: {bus.Type} , Register number: {bus.RegisterNumber}");
                    break;
                case AirPlane airplane:
                    Console.WriteLine($"Type: {airplane.Type} , Register number: {airplane.RegisterNumber}");
                    break;
                case Boat boat:
                    Console.WriteLine($"Type: {boat.Type} , Register number: {boat.RegisterNumber}");
                    break;
                case Motorcycle motorcycle:
                    Console.WriteLine($"Type: {motorcycle.Type} , Register number: {motorcycle.RegisterNumber}");
                    break;
                default:
                    Console.WriteLine("Vehicle type not recognized.");
                    break;
            }
        }

        private void RemoveVehicle()
        {
            string registerNumber = GetPropertyValue("Register Number of the vehicle to remove");
            var vehicle = garage.Vehicles.FirstOrDefault(v => v.RegisterNumber.Equals(registerNumber, StringComparison.OrdinalIgnoreCase));
            if (vehicle != null)
            {
                garage.RemoveVehicle(vehicle);
                Console.WriteLine($"Vehicle with Register Number {registerNumber} removed from the garage.");
            }
            else
            {
                Console.WriteLine($"Vehicle with Register Number {registerNumber} not found in the garage.");
            }
        }

        private void ListVehicles()
        {
            int vehicleCount = garage.Vehicles.Count();
            Console.WriteLine($"List of vehicles in the garage: {vehicleCount}");
            Console.WriteLine("-----------------------------------------------");
            foreach (var vehicle in garage.Vehicles)
            {
                Console.WriteLine($"Type: {vehicle.Type}\nRegister Number: {vehicle.RegisterNumber}\nColor: {vehicle.Color}\nWheels Number: {vehicle.WheelsNumber}");

                if (vehicle is Car car)
                    Console.WriteLine($"Cylinder Volume: {car.CylinderVolume}\nFuel Type: {car.FuelType}");
                else if (vehicle is Bus bus)
                    Console.WriteLine($"Number of Seats: {bus.NumberOfSeats}\nFuel Type: {bus.FuelType}");
                else if (vehicle is AirPlane airplane)
                    Console.WriteLine($"Number of Engines: {airplane.NumberOfEngines}\nCylinder Volume: {airplane.CylinderVolume}\nFuel Type: {airplane.FuelType}");
                else if (vehicle is Boat boat)
                    Console.WriteLine($"Number of Engines: {boat.NumberOfEngines}\nFuel Type: {boat.FuelType}\nLength: {boat.Length}");
                else if (vehicle is Motorcycle motorcycle)
                    Console.WriteLine($"Cylinder Volume: {motorcycle.CylinderVolume}\nFuel Type: {motorcycle.FuelType}");

                Console.WriteLine();
            }
        }

        private IVehicle CreateCar()
        {
            return new Car(
                GetPropertyValue("Register Number"),
                GetPropertyValue("Color"),
                GetNumericPropertyValue("Wheels Number"),
                GetNumericPropertyValue("Cylinder Volume"),
                GetPropertyValue("Fuel Type")
            );
        }

        private IVehicle CreateBus()
        {
            return new Bus(
                GetPropertyValue("Register Number"),
                GetPropertyValue("Color"),
                GetNumericPropertyValue("Wheels Number"),
                 GetNumericPropertyValue("Number of Seats"),
                GetPropertyValue("Fuel Type")
            );
        }

        private IVehicle CreateAirplane()
        {
            return new AirPlane(
                GetPropertyValue("Register Number"),
                GetPropertyValue("Color"),
                GetNumericPropertyValue("Wheels Number"),
                GetNumericPropertyValue("Number of Engines"),
                GetNumericPropertyValue("Cylinder Volume"),
                GetPropertyValue("Fuel Type")
            );
        }


        private IVehicle CreateBoat()
        {
            return new Boat(
                GetPropertyValue("Register Number"),
                GetPropertyValue("Color"),
                GetNumericPropertyValue("Wheels Number"),
                GetNumericPropertyValue("Number of Engines"),
                GetPropertyValue("Fuel Type"),
                GetDoublePropertyValue("Length")
            );
        }

        private IVehicle CreateMotorcycle()
        {
            return new Motorcycle(
                GetPropertyValue("Register Number"),
                GetPropertyValue("Color"),
                GetNumericPropertyValue("Wheels Number"),
                GetNumericPropertyValue("Cylinder Volume"),
                GetPropertyValue("Fuel Type")
            );
        }

        private string GetPropertyValue(string propertyName)
        {
            Console.Write($"Enter {propertyName}: ");
            return Console.ReadLine();
        }

        private int GetNumericPropertyValue(string propertyName)
        {
            Console.Write($"Enter {propertyName}: ");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                return -1; // Return a default value or an indicator of error
            }
        }

        private double GetDoublePropertyValue(string propertyName)
        {
            Console.Write($"Enter {propertyName}: ");
            if (double.TryParse(Console.ReadLine(), out double result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid double.");
                return -1; // Return a default value or an indicator of error
            }
        }

    }
}
