using E_USED.Models.Entity.Product;
using SellingUsedThings.Models.Entity;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace E_USED.Dtos
{
    public class CreateProductViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "You Should put a Price")]
        public decimal? Price { get; set; }
        public string? Location { get; set; }

        [Required(ErrorMessage = "You Should choose a Category")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "You Should choose a City")]
        public int? CityId { get; set; }

        public ICollection<IFormFile> Images { get; set; } = new List<IFormFile>();

    }
}
