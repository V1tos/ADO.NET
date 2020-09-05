using CA2___CodeFirst_EF__Shop_.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2___CodeFirst_EF__Shop_
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationContext context = new ApplicationContext();




            //foreach (var item in context.Categories)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //foreach (var item in context.Clients)
            //{
            //    Console.WriteLine(item.Name);
            //}
            //foreach (var item in context.Products.Include(x => x.Category))
            //{
            //    Console.WriteLine($"{item.Name} - {item.Category.Name}");
            //}
            //foreach (var item in context.Manufactures)
            //{
            //    Console.WriteLine($"{item.Name}");
            //}

            foreach (var item in context.Orders.Include(x=>x.Adress).Include(x=>x.Client).Include(x=>x.Products))
            {
                Console.WriteLine($"{item.Name} - {item.Client.Name} - {item.Adress.ToString()} - {item.Date.ToString()}");
                Console.WriteLine("Products: ");
                foreach (var item1 in item.Products)
                {
                    Console.WriteLine($"{item1.Name}");
                }
              
            }
           
        }
    }
}
