using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DataAccess.EntityFramework
{
    public class EFDbContext : DbContext
    {

        public Database Database { get { return base.Database; } }

        public EFDbContext(string conectionString)
            : base(conectionString)
        {
            
        }
    }

    public class EFDbSet<T> : DbSet<T> where T : class
    {
 
    }
}
