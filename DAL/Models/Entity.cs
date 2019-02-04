using SharedKernel.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
	public class Entity : IEntity
	{
		public long Id { get; set; }
		public DateTime CreatedAt { get; set; }

		public Entity()
		{
			CreatedAt = DateTime.UtcNow;
		}
	}
}
