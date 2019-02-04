using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.DAL.Models
{
	public interface IEntity
	{
		long Id { get; set; }
		DateTime CreatedAt { get; set; }
	}
}
