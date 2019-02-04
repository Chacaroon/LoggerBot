using Microsoft.EntityFrameworkCore;
using SharedKernel.DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
	public class AppRepository : Repository<App>, IRepository<App>
	{
		public AppRepository(ApplicationContext dbContext)
			: base(dbContext)
		{

		}
	}
}
