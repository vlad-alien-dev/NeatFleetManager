using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatFleetManagement.Data
{
    public class CarConfig : EntityTypeConfiguration<Car>
    {
        public CarConfig()
        {
            ToTable("Cars");
            Property(g => g.Color).IsRequired();
            Property(g => g.Condition).IsRequired();
            Property(g => g.Price).IsRequired().HasPrecision(8,2);
        }
    }
}
