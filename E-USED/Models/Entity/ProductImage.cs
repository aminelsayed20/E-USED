using E_USED.Repository;
using System.ComponentModel.DataAnnotations.Schema;

namespace SellingUsedThings.Models.Entity
{
    public class ProductImage : IaddID
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public Product Product { get; set; }
    }
}
