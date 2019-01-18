using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.DAL.Models
{
	public class User : Entity
	{
		public long ChatId { get; set; }

		public IEnumerable<UserApp> UserApps { get; set; }
	}
}