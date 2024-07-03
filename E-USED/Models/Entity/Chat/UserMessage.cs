namespace E_USED.Models.Entity.Chat
{
	public class UserMessage
	{ 
		public UserMessage() { }
		public UserMessage(string senderId, string receiverId, string message) 
		{
			this.SenderId = senderId;
			this.ReceiverId = receiverId;
			this.Message = message;
		}
		public int Id { get; set; }
		public string SenderId { get; set; }
		public string ReceiverId { get; set;}
		public string? Message { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
	}
}
