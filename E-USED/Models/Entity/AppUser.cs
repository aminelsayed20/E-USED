using E_USED.Models.Entity;
using E_USED.Models.Entity.Chat;
using E_USED.Models.Entity.Product;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SellingUsedThings.Models.Entity
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ImgPath { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; } = default!;

        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<Chat> Chats { get; set; } = new List<Chat>();

    }
}
