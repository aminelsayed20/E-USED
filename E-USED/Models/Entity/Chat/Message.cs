using E_USED.Repository.Interfaces;
using SellingUsedThings.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_USED.Models.Entity.Chat
{
    public class Message : IaddID
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;


        public string? SenderId { get; set; }
        public AppUser Sender { get; set; } = default!;


        public int ChatId { get; set; }
        public Chat Chat { get; set; } = default!;

    }
}
