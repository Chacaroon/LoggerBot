using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramLogger
{
	class TelegramLoggerProvider : ILoggerProvider
	{
		private string _token;
		private LogLevel _logLevel;

		public TelegramLoggerProvider(string token, LogLevel logLevel)
		{
			_token = token;
			_logLevel = logLevel;
		}

		public ILogger CreateLogger(string categoryName)
		{
			return new TelegramLogger(_token, _logLevel);
		}

		public void Dispose()
		{
		}
	}
}
