using E_USED.Data;
using E_USED.Dtos;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SellingUsedThings.Models.Entity;

namespace E_USED.Controllers
{
    
    public class ChatController : Controller
    {
		private readonly ApplicationDbContext _context;
		private readonly UserManager<AppUser> _userManager;
		public ChatController(ApplicationDbContext context, UserManager<AppUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}
		public IActionResult Index()
        {
			var currentUser = _userManager.GetUserAsync(User).Result;
			ViewBag.UsersId = _context.Users.Where(u => u.Id != currentUser.Id).ToList();
            ViewBag.UserNeme = currentUser.FirstName + " " + currentUser.LastName;

			return View();
        }

        [HttpGet]
        public IActionResult DisplayChat(string userId)
        {
            var currentUser = _userManager.GetUserAsync(User).Result;
            var otherUser = _context.Users.FirstOrDefault(u => u.Id == userId);


            var chat = _context.userMessages.Where(um => um.SenderId == userId && um.ReceiverId == currentUser.Id
                                                    || um.ReceiverId == userId && um.SenderId == currentUser.Id)
                                              .OrderBy(um => um.CreatedAt);

            var messages = chat.Select(ch => new MessageDto(ch.Message, ch.SenderId == currentUser.Id, ch.CreatedAt));

            var chatDto = new ChatDto
            {
                CurrentUserId = currentUser.Id,
                CurrentUserName = currentUser.FirstName + " " + currentUser.LastName,
                CurrentUserImg = currentUser.ImgPath,

                OtherUserId = otherUser.Id,
                OtherUserName = otherUser.FirstName + " " + otherUser.LastName,
                OtherUserImg = otherUser.ImgPath,
                OtherUserIsActive = otherUser.IsActive ?? false,

                Messages = messages.ToList(),
                MessageCount = messages.Count()


            };



            return View("UserChat", chatDto);
        }

        [HttpGet]
        public IActionResult DisplayGroupChat (string groupName)
        {
			var currentUser = _userManager.GetUserAsync(User).Result;

			var groupChatDto = new GroupChatDto
			{
				CurrentUserId = currentUser.Id,
				CurrentUserName = currentUser.FirstName + " " + currentUser.LastName,
				CurrentUserImg = currentUser.ImgPath,

                GroupName = groupName

			};

			return View("GroupChat", groupChatDto);
        }



    }
}
