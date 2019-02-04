using SharedKernel.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
	public class User : Entity
	{
		public long ChatId { get; set; }

		public IEnumerable<UserApp> UserApps { get; set; }

		public User()
		{
			UserApps = new List<UserApp>();
		}

		public User(long chatId)
			: this()
		{
			ChatId = chatId;
		}
	}
}