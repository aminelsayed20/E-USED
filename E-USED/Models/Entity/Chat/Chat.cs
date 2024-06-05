using E_USED.Repository;
using SellingUsedThings.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_USED.Models.Entity.Chat
{
    public class Chat : IaddID
    {
        public int Id { get; set; }

        [ForeignKey("User1")]
        public string User1Id { get; set; }
        public AppUser User1 { get; set; } = default!;

        [ForeignKey("User2")]
        public string User2Id { get; set; }
        public AppUser User2 { get; set; } = default!;

        public ICollection<Message> Messages { get; set; } = new List<Message>();

    }
}
