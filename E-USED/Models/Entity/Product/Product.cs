using E_USED.Models.Entity;
using E_USED.Repository.Interfaces;
using SellingUsedThings.Enum;
using SellingUsedThings.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_USED.Models.Entity.Product
{
    public class Product : IaddID
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? Location { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;


        public int? CategoryId { get; set; }
        public Category Category { get; set; } = default!;


        public int? CityId { get; set; }
        public City City { get; set; } = default!;


        public string? UserId { get; set; }
        public AppUser User { get; set; } = default!;

        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
    }
}
