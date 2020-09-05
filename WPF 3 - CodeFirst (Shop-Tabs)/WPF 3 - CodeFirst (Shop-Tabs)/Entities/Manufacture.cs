using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_3___CodeFirst__Shop_Tabs_.Entities
{
    public class Manufacture
    {
        public Manufacture()
        {
            Products = new List<Product>();
            Adresses = new List<Adress>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Phone { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Adress> Adresses { get; set; }
    }
}
