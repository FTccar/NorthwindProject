using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Concrete.EntityFramework
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext() :
            base("NorthwindContext")
        {
            //Database.Connection.ConnectionString = "Server=DESKTOP-1TVRRF4\\FERDI;Database=OnlineBlog;UID=sa;PWD=27412946634";
        }

        public DbSet<Product> Products { get; set; }
    }
}
