using Microsoft.EntityFrameworkCore;
using SharedKernel.DAL.Interfaces;
using SharedKernel.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
	public class UserRepository : Repository<User>, IRepository<User>
	{
		public UserRepository(DbContext dbContext)
			: base(dbContext)
		{

		}
	}
}
