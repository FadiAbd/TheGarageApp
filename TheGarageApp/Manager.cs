using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGarageApp.Services;

namespace TheGarageApp
{
    internal class Manager
    {
        private readonly IUI ui;
        private readonly GarageHandler garageHandler;

        public Manager(IUI ui, GarageHandler garageHandler) 
        {
            this.ui = ui;
            this.garageHandler = garageHandler;
        }   
        
        public void Start()
        {
            garageHandler.Start();
            ui.Start();
        }
    }
}
