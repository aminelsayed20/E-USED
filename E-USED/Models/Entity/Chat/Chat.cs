using E_USED.Repository.Interfaces;
using SellingUsedThings.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_USED.Models.Entity.Chat
{
    public class Chat : IaddID
    {
        public int Id { get; set; }


        public string? User1Id { get; set; }
        public AppUser User1 { get; set; } = default!; // sender


        public string? User2Id { get; set; }
        public AppUser User2 { get; set; } = default!; // receiver

        public ICollection<Message> Messages { get; set; } = new List<Message>();

    }
}
