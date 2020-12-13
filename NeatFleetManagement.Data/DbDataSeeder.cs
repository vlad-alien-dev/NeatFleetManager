using NeatFleetManagement.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatFleetManagement.Data
{
    public class DbDataSeeder : DropCreateDatabaseIfModelChanges<BaseDbContext>
    {
        protected override void Seed(BaseDbContext context)
        {
            GetCars().ForEach(c => context.Cars.Add(c));

            context.Commit();
        }
        private static List<Car> GetCars()
        {
            return new List<Car>
            {
                new Car {
                    Color=CarColor.Red,
                    Condition = CarCondition.New,
                    Price = 1800
                },
                new Car {
                    Color=CarColor.Red,
                    Condition = CarCondition.New,
                    Price = 1500
                },
                new Car {
                    Color=CarColor.Green,
                    Condition = CarCondition.New,
                    Price = 2000
                },
                new Car {
                    Color=CarColor.Yellow,
                    Condition = CarCondition.New,
                    Price = 3000
                },
                new Car {
                    Color=CarColor.Green,
                    Condition = CarCondition.Used,
                    Price = 1250
                },
                new Car {
                    Color=CarColor.Yellow,
                    Condition = CarCondition.Used,
                    Price = 600
                },
                new Car {
                    Color=CarColor.Red,
                    Condition = CarCondition.Used,
                    Price = 5000
                },
                new Car {
                    Color=CarColor.Red,
                    Condition = CarCondition.Used,
                    Price = 6000
                },
            };
        }
    }
}
