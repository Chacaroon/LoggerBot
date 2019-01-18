using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.DAL.Models
{
	public class Entity
	{
		public Guid Id { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
