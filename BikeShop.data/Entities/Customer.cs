namespace BikeShop.Data.Entities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FirstName { get; set; }

        public ICollection<ShoppingBag> ShoppingBags { get; set; } = new List<ShoppingBag>(); // Collection reference property
    }
}
