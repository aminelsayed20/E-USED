using E_USED.Data;
using E_USED.Models.Entity.Chat;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SellingUsedThings.Models.Entity;

namespace E_USED.Hubs
{
    [HubName("chatHub")]
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _context;
		private readonly UserManager<AppUser> _userManager;
		public ChatHub(ApplicationDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
		}

		public async Task CreateGroup(string user, string groupName)
		{

			await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

			await Clients.Others.SendAsync("NewGroup", user, groupName);
		}

		public async Task SendMessageToGroup(string userName, string userImg, string groupName, string message)
		{
			await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

			await Clients.OthersInGroup(groupName).SendAsync("ReceiveGroupMessage", userName, userImg, message);

		}

		public async Task JoinToGroup (string user, string groupName)
		{

			await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
			await Clients.OthersInGroup(groupName).SendAsync("NewMember",user);
		}


		public async Task SendMessage(string receiver, string sender, string message)
        {
			// handel unRead messages
/*			var userIsConnection = _context.ConnectionUsers.Any(cu=>cu.UserId == receiver);
			if (!userIsConnection) 
			{
			  var user = _context.Users.FirstOrDefault(u=>u.Id == receiver);
				  user.UnReadMessageCount++ ;
				  _context.SaveChanges();
			}*/

			// save message to db

			_context.userMessages.Add(new UserMessage(sender, receiver, message));
			_context.SaveChanges();

			

			var connectionIds = _context.ConnectionUsers.Where(c => c.UserId == receiver); 

			foreach (var conId in connectionIds) 
			{
				await Clients.Client(conId.ConnectionId).SendAsync("ReceiveMessage",	 message);

			}
            
            await Console.Out.WriteLineAsync(Context.ConnectionId);

        }



		public override async Task OnConnectedAsync()
		{
			// Add user to connections table
			var currentUserId = _userManager.GetUserId(Context.User);  // Retrieve the user ID
			var connectionId = Context.ConnectionId;

			// Add the new ConnectionUser record
			_context.ConnectionUsers.Add(new ConnectionUser (currentUserId,  connectionId));

			// Save changes to the database
			await _context.SaveChangesAsync();

			await base.OnConnectedAsync();
		}


		public override async Task OnDisconnectedAsync(Exception? exception)
		{
			var connectionId = Context.ConnectionId;

			var connectionUser =  _context.ConnectionUsers
			.Where(cu => cu.ConnectionId == connectionId);

			foreach (var con in connectionUser) 
			{ 
			if (con != null)
				_context.ConnectionUsers.Remove(con);
			
			}
			await _context.SaveChangesAsync();

			await base.OnDisconnectedAsync(exception);

		}



/*		public void CloseAllConnections()
		{
			_context.ConnectionUsers.Add(new ConnectionUser() { UserId = "ssss", ConnectionId = "dddd"});
			_context.SaveChanges();
		}*/

	}
	
}
