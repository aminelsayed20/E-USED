using E_USED.Models.Entity.Product;
using SellingUsedThings.Models.Entity;

namespace E_USED.Dtos
{
    public class ProductForListDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Location { get; set; }
        public string? City { get; set; }
        public string? Time { get; set; } 
        public string? ImagePath { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
