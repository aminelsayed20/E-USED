using E_USED.Repository;

namespace SellingUsedThings.Models.Entity
{
    public class Message : IaddID
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int SenderId { get; set; }
        public Chat Chat { get; set; }

    }
}
