using E_USED.Repository;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_USED.Models.Entity.Product
{
    public class ProductImage : IaddID
    {
        public int Id { get; set; }
        public string? ImagePath { get; set; }


        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;
    }
}
