using SharedKernel.BLL.Interfaces.Models;
using SharedKernel.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
	public class ExceptionInfo : Entity, IExceptionInfo
	{
		public string Message { get; set; }
		public string StackTrace { get; set; }

		[NotMapped]
		IExceptionInfo IExceptionInfo.InnerException
		{
			get => InnerException;
			set => InnerException = value as ExceptionInfo;
		}

		public ExceptionInfo InnerException { get; set; }
	}
}
