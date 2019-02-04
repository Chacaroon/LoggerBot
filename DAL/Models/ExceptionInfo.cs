using SharedKernel.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
	public class ExceptionInfo : Entity
	{
		public string Message { get; set; }
		public string StackTrace { get; set; }
	}
}
