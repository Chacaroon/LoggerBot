using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.DAL.Models
{
	public class ExceptionInfo : Entity
	{
		public string Message { get; set; }
		public string StackTrace { get; set; }
	}
}
