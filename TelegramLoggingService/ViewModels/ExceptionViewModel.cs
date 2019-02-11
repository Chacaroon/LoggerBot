using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramLoggingService.ViewModels
{
	public class ExceptionViewModel
	{
		public string Message { get; set; }
		public string StackTrace { get; set; }
		public ExceptionViewModel InnerException { get; set; }
	}
}
