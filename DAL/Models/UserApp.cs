using SharedKernel.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
	public class UserApp
	{
		public Guid UserId { get; set; }
		public User User { get; set; }

		public Guid AppId { get; set; }
		public App App { get; set; }
	}
}
