namespace BikeShop.Models
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FirstName { get; set; }
        public ICollection<ShoppingBagDTO> ShoppingBags { get; set; } = new List<ShoppingBagDTO>();
    }
}
