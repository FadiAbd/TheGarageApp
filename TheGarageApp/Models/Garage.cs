using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGarageApp.Services;

namespace TheGarageApp.Models
{
    public class Garage<T> : IGarage<T> where T : IVehicle
    {
        // Array with capacity of 10
        private T[] vehicles = new T[10];

        // Keep track of the number of vehicles in the garage
        private int count = 0;

        public Garage(int capacity)
        {
            vehicles = new T[capacity];
            count = 0;
        }

        public void AddVehicle(T vehicle)
        {
            if (count < vehicles.Length)
            {
                vehicles[count++] = vehicle;
            }
            else
            {
                Console.WriteLine("The garage is full. Cannot add more vehicles");
            }
        }

        public void RemoveVehicle(T vehicle)
        {
            // Find the index of the vehicle in the array
            int index = Array.IndexOf(vehicles, vehicle);
            if (index >= 0)
            {
                // Shift the vehicles after the removed vehicle 
                Array.Copy(vehicles, index + 1, vehicles, index, count - index - 1);
                vehicles[count - 1] = default;// Set the last element to default value (null for reference types)
                count--;
                Console.WriteLine($"Current count of vehicles in the garage: {count}");
            }
            else
            {
                Console.WriteLine($"Vehicle with Register Number {vehicle.RegisterNumber} not found in the garage.");
            }
        }
        public IEnumerable<T> Vehicles => vehicles.Take(count);
    }


}
