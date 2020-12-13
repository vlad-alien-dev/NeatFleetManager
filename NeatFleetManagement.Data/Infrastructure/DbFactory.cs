using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatFleetManagement.Data
{
    public class DbFactory : Disposable, IDbFactory
    {
        BaseDbContext dbContext;

        public BaseDbContext Init()
        {
            return dbContext ?? (dbContext = new BaseDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
