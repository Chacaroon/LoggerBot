using Microsoft.EntityFrameworkCore;
using SharedKernel.DAL.Interfaces;
using SharedKernel.DAL.Models;

namespace DAL.Repositories
{
	public class AppRepository : Repository<App>, IRepository<App>
	{
		public AppRepository(DbContext dbContext)
			: base(dbContext)
		{

		}
	}
}
