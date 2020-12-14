using NeatFleetManagement.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeatFleetManagement.Presentation.Models
{
    public class InventoryViewModel
    {
        private IEnumerable<CarViewModel> cars;
        public InventoryViewModel(IEnumerable<CarViewModel> cars)
        {
            this.cars = cars;
        }

        public IEnumerable<CarViewModel> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }

    }
}