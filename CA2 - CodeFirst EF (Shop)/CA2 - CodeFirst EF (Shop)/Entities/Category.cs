using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2___CodeFirst_EF__Shop_.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection <Product> Products { get; set; }
    }
}
