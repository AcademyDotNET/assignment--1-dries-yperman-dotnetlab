using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeShop.Models.Domain.Products
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
    }
}
