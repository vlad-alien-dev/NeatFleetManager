using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatFleetManager.Data
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext() : base("CarFleetManagement") { }

        public DbSet<Car> Cars { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CarConfig());
        }
    }
}
