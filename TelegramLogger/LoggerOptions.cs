using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace TelegramLogger
{
	public class LoggerOptions
	{
		public bool LogCustomExceptions { get; set; }
		public LogLevel LogLevel { get; set; }

		public LoggerOptions()
		{
			LogCustomExceptions = false;
			LogLevel = LogLevel.Warning;
		}
	}
}
