using SharedKernel.BLL.Interfaces.Models;
using SharedKernel.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
	public class ExceptionInfo : Entity
	{
		public Logger Logger { get; set; }
		public string Message { get; set; }
		public string StackTrace { get; set; }
		public ExceptionInfo InnerException { get; set; }
	}
}
