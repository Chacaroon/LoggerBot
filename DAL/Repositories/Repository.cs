﻿using Microsoft.EntityFrameworkCore;
using SharedKernel.DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
	public class Repository<T> : IRepository<T> where T : Entity
	{
		protected DbContext _dbContext;

		public Repository(DbContext dbContext)
		{
			_dbContext = dbContext;
		}

		protected DbContext DbContext
		{
			get => _dbContext;
			set => _dbContext = value;
		}

		public virtual void Add(T item)
		{
			DbContext.Set<T>().Add(item);
			DbContext.SaveChanges();
		}

		public virtual T FindById(long id)
		{
			return DbContext.Set<T>().SingleOrDefault(x => x.Id == id);
		}

		public virtual IQueryable<T> GetAll()
		{
			return DbContext.Set<T>();
		}
		public virtual IQueryable<T> GetAll(Func<T, bool> predicate)
		{
			return DbContext.Set<T>().Where(predicate).AsQueryable();
		}

		public virtual void AddRange(IEnumerable<T> item)
		{
			DbContext.Set<T>().AddRange(item);
			DbContext.SaveChanges();
		}

		public virtual void Delete(T item)
		{

			DbContext.Set<T>().Remove(item);
			DbContext.SaveChanges();
		}

		public void DeleteById(long id)
		{
			T item = DbContext.Set<T>().Where(i => i.Id == id).SingleOrDefault();
			DbContext.Set<T>().Remove(item);
			DbContext.SaveChanges();
		}
		public virtual void DeleteRange(IEnumerable<T> items)
		{
			DbContext.Set<T>().RemoveRange(items);
			DbContext.SaveChanges();
		}

		public virtual void Update(T item)
		{
			DbContext.Entry(item).State = EntityState.Modified;
			DbContext.SaveChanges();
		}
	}
}
