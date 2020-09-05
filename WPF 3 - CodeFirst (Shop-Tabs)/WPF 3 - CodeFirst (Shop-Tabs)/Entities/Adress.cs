﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_3___CodeFirst__Shop_Tabs_.Entities
{
    public class Adress
    {
        public Adress()
        {
            Orders = new List<Order>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int Building { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual Manufacture Manufacture { get; set; }

        public override string ToString()
        {
            return $"{Country}, {City} city, {Street} street, building {Building}";
        }
    }
}
