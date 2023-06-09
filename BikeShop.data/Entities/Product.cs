﻿namespace BikeShop.Data.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }

        public ICollection<ShoppingItem> ShoppingItems { get; set; } = new List<ShoppingItem>(); // Reference property
    }
}
