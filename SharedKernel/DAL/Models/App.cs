using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.DAL.Models
{
	public class App : Entity
	{
		public string Name { get; set; }

		public IEnumerable<ExceptionInfo> Exceptions { get; set; }

		public IEnumerable<UserApp> UserApps { get; set; }
	}
}
