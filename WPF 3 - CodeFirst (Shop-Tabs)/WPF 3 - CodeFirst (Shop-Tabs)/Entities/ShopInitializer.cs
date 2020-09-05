using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_3___CodeFirst__Shop_Tabs_.Entities
{
    public class ShopInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var clients = new Client[] {
                                            new Client { Name = "Bill Gates" },
                                            new Client { Name = "Jack Sparrow" },
                                            new Client { Name = "Victor Kyslyi" },
                                            new Client { Name = "Joe Gomes" },};

            var categories = new Category[] {
                                            new Category { Name = "Books" },
                                            new Category { Name = "Food" },
                                            new Category { Name = "Alcohol" },
                                            new Category { Name = "PC" },};

            var manufactures = new Manufacture[] {
                                            new Manufacture { Name = "Yakaboo", Phone = 1334567, },
                                            new Manufacture { Name = "Biola", Phone = 1234388 },
                                            new Manufacture { Name = "Obolon", Phone = 1344432 },
                                            new Manufacture { Name = "Acer", Phone = 1364777 }, };


            var products = new Product[] {
                                            new Product { Name = "Clean Code", Price=300},
                                            new Product { Name = "Fruit juice", Price=30},
                                            new Product { Name = "Beer", Price=70},
                                            new Product { Name = "NoteBook", Price=3000}, };

            var adresses = new Adress[] {
                                          new Adress {Country="Ukraine", City = "Rivne", Street = "Chornovil", Building = 1 },
                                          new Adress {Country="Ukraine", City = "Lviv", Street = "Shevchenko", Building = 3 },
                                          new Adress {Country="Ukraine", City = "Kyiv", Street = "Khreschatyk", Building = 5 },
                                          new Adress {Country="Ukraine", City = "Lutsk", Street = "Danylo", Building = 6 },
                                          new Adress {Country="Ukraine", City = "Kharkiv", Street = "Metalist", Building = 7 },
                                          new Adress {Country="Ukraine", City = "Zhytomyr", Street = "Golovna", Building = 3 },
                                          new Adress {Country="Ukraine", City = "Odessa", Street = "Potemkin", Building = 5 },
                                          new Adress {Country="Ukraine", City = "Ternopil", Street = "Ruska", Building = 7 }, };

            var orders = new Order[] {
                                            new Order { Name="Books" , Date = new DateTime(2020, 5, 25) },
                                            new Order { Name = "Food", Date = new DateTime(2020, 3, 15)},
                                            new Order { Name = "PC", Date = new DateTime(2020, 7, 21)},
                                            new Order { Name = "Alcohol", Date = new DateTime(2020, 8, 6)}, };


            context.Clients.AddRange(clients);
            context.Categories.AddRange(categories);
            context.Manufactures.AddRange(manufactures);
            context.Products.AddRange(products);
            context.Adresses.AddRange(adresses);
            context.Orders.AddRange(orders);
            context.SaveChanges();

            context.Categories.FirstOrDefault(x => x.Name == "Food").Products.Add(context.Products.FirstOrDefault(x => x.Name == "Fruit juice"));
            context.Categories.FirstOrDefault(x => x.Name == "Books").Products.Add(context.Products.FirstOrDefault(x => x.Name == "Clean Code"));
            context.Categories.FirstOrDefault(x => x.Name == "Alcohol").Products.Add(context.Products.FirstOrDefault(x => x.Name == "Beer"));
            context.Categories.FirstOrDefault(x => x.Name == "PC").Products.Add(context.Products.FirstOrDefault(x => x.Name == "NoteBook"));

            context.Manufactures.FirstOrDefault(x => x.Name == "Yakaboo").Adresses.Add(context.Adresses.FirstOrDefault(x => x.City == "Rivne"));
            context.Manufactures.FirstOrDefault(x => x.Name == "Biola").Adresses.Add(context.Adresses.FirstOrDefault(x => x.City == "Ternopil"));
            context.Manufactures.FirstOrDefault(x => x.Name == "Obolon").Adresses.Add(context.Adresses.FirstOrDefault(x => x.City == "Lviv"));
            context.Manufactures.FirstOrDefault(x => x.Name == "Acer").Adresses.Add(context.Adresses.FirstOrDefault(x => x.City == "Kyiv"));

            context.Adresses.FirstOrDefault(x => x.City == "Lutsk").Orders.Add(context.Orders.FirstOrDefault(x => x.Name == "Alcohol"));
            context.Adresses.FirstOrDefault(x => x.City == "Kharkiv").Orders.Add(context.Orders.FirstOrDefault(x => x.Name == "Books"));
            context.Adresses.FirstOrDefault(x => x.City == "Zhytomyr").Orders.Add(context.Orders.FirstOrDefault(x => x.Name == "PC"));
            context.Adresses.FirstOrDefault(x => x.City == "Odessa").Orders.Add(context.Orders.FirstOrDefault(x => x.Name == "Food"));

            context.Orders.FirstOrDefault(x => x.Name == "Alcohol").Products.Add(context.Products.FirstOrDefault(x => x.Name == "Beer"));
            context.Orders.FirstOrDefault(x => x.Name == "Books").Products.Add(context.Products.FirstOrDefault(x => x.Name == "Clean Code"));
            context.Orders.FirstOrDefault(x => x.Name == "PC").Products.Add(context.Products.FirstOrDefault(x => x.Name == "NoteBook"));
            context.Orders.FirstOrDefault(x => x.Name == "Food").Products.Add(context.Products.FirstOrDefault(x => x.Name == "Fruit juice"));



            context.Clients.FirstOrDefault(x => x.Name == "Bill Gates").Orders.Add(context.Orders.FirstOrDefault(x => x.Name == "Alcohol"));
            context.Clients.FirstOrDefault(x => x.Name == "Jack Sparrow").Orders.Add(context.Orders.FirstOrDefault(x => x.Name == "Books"));
            context.Clients.FirstOrDefault(x => x.Name == "Victor Kyslyi").Orders.Add(context.Orders.FirstOrDefault(x => x.Name == "PC"));
            context.Clients.FirstOrDefault(x => x.Name == "Joe Gomes").Orders.Add(context.Orders.FirstOrDefault(x => x.Name == "Food"));





            context.SaveChanges();

            base.Seed(context);
        }
    }
}

