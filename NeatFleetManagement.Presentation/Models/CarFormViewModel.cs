using NeatFleetManagement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NeatFleetManagement.Presentation.Models
{
    public class CarFormViewModel
    {
        public int CarId { get; set; }
        public CarColor Color { get; set; }
        public CarCondition Condition { get; set; }
        [Range(100, 2000000)]
        public decimal Price { get; set; }
    }
}