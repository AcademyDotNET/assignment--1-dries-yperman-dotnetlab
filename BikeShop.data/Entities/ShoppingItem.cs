namespace BikeShop.Data.Entities
{
    public class ShoppingItem : IEntity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }


        public Product Product { get; set; } = new Product(); // Navigation property
    }
}
