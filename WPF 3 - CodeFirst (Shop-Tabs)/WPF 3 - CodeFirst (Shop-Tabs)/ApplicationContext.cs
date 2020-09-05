using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_3___CodeFirst__Shop_Tabs_.Entities;

namespace WPF_3___CodeFirst__Shop_Tabs_
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("name=defaultConnection")
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
