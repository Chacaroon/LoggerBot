﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.DAL.Models
{
	public class UserApp
	{
		public Guid UserId { get; set; }
		public User User { get; set; }

		public Guid AppId { get; set; }
		public App App { get; set; }
	}
}
