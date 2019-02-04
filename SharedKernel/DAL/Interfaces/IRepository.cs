using SharedKernel.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.DAL.Interfaces
{
	public interface IRepository<T> where T : IEntity
	{
		void Add(T item);
		T FindById(long id);

		IEnumerable<T> GetAll(Func<T, bool> predicate);
		IEnumerable<T> GetAll();
		void AddRange(IEnumerable<T> item);
		void Update(T item);
		void Delete(T item);
		void DeleteById(long id);
		void DeleteRange(IEnumerable<T> item);
	}
}
