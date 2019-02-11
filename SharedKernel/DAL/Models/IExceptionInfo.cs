using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.DAL.Models
{
	public interface IExceptionInfo : IEntity
	{
		string Message { get; set; }
		string StackTrace { get; set; }
		IExceptionInfo InnerException { get; set; }
	}
}
