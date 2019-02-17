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

		public IEnumerable<UserLogger> UserLoggers { get; set; }

		public ChatState ChatState { get; set; }

		public ApplicationUser(long chatId)
		{
			UserLoggers = new List<UserLogger>();
			ChatId = chatId;
			ChatState = new ChatState();
		}

		public void AddLogger(Logger logger, bool isSubscriber = default)
		{
			UserLoggers = UserLoggers.Append(
				new UserLogger()
				{
					UserId = Id,
					Logger = logger,
					IsSubscriber = isSubscriber
				}).ToList();
		}
	}
}