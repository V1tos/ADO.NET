using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_3___CodeFirst__Shop_Tabs_.Entities
{
    public class Product
    {
        public Product()
        {

        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }

        public virtual Category Category { get; set; }
        public virtual Order Order { get; set; }
        public virtual Manufacture Manufacture { get; set; }

    }
}
