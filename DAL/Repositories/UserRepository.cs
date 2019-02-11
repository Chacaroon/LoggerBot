using SharedKernel.DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class UserRepository : Repository<ApplicationUser>, IRepository<ApplicationUser>
	{
		private IQueryable<ApplicationUser> _baseQuery;

		public UserRepository(ApplicationContext dbContext)
			: base(dbContext)
		{
			_baseQuery = dbContext.Set<ApplicationUser>()
				.Include(u => u.UserApps)
					.ThenInclude(ua => ua.App)
				.Include(u => u.ChatState);
		}

		public override IQueryable<ApplicationUser> GetAll()
		{
			return _baseQuery;
		}

		public override IQueryable<ApplicationUser> GetAll(Func<ApplicationUser, bool> predicate)
		{
			return _baseQuery.Where(predicate).AsQueryable();
		}

		public override ApplicationUser FindById(long id)
		{
			return _baseQuery.Where(u => u.Id == id).FirstOrDefault();
		}
	}
}
