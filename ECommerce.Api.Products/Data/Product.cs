using System;

namespace ECommerce.Api.Products.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public int Inventory { get; set; }
    }
}