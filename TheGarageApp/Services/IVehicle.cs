using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGarageApp.Services
{
    internal interface IVehicle
    {
        string Type { get; }
        string RegisterNumber { get; }  
        string Color {  get; }
        int WheelsNumber { get; }

        void Park();
        void AddVehicle();
        void RemoveVehicle();
    }
}
