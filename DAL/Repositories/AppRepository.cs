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
					.ThenInclude(ua => ua.User)
				.Include(a => a.Exceptions);
		}

		public override IQueryable<App> GetAll()
		{
			return _baseQuery;
		}

		public override IQueryable<App> GetAll(Func<App, bool> predicate)
		{
			return _baseQuery.Where(predicate).AsQueryable();
		}

		public override App FindById(long id)
		{
			return _baseQuery.Where(a => a.Id == id).FirstOrDefault();
		}
	}
}
