using E_USED.Repository;
using SellingUsedThings.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_USED.Models.Entity.Chat
{
    public class Message : IaddID
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;


        [ForeignKey("User")]
        public string SenderId { get; set; }
        public AppUser User { get; set; } = default!;


        [ForeignKey("Chat")]
        public int ChatId { get; set; }
        public Chat Chat { get; set; } = default!;

    }
}
