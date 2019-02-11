using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.DAL.Models
{
	public interface IApp : IEntity
	{
		string Name { get; set; }

		IEnumerable<IExceptionInfo> Exceptions { get; set; }

		IEnumerable<IUserApp> UserApps { get; set; }
	}
}
