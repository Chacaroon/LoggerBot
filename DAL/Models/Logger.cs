using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DAL.Models
{
	public class Logger : Entity
	{
		public string Name { get; set; }
		public Guid PrivateToken { get; set; }
		public Guid SubscribeToken { get; set; }
		public IEnumerable<ExceptionInfo> Exceptions { get; set; }
		public IEnumerable<UserLogger> UserLoggers { get; set; }

		public Logger()
		{
			PrivateToken = Guid.NewGuid();
			SubscribeToken = Guid.NewGuid();
		}

		public Logger(string name)
			: this()
		{
			Name = name;
		}

		public void AddException(ExceptionInfo exception)
		{
			Exceptions = Exceptions.Append(exception).ToList();
		}
	}
}
