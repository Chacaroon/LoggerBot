using SharedKernel.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Models
{
	public class ApplicationUser : Entity
	{
		public long ChatId { get; set; }

		public IEnumerable<UserApp> UserApps { get; set; }

		public ChatState ChatState { get; set; }

		public ApplicationUser(long chatId)
		{
			UserApps = new List<UserApp>();
			ChatId = chatId;
			ChatState = new ChatState();
		}

		public void AddApp(App app, bool isSubscriber = default)
		{
			UserApps = UserApps.Append(
				new UserApp()
				{
					UserId = Id,
					App = app,
					IsSubscriber = isSubscriber
				}).ToList();
		}
	}
}