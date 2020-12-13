using NeatFleetManager.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NeatFleetManager.Web
{
    public class CarViewModel
    {
        public int CarId { get; set; }
        public CarColor Color { get; set; }
        public CarCondition Condition { get; set; }
        [Range(100, 2000000)]
        public decimal Price { get; set; }
    }
}