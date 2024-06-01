using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SellingUsedThings.Models.Entity
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ImgPath { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<Product>? Products { get; set; }
        public List<Chat>? Chats { get; set; }

    }
}
