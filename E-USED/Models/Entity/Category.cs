using E_USED.Repository.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_USED.Models.Entity.Product
{
    public class Category : IaddID
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Product>? Products { get; set; }= new List<Product>();
    }
}
