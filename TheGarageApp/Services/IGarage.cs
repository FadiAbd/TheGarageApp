using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGarageApp.Services
{
    public interface IGarage<T>
    {
        void AddVehicle(T vehicle);
        void RemoveVehicle(T vehicle);
        IEnumerable<T> Vehicles { get; }
    }
}
