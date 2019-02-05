using Microsoft.EntityFrameworkCore;
using SharedKernel.DAL.Interfaces;
using DAL.Models;
using System.Linq;
using System.Collections.Generic;
using System;

namespace DAL.Repositories
{
	public class AppRepository : Repository<App>, IRepository<App>
	{
		private IQueryable<App> _baseQuery;

		public AppRepository(ApplicationContext dbContext)
			: base(dbContext)
		{
			_baseQuery = dbContext.Set<App>()
				.Include(a => a.UserApps)
					.ThenInclude(ua => ua.User);
		}

		public override IEnumerable<App> GetAll()
		{
			return _baseQuery;
		}

		public override IEnumerable<App> GetAll(Func<App, bool> predicate)
		{
			return _baseQuery.Where(predicate);
		}

		public override App FindById(long id)
		{
			return _baseQuery.Where(a => a.Id == id).FirstOrDefault();
		}
	}
}
