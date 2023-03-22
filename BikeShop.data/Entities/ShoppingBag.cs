namespace BikeShop.Data.Entities
{
    public class ShoppingBag : IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }


        public int CustomerId { get; set; }
        public Customer? Customer { get; set; } // Navigation property
        public ICollection<ShoppingItem> Items { get; set; } = new List<ShoppingItem>(); // Collection navigation property
    }
}
