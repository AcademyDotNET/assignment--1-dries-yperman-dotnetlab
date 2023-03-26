namespace BikeShop.Models
{
    public class ShoppingBagDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public CustomerDTO? Customer { get; set; }
        public ICollection<ShoppingItemDTO> Items { get; set; } = new List<ShoppingItemDTO>();
    }
}
