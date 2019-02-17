using Microsoft.EntityFrameworkCore;
using SharedKernel.DAL.Interfaces;
using DAL.Models;
using System.Linq;
using System.Collections.Generic;
using System;

namespace DAL.Repositories
{
	public class LoggerRepository : Repository<Logger>, IRepository<Logger>
	{
		private IQueryable<Logger> _baseQuery;

		public LoggerRepository(ApplicationContext dbContext)
			: base(dbContext)
		{
			_baseQuery = dbContext.Set<Logger>()
				.Include(a => a.UserLoggers)
					.ThenInclude(ua => ua.User)
				.Include(a => a.Exceptions);
		}

		public override IQueryable<Logger> GetAll()
		{
			return _baseQuery;
		}

		public override IQueryable<Logger> GetAll(Func<Logger, bool> predicate)
		{
			return _baseQuery.Where(predicate).AsQueryable();
		}

		public override Logger FindById(long id)
		{
			return _baseQuery.Where(a => a.Id == id).FirstOrDefault();
		}
	}
}
