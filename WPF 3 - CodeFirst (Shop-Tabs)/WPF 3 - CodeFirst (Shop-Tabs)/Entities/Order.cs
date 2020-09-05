using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_3___CodeFirst__Shop_Tabs_.Entities
{
    public class Order
    {
        public Order()
        {
            Products = new List<Product>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public double TotalPrice { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual Client Client { get; set; }
        public virtual Adress Adress { get; set; }

    }
}
