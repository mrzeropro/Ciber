using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Ciber.Models
{
    public partial class Product
    {
        public Product()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public double? Price { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
