using E_USED.Repository;

namespace SellingUsedThings.Models.Entity
{
    public class Chat : IaddID
    {
        public int Id { get; set; }
        public int User1Id { get; set; }
        public int User2Id { get; set; }
        public List<Message> Messages { get; set; }
        
    }
}
