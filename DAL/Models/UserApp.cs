using SharedKernel.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
	public class UserLogger
	{
		public long UserId { get; set; }
		public ApplicationUser User { get; set; }

		public long LoggerId { get; set; }
		public Logger Logger { get; set; }

		public bool IsSubscriber { get; set; }
	}
}
