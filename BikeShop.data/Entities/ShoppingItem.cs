namespace BikeShop.Data.Entities
{
    public class ShoppingItem : IEntity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }


        public int ProductId { get; set; }
        public Product? Product { get; set; } // Navigation property
        public int ShoppingBagId { get; set; }
        public ShoppingBag? ShoppingBag { get; set; } // Navigation property
    }
}
