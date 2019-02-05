﻿using SharedKernel.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
	public class App : Entity
	{
		public string Name { get; set; }
		public Guid PublicToken { get; set; }
		public IEnumerable<ExceptionInfo> Exceptions { get; set; }
		public IEnumerable<UserApp> UserApps { get; set; }

		public App()
		{
			PublicToken = Guid.NewGuid();
		}

		public App(string name)
			: this()
		{
			Name = name;
		}
	}
}
