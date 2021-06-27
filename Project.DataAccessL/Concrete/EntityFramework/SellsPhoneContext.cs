using Project.EnitityL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccessL.Concrete.EntityFramework
{
    public class SellsPhoneContext:DbContext
    {
        public SellsPhoneContext()
            :base("DbSellsPhone")
        {
            
        }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PhoneImage> PhoneImages { get; set; }

    }
}
