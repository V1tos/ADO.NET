using CA2___CodeFirst_EF__Shop_.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2___CodeFirst_EF__Shop_
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(): base("name=defaultConnection")
        {
            Database.SetInitializer(new ShopInitializer());
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
