using System;

namespace ProductMVC.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Customer { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
