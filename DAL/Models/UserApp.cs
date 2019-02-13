using SharedKernel.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
	public class UserApp
	{
		public long UserId { get; set; }
		public ApplicationUser User { get; set; }

		public long AppId { get; set; }
		public App App { get; set; }

		public bool IsSubscriber { get; set; }
	}
}
