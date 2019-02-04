using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.DAL.Models
{
	public interface IUserApp
	{
		Guid UserId { get; set; }
		IUser User { get; set; }

		Guid AppId { get; set; }
		IApp App { get; set; }
	}
}
