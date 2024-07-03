using E_USED.Repository.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_USED.Models.Entity.Product
{
    public class ProductImage : IaddID
    {
        public ProductImage(string? ImagePath, int ProductId)
        {
            this.ImagePath = ImagePath;
            this.ProductId = (int)ProductId;
        }
        public int Id { get; set; }
        public string? ImagePath { get; set; }


        public int ProductId { get; set; } 
        public Product Product { get; set; } = default!;
    }
}
