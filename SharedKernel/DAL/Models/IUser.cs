using System.Collections.Generic;

namespace SharedKernel.DAL.Models
{
	public interface IUser : IEntity
	{
		long ChatId { get; set; }

		IEnumerable<IUserApp> UserApps { get; set; }
	}
}