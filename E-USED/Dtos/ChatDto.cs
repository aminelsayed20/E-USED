using Humanizer.Localisation.DateToOrdinalWords;

namespace E_USED.Dtos
{
	public class ChatDto
	{
		public string CurrentUserId { get; set; }
		public string CurrentUserName { get; set; }
		public string CurrentUserImg {  get; set; }


		public string OtherUserId { get; set;}
		public string OtherUserName { get; set; }
		public string OtherUserImg { get; set; }
		public bool OtherUserIsActive { get; set; }

		public List <MessageDto> Messages { get; set;} = new List<MessageDto>();

		public int MessageCount { get; set; } = 0;
	}
}
